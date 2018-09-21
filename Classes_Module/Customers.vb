Public Class Customers
    Inherits Systemusers_mysqlcon

    Dim fname As String
    Dim lname As String
    Dim phone As String
    Dim address As String
    Dim id As Integer

    Public Sub New(ByVal cs As String)
        MyBase.New(cs)
    End Sub


    Public Overrides Function Kuhadiscount() As Decimal
        Dim x As Decimal = (20 / 100)
        Return x
    End Function

    Public Function checkduplicates(ByVal lname As String, ByVal fname As String, ByVal address As String)
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM customers WHERE lname=@lname AND fname=@fname AND address=@email"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@lname", lname)
        cmd.Parameters.AddWithValue("@fname", fname)
        cmd.Parameters.AddWithValue("@email", address)
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


    Public Sub viewcustomers()
        Dim ctable As New DataTable
        ctable.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM customers ORDER BY customer_id DESC"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(ctable)
            Customer_Details.DataGridView2.DataSource = ctable
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub lagaylahatngcustomer()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT concat_ws(',',lname,fname) FROM customers;"
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader


            While dr.Read = True
                Customer_Details.txtcustomersearch.AutoCompleteCustomSource.Add(dr.GetValue(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub searchcustomer(ByVal fullname As String)
        Dim cus As New DataTable
        cus.Clear()
        con.ConnectionString = cs
        If Customer_Details.txtcustomersearch.Text = "" Then
            viewcustomers()
        Else
            cmd.CommandText = "SELECT * FROM customers WHERE concat_ws(',',lname,fname)like @name "
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@name", fullname)
        End If

        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(cus)
            Customer_Details.DataGridView2.DataSource = cus
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub addcustomer(ByVal fname As String, ByVal lname As String, ByVal phone As String, ByVal address As String)
        Me.lname = lname
        Me.fname = fname
        Me.phone = phone
        Me.address = address
        con.ConnectionString = cs
        With cmd
            .CommandText = "INSERT INTO customers (fname,lname,phonenumber,address) " & _
                           "VALUES (@f,@l,@p,@e) "
            .Connection = con
            .Parameters.AddWithValue("@f", Me.fname)
            .Parameters.AddWithValue("@l", Me.lname)
            .Parameters.AddWithValue("@p", Me.phone)
            .Parameters.AddWithValue("@e", Me.address)
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            '   MsgBox("Sucessfully inserted")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub updatecustomer(ByVal fname As String, ByVal lname As String, ByVal phone As String, ByVal address As String, ByVal id As Integer)
        Me.lname = lname
        Me.fname = fname
        Me.phone = phone
        Me.address = address
        Me.id = id
        con.ConnectionString = cs
        With cmd
            .CommandText = "UPDATE customers SET fname=@f,lname=@l,phonenumber=@p,address=@e " & _
                           "WHERE customer_id=@i "
            .Connection = con
            .Parameters.AddWithValue("@f", Me.fname)
            .Parameters.AddWithValue("@l", Me.lname)
            .Parameters.AddWithValue("@p", Me.phone)
            .Parameters.AddWithValue("@e", Me.address)
            .Parameters.AddWithValue("@i", CInt(Me.id))
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

    Public Sub deletecustomer(ByVal cid As Integer)
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM customers WHERE customer_id =@id"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@id", CInt(cid))
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


    Public Sub generatecustomerlistreport()
        Dim rptdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim strReportPath As String = My.Application.Info.DirectoryPath.ToString() + "\CrystalReports\Customer.rpt"
        rptdoc.Load(strReportPath)
        Dim rpt As New DataTable
        rpt.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM customer_details"
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
