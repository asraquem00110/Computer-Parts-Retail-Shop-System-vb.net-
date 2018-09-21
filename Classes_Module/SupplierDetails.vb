Public Class SupplierDetails
    Inherits Systemusers_mysqlcon

    Dim id As Integer
    Dim des As String
    Dim addresss As String
    Dim phone As String

    Public Sub New(ByVal cs As String)
        MyBase.New(cs)
    End Sub


    Public Overrides Function Kuhadiscount() As Decimal
        Dim x As Decimal = (10 / 100)
        Return x
    End Function

    Public Function checkduplicates(ByVal description As String)
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM suppliers WHERE Description=@desc"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@desc", description)

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

    Public Sub viewsuppliers()
        Dim sat As New DataTable
        sat.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM Suppliers"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(sat)
            Suppliers.DataGridView2.DataSource = sat
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub addsupplier(ByVal _desc As String, ByVal _add1 As String, ByVal _phone As String)
        Me.des = _desc
        Me.addresss = _add1
        Me.phone = _phone

        con.ConnectionString = cs
        With cmd
            .CommandText = "INSERT INTO Suppliers (Description,Address,Phoneno) " & _
                           "VALUES (@desc,@add1,@phone) "
            .Connection = con
            .Parameters.AddWithValue("@desc", Me.des)
            .Parameters.AddWithValue("@add1", Me.addresss)
            .Parameters.AddWithValue("@phone", Me.phone)
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

    Public Sub deletesuppliers(ByVal id As Integer)
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM Suppliers WHERE Supplier_id=@suid"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@suid", CInt(id))
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
    Public Sub updatesuppliers(ByVal id As Integer, ByVal des As String, ByVal add1 As String, ByVal phone As String)
        Me.id = id
        Me.des = des
        Me.addresss = add1
        Me.phone = phone



        con.ConnectionString = cs
        With cmd
            .CommandText = "UPDATE Suppliers SET Description=@_desc,Address=@_add1,Phoneno=@_phone " & _
                           "WHERE Supplier_id=@_cid "
            .Connection = con
            .Parameters.AddWithValue("@_cid", CInt(Me.id))
            .Parameters.AddWithValue("@_desc", Me.des)
            .Parameters.AddWithValue("@_phone", Me.phone)
            .Parameters.AddWithValue("@_add1", Me.addresss)
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

    Public Sub viewsupplierdescription()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT Description FROM Suppliers"
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            While dr.Read = True
                Stocksin.cmbsupplier.Items.Add(dr.GetValue(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub generatesupplierlistreport()
        Dim rptdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim strReportPath As String = My.Application.Info.DirectoryPath.ToString() + "\CrystalReports\Supplierlist.rpt"
        rptdoc.Load(strReportPath)
        Dim rpt As New DataTable
        rpt.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM supplier_details"
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
