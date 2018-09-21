Public Class Productinventory
    Inherits Systemusers_mysqlcon
    Public Sub New(ByVal cs As String)
        MyBase.New(cs)
    End Sub



    Public Overrides Function Kuhadiscount() As Decimal
        Dim x As Decimal = (15 / 100)
        Return x
    End Function

    Public Function checkduplicates(ByVal description As String)
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM products WHERE Description=@des"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@des", description)
        Try
            con.Open()
            dr = cmd.ExecuteReader
            cmd.Parameters.Clear()
            If dr.HasRows = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Function

    Public Sub viewproducts()
        Dim ptable As New DataTable
        ptable.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT p.product_id as ID,p.Description,p.cost_price,p.stocksonhand,p.brandname,c.category " & _
                          "FROM Products p " & _
                          "LEFT JOIN category c " & _
                          "ON p.category_category_id=c.category_id " & _
                          "ORDER BY p.Description"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(ptable)
            products.DataGridView2.DataSource = ptable
            Purchase.DataGridView2.DataSource = ptable
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub lagaylahatngproduct()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT Description FROM products;"
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            While dr.Read = True
                products.txtproductsearch.AutoCompleteCustomSource.Add(dr.GetValue(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub lagaylahatngproductpurchase()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT Description FROM products;"
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            While dr.Read = True
                Purchase.txtproductsearch.AutoCompleteCustomSource.Add(dr.GetValue(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub searchproductpurchase(ByVal productname As String)
        Dim cus As New DataTable
        cus.Clear()
        con.ConnectionString = cs
        If Purchase.txtproductsearch.Text = "" Then
            viewproducts()
        Else
            cmd.CommandText = "SELECT p.product_id,p.Description,p.cost_price,p.stocksonhand,p.brandname,c.category " & _
                          "FROM Products p " & _
                          "LEFT JOIN category c " & _
                          "ON p.category_category_id=c.category_id " & _
                          "WHERE p.Description like @name "
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@name", productname)
        End If

        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(cus)
            Purchase.DataGridView2.DataSource = cus
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub searchproduct(ByVal productname As String)
        Dim cus As New DataTable
        cus.Clear()
        con.ConnectionString = cs
        If products.txtproductsearch.Text = "" Then
            viewproducts()
        Else
            cmd.CommandText = "SELECT p.product_id,p.Description,p.cost_price,p.stocksonhand,p.brandname,c.category " & _
                          "FROM Products p " & _
                          "LEFT JOIN category c " & _
                          "ON p.category_category_id=c.category_id " & _
                          "WHERE p.Description like @name "
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@name", productname)
        End If

        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(cus)
            products.DataGridView2.DataSource = cus
            Purchase.DataGridView2.DataSource = cus
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub insertproducts(ByVal descrip As String, ByVal categ As String, ByVal brand As String, ByVal pric As Decimal)
        con.ConnectionString = cs
        With cmd
            .CommandText = "INSERT INTO Products (Description,cost_price,brandname,category_category_id) " & _
                           "VALUES (@des,@price,@brandname,(SELECT category_id FROM category WHERE category=@category)) "
            .Connection = con
            .Parameters.AddWithValue("@des", descrip)
            .Parameters.AddWithValue("@category", categ)
            .Parameters.AddWithValue("@brandname", brand)
            .Parameters.AddWithValue("@price", CDec(pric))
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
            MsgBox("Sucessfully inserted")
        End Try
    End Sub

    Public Sub updateproducts(ByVal descrip As String, ByVal categ As String, ByVal brand As String, ByVal pric As Decimal, ByVal id As Integer)
        con.ConnectionString = cs
        With cmd
            .CommandText = "UPDATE products set Description=@des,cost_price=@price,brandname=@brandname, " & _
                           "category_category_id=(SELECT category_id FROM category WHERE category=@category) WHERE product_id=@id "
            .Connection = con
            .Parameters.AddWithValue("@des", descrip)
            .Parameters.AddWithValue("@category", categ)
            .Parameters.AddWithValue("@brandname", brand)
            .Parameters.AddWithValue("@price", CDec(pric))
            .Parameters.AddWithValue("@id", CInt(id))
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            MsgBox("Sucessfully updated")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub deleteproducts(ByVal id As Integer)
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM products where product_id=@id "
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@id", id)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            MsgBox("Successfully Deleted")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub viewcategory()
        Dim cattable As New DataTable
        cattable.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM category ORDER BY category"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(cattable)
            Categories.DataGridView2.DataSource = cattable
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub addcategory(ByVal category As String)
        con.ConnectionString = cs

        cmd.CommandText = "INSERT INTO category (category) VALUES (@category)"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@category", category)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try


    End Sub

    Public Sub deletecategory(ByVal id As Integer)
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM category WHERE category_id=@id"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@id", id)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try

    End Sub

    Public Sub kuhacategoryname()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT category FROM category ORDER BY category"
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            While dr.Read = True
                products.cmbcategory.Items.Add(dr.GetValue(0))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub viewstocksin()
        Dim stk As New DataTable
        stk.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM stocksin"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(stk)
            Stocksin.DataGridView2.DataSource = stk
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub filterstocksin()
        con.Close()
        Dim stk As New DataTable
        stk.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM stocksin WHERE DateIn >='" & Format(Stocksin.dtpstart.Value, "yyyy-MM-dd") & "' AND DateIn <='" & Format(Stocksin.dtpend.Value, "yyyy-MM-dd") & "'"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(stk)
            Stocksin.DataGridView2.DataSource = stk
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub deletestocksin()
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM stocksin WHERE DateIn >='" & Format(Stocksin.dtpstart.Value, "yyyy-MM-dd") & "' AND DateIn <='" & Format(Stocksin.dtpend.Value, "yyyy-MM-dd") & "'"
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

    Public Sub insertstocksin(ByVal pid As Integer, ByVal cost As Decimal, ByVal bilang As Integer, ByVal description As String, ByVal datee As Date)
        con.ConnectionString = cs
        With cmd
            .CommandText = "INSERT INTO stocksin (quantity,Priceperpiece,DateIn,Products_product_id,suppliers_supplier_id) " & _
                   "VALUES (@quantity,@pcost,@date,@pid,(SELECT supplier_id FROM suppliers WHERE Description=@sdesc)) "
            .Connection = con
            .Parameters.AddWithValue("@date", Format(datee, "yyyy-MM-dd"))
            .Parameters.AddWithValue("@pid", pid)
            .Parameters.AddWithValue("@pcost", cost)
            .Parameters.AddWithValue("@quantity", bilang)
            .Parameters.AddWithValue("@sdesc", description)
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try

    End Sub

    'Public Sub insertstocksin(ByVal pid As Integer, ByVal cost As Decimal, ByVal bilang As Integer, ByVal description As String, ByVal datee As Date)
    '    Dim x As Integer
    '    con.ConnectionString = cs
    '    con.Open()
    '    transact = con.BeginTransaction()
    '    cmd.Connection = con
    '    cmd.Transaction = transact

    '    Try
    '        With cmd
    '            'inserting to stocksin table 
    '            .CommandText = "INSERT INTO stocksin (quantity,Priceperpiece,DateIn,Products_product_id,suppliers_supplier_id) " & _
    '                 "VALUES (@quantity,@pcost,@date,@pid,(SELECT supplier_id FROM suppliers WHERE Description=@sdesc)) "
    '            .Connection = con
    '            .Parameters.AddWithValue("@date", Format(datee, "yyyy-MM-dd"))
    '            .Parameters.AddWithValue("@pid", pid)
    '            .Parameters.AddWithValue("@pcost", cost)
    '            .Parameters.AddWithValue("@quantity", bilang)
    '            .Parameters.AddWithValue("@sdesc", description)
    '            .ExecuteNonQuery()

    '            'kinukuha ung stocksonhand ng item na inupdate
    '            .CommandText = "SELECT stocksonhand FROM products WHERE product_id=@pid"
    '            dr = .ExecuteReader
    '            dr.Read()
    '            x = dr.GetValue(0)
    '            dr.Close()
    '            'MsgBox(x)

    '            'inuupdate ngaun ung stocks ng product
    '            .CommandText = "UPDATE products SET stocksonhand = (" & CInt(x) & " + @quantity) WHERE product_id=@pid"
    '            .ExecuteNonQuery()
    '        End With
    '        cmd.Parameters.Clear()

    '        'kung wlang error magcocommit lahat ng querries
    '        transact.Commit()
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString)
    '        Try
    '            'dito magrorollback ung tatlong query na nasa taas
    '            transact.Rollback()
    '        Catch ex2 As Exception
    '            MsgBox(ex2.Message.ToString)
    '        End Try
    '    Finally
    '        con.Close()
    '    End Try


    'End Sub


    Public Function kuhalastinsertedproductid(ByRef description As String)
        Dim id As Integer
        con.ConnectionString = cs
        cmd.CommandText = "SELECT product_id,Description FROM products WHERE product_id=(SELECT product_id FROM products ORDER BY product_id DESC LIMIT 1) "
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            dr.Read()
            description = dr.GetValue(1)
            id = dr.GetValue(0)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
        Return id
    End Function

    Public Sub generatestocksinreport()
        Dim rptdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim strReportPath As String = My.Application.Info.DirectoryPath.ToString() + "\CrystalReports\Stocksinreport.rpt"
        rptdoc.Load(strReportPath)
        Dim rpt As New DataTable
        rpt.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT stocksin_id,DateIn,supplier_id,quantity,Priceperpiece,product_id FROM stocksinview " & _
                          "WHERE DateIn >='" & Format(Stocksin.dtpstart.Value, "yyyy-MM-dd") & "' AND DateIn <='" & Format(Stocksin.dtpend.Value, "yyyy-MM-dd") & "'"
        cmd.Connection = con

        con.Open()
        da.SelectCommand = cmd
        da.Fill(rpt)
        cmd.CommandText = "SELECT SUM(quantity*Priceperpiece) FROM stocksinview " & _
                          "WHERE DateIn >='" & Format(Stocksin.dtpstart.Value, "yyyy-MM-dd") & "' AND DateIn <='" & Format(Stocksin.dtpend.Value, "yyyy-MM-dd") & "'"
        dr = cmd.ExecuteReader
        dr.Read()
        rptdoc.SetDataSource(rpt)
        rptdoc.SetParameterValue("Total", dr.GetValue(0))
        Reports.CrystalReportViewer1.ReportSource = rptdoc
     
        con.Close()

    End Sub


    Public Sub generateproductlistreport()

        Dim rptdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim strReportPath As String = My.Application.Info.DirectoryPath.ToString() + "\CrystalReports\Productlist.rpt"
        rptdoc.Load(strReportPath)
        Dim rpt As New DataTable
        rpt.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM product_details"
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
