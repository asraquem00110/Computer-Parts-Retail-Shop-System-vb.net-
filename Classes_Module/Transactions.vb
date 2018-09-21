Public Class Transactions
    Inherits Systemusers_mysqlcon

    Sub New(ByVal cs As String)
        MyBase.New(cs)
    End Sub



    Public Sub createtemporarytablefororders()
        con.ConnectionString = cs
        cmd.CommandText = "create temporary table IF NOT EXISTS `cprss`.`order" & Purchase.txtcustomerid.Text & "`( " & _
                          "customerid INT NOT NULL, " & _
                          "quantity INT(11),costprice Decimal(20,2),ProductID INT(11) NOT NULL,Productdescription Varchar(100),orderdate DATE,orderid INT(11),PRIMARY KEY(ProductID)); "
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub



    Public Sub inserttemporder(ByVal quantity As Integer)
        con.ConnectionString = cs
        cmd.CommandText = "INSERT INTO order" & Purchase.txtcustomerid.Text & " (customerid,quantity,costprice,ProductID,Productdescription,orderdate) " & _
                          "VALUES (" & Purchase.txtcustomerid.Text & ",@quantity," & Purchase.txtprice.Text & "," & Purchase.txtid.Text & ",'" & Purchase.txtdescription.Text & "',curdate()) " & _
                          "ON DUPLICATE KEY UPDATE customerid=" & Purchase.txtcustomerid.Text & ",quantity=@quantity,costprice=" & Purchase.txtprice.Text & ",ProductID=" & Purchase.txtid.Text & ",Productdescription='" & Purchase.txtdescription.Text & "',orderdate=curdate()"

        cmd.Connection = con
        cmd.Parameters.AddWithValue("@quantity", quantity)
        Try
            con.Open()
            cmd.ExecuteReader()
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub computetotal()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT SUM(quantity*costprice) FROM order" & Purchase.txtcustomerid.Text & " WHERE customerid=" & Purchase.txtcustomerid.Text & " AND orderdate=curdate()"
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            dr.Read()
            If Not IsDBNull(dr.GetValue(0)) Then
                Purchase.txttotalamount.Text = CDec(dr.GetValue(0))
            Else
                Purchase.txttotalamount.Text = "0.00"
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub deletefromtemporder(ByVal id As Integer)
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM order" & Purchase.txtcustomerid.Text & " WHERE ProductID=@id AND customerid=" & Purchase.txtcustomerid.Text & " AND orderdate=curdate()"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@id", id)
        Try
            con.Open()
            cmd.ExecuteReader()
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub removeallfromtemporder()
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM order" & Purchase.txtcustomerid.Text & " WHERE orderdate=curdate()"
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub selecttemporder()
        Dim tbl As New DataTable
        con.ConnectionString = cs
        cmd.CommandText = "SELECT ProductID as ID,Productdescription,quantity,costprice,(quantity*costprice) as TotalPrice FROM order" & Purchase.txtcustomerid.Text & " WHERE customerid=" & Purchase.txtcustomerid.Text & " AND orderdate=curdate()"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(tbl)
            Purchase.DataGridView1.DataSource = tbl
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub maketransaction(ByVal cid As Integer, ByVal uid As Integer)
        Dim oid As Integer
        Dim discount As Decimal = Purchase.generatediscount


        con.ConnectionString = cs
        con.Open()
        transact = con.BeginTransaction
        cmd.Connection = con
        cmd.Transaction = transact

        Try
            cmd.CommandText = "INSERT INTO orderline (Customers_customer_id,Users_user_id,orderdate) " & _
                              "VALUES (" & cid & "," & uid & ",curdate()) "
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT MAX(order_id) FROM orderline "
            cmd.Connection = con
            dr = cmd.ExecuteReader
            dr.Read()
            oid = dr.GetValue(0)
            dr.Close()
            ' MsgBox(oid)

            cmd.CommandText = "UPDATE order" & Purchase.txtcustomerid.Text & " SET orderid=" & oid & " WHERE customerid=" & Purchase.txtcustomerid.Text & " AND orderdate=curdate()"
            cmd.Connection = con
            cmd.ExecuteNonQuery()

            cmd.CommandText = "INSERT INTO orderinfo (quantity_,cost_price,Orderline_order_id,Products_product_id) " & _
                              "SELECT quantity,(costprice-(costprice*" & discount & ")),orderid,ProductID FROM order" & Purchase.txtcustomerid.Text & ""
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            transact.Commit()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Try
                'dito magrorollback ung  query na nasa taas
                transact.Rollback()
            Catch ex2 As Exception
                MsgBox(ex2.Message.ToString)
            End Try
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub generatereceipt()
        Dim rptdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim strReportPath As String = My.Application.Info.DirectoryPath.ToString() + "\CrystalReports\Receipts.rpt"
        rptdoc.Load(strReportPath)
        Dim rpt As New DataTable
        rpt.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM transactions where order_id=(SELECT MAX(order_id) FROM transactions)"
        cmd.Connection = con

        con.Open()
        da.SelectCommand = cmd
        da.Fill(rpt)
        rptdoc.SetDataSource(rpt)
        cmd.CommandText = "SELECT CONCAT(CustomerLname,'" & ", " & "',CustomerFname) FROM transactions where order_id=(SELECT MAX(order_id) FROM transactions)"
        dr = cmd.ExecuteReader
        dr.Read()
        rptdoc.SetParameterValue("CustomerName", dr.GetValue(0))
        dr.Close()
        cmd.CommandText = "SELECT CONCAT(CashierLname,'" & ", " & "',CashierFname) FROM transactions where order_id=(SELECT MAX(order_id) FROM transactions)"
        dr = cmd.ExecuteReader
        dr.Read()
        rptdoc.SetParameterValue("CashierName", dr.GetValue(0))
        dr.Close()
        Dim discount As Decimal
        With Purchase

            If .cmbdiscount.Text = "No Discount" Then
                discount = 0
            ElseIf .cmbdiscount.Text = "5%" Then
                discount = 0.05
            ElseIf .cmbdiscount.Text = "10%" Then
                discount = 0.1
            ElseIf .cmbdiscount.Text = "15%" Then
                discount = 0.15
            ElseIf .cmbdiscount.Text = "20%" Then
                discount = 0.2
            Else
                discount = 0
            End If
        End With
        cmd.CommandText = "SELECT SUM((oi.quantity_*p.cost_price)*" & discount & "),SUM((oi.quantity_*p.cost_price)) " & _
                          "FROM products p INNER JOIN orderinfo oi ON p.product_id=oi.Products_product_id " & _
                          "INNER JOIN orderline o ON o.order_id=oi.Orderline_order_id " & _
                          "WHERE o.order_id=(SELECT MAX(order_id) FROM transactions) "
        dr = cmd.ExecuteReader
        dr.Read()
        rptdoc.SetParameterValue("discountprice", dr.GetValue(0))
        rptdoc.SetParameterValue("originalprice", dr.GetValue(1))
        dr.Close()
        Reports.CrystalReportViewer1.ReportSource = rptdoc
        con.Close()

    End Sub



    Public Sub viewrecordtransactions()
        Dim tbl As New DataTable
        tbl.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "Select o.order_id as OrderID,o.Customers_customer_id as CustomerID,o.Users_user_id as SalesRepID,o.orderdate, " & _
                          "oi.Products_product_id as ProductID,oi.quantity_ as Quantity,oi.cost_price as CostPrice " & _
                          "from orderline o inner join orderinfo oi on o.order_id=oi.Orderline_order_id "
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(tbl)
            Records.DataGridView2.DataSource = tbl
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub filtertransactionsrecord()
        Dim tbl As New DataTable
        tbl.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "Select o.order_id as OrderID,o.Customers_customer_id as CustomerID,o.Users_user_id as SalesRepID,o.orderdate, " & _
                          "oi.Products_product_id as ProductID,oi.quantity_ as Quantity,oi.cost_price as CostPrice " & _
                          "from orderline o inner join orderinfo oi on o.order_id=oi.Orderline_order_id " & _
                          "WHERE o.orderdate>='" & Format(Records.dtpstart.Value, "yyyy-MM-dd") & "' AND o.orderdate <='" & Format(Records.dtpend.Value, "yyyy-MM-dd") & "'"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(tbl)
            Records.DataGridView2.DataSource = tbl
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub deletefilteredtransactionrecord()

        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM orderline WHERE orderdate>='" & Format(Records.dtpstart.Value, "yyyy-MM-dd") & "' AND orderdate <='" & Format(Records.dtpend.Value, "yyyy-MM-dd") & "'"
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub generatefilteredreporttransactionrecord()
        Dim rptdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim strReportPath As String = My.Application.Info.DirectoryPath.ToString() + "\CrystalReports\Transact.rpt"
        rptdoc.Load(strReportPath)
        Dim rpt As New DataTable
        rpt.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM Records_Transactions WHERE orderdate>='" & Format(Records.dtpstart.Value, "yyyy-MM-dd") & "' AND orderdate <='" & Format(Records.dtpend.Value, "yyyy-MM-dd") & "' "
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(rpt)
            rptdoc.SetDataSource(rpt)
            Reports.CrystalReportViewer1.ReportSource = rptdoc
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub



End Class
