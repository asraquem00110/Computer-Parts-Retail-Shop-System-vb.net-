Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Systemusers_mysqlcon
    Public con As New MySqlConnection
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dr As MySqlDataReader
    Public transact As MySqlTransaction
    ' Public haha As String = "yow"

    Dim userlname As String
    Dim userfname As String
    Dim username As String
    Dim userpassword As String
    Dim userrole As String

    Public cs As String

    Public Sub New(ByVal cs As String)
        Me.cs = cs
    End Sub

    Public Overridable Function Kuhadiscount() As Decimal
        Dim x As Decimal = (5 / 100)
        Return x
    End Function



    Public Property kuhauserlname()
        Set(ByVal value)
            Me.userlname = value
        End Set
        Get
            Return Me.userlname
        End Get
    End Property

    Public Property kuhauserfname()
        Set(ByVal value)
            Me.userfname = value
        End Set
        Get
            Return Me.userfname
        End Get
    End Property

    Public Property kuhausername()
        Set(ByVal value)
            Me.username = value
        End Set
        Get
            Return Me.username
        End Get
    End Property

    Public Property kuhauserpassword()
        Set(ByVal value)
            Me.userpassword = value
        End Set
        Get
            Return Me.userpassword
        End Get
    End Property

    Public Property kuhauserrole()
        Set(ByVal value)
            Me.userrole = value
        End Set
        Get
            Return Me.userrole
        End Get
    End Property

    Public Sub adduser()

        con.ConnectionString = cs
        With cmd
            .CommandText = "INSERT INTO users (lname,fname,username,password,Roles_role_id) " & _
                           "VALUES (@l,@f,@u,@p,(SELECT role_id FROM Roles WHERE Description=@r)) "
            .Connection = con
            .Parameters.AddWithValue("@f", Me.userfname)
            .Parameters.AddWithValue("@l", Me.userlname)
            .Parameters.AddWithValue("@u", Me.username)
            .Parameters.AddWithValue("@p", Me.userpassword)
            .Parameters.AddWithValue("@r", Me.userrole)
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


    Public Function checkduplicates(ByVal lname As String, ByVal fname As String, ByVal username As String)
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM users WHERE lname=@lname AND fname=@fname AND username=@user"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@lname", lname)
        cmd.Parameters.AddWithValue("@fname", fname)
        cmd.Parameters.AddWithValue("@user", username)
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

    Public Sub viewusers()
        Dim usertable As New DataTable
        usertable.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT u.user_id,u.lname,u.fname,u.username,u.password,r.Description FROM users u " & _
                          "INNER JOIN roles r " & _
                          "ON u.Roles_role_id=r.role_id " & _
                          "ORDER BY CONCAT(lname,fname)"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(usertable)
            users.DataGridView2.DataSource = usertable
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub updateuser(ByVal lname As String, ByVal fname As String, ByVal username As String, ByVal password As String, ByVal role As String, ByVal id As Integer)
        con.ConnectionString = cs
        With cmd
            .CommandText = "UPDATE users SET fname=@f,lname=@l,username=@u,password=@p,Roles_role_id=(SELECT role_id FROM Roles WHERE Description=@r) " & _
                           "WHERE user_id=@i "
            .Connection = con
            .Parameters.AddWithValue("@f", fname)
            .Parameters.AddWithValue("@l", lname)
            .Parameters.AddWithValue("@u", username)
            .Parameters.AddWithValue("@p", password)
            .Parameters.AddWithValue("@r", role)
            .Parameters.AddWithValue("@i", id)
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

    Public Sub deleteuser(ByVal cid As Integer)
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM users WHERE user_id =@id"
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

    Public Sub kuharoles()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT Description FROM roles"
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            While dr.Read = True
                users.cmbroles.Items.Add(dr.GetValue(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()

        End Try
    End Sub


    Function checkaccount()

        Dim num As Integer
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM users WHERE username=@uname AND password=@pass"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@uname", Login.txtuname.Text)
        cmd.Parameters.AddWithValue("@pass", Login.txtpass.Text)
        Try
            con.Open()
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                MsgBox("Account exist")
                num = dr.GetValue(5)
                MainForm.Show()
                MainForm.lbluser.Text = dr.GetValue(1) + ", " + dr.GetValue(2)
                MainForm.lblid.Text = dr.GetValue(0)
                Login.Hide()
            Else
                MsgBox("doesnt exist")
            End If
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
        Return num
    End Function


    Public Sub checkroles()
        Dim id = checkaccount()
        Dim x As String
        con.ConnectionString = cs
        cmd.CommandText = "SELECT p.Description,r.Description FROM permissions p " & _
                          "INNER JOIN rolepermissions ro " & _
                          "ON p.permission_id=ro.Permissions_permission_id " & _
                          "INNER JOIN roles r " & _
                          "ON ro.roles_role_id=r.role_id " & _
                          "WHERE r.role_id=" & id & " "
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            While dr.Read = True
                MainForm.lblrole.Text = dr.GetValue(1)
                x = dr.GetValue(0)
                '   MsgBox(x)
                If x = "Make Transaction" Then
                    MainForm.cmdtransact.Enabled = True
                ElseIf x = "View System Users" Then
                    MainForm.cmdusers.Enabled = True
                ElseIf x = "Add System Users" Then
                    users.cmdadd.Enabled = True
                ElseIf x = "Delete System Users" Then
                    users.cmddelete.Enabled = True
                ElseIf x = "Update System Users" Then
                    users.cmdupdate.Enabled = True
                ElseIf x = "View Roles" Then
                    users.cmdroles.Enabled = True
                ElseIf x = "View Customer" Then
                    MainForm.cmdcustomer.Enabled = True
                ElseIf x = "Add Customer" Then
                    Customer_Details.cmdshowadd.Enabled = True
                ElseIf x = "Delete Customer" Then
                    Customer_Details.cmddelete.Enabled = True
                ElseIf x = "Update Customer" Then
                    Customer_Details.cmdupdate.Enabled = True
                ElseIf x = "View Inventory" Then
                    MainForm.cmdproduct.Enabled = True
                ElseIf x = "Add Product" Then
                    products.cmdshowadd.Enabled = True
                ElseIf x = "Delete Product" Then
                    products.cmddelete.Enabled = True
                ElseIf x = "Update Inventory" Then
                    products.cmdupdate.Enabled = True
                ElseIf x = "View Supplier" Then
                    MainForm.cmdsuppliers.Enabled = True
                ElseIf x = "Add Supplier" Then
                    Suppliers.cmdadd.Enabled = True
                ElseIf x = "Delete Supplier" Then
                    Suppliers.cmddelete.Enabled = True
                ElseIf x = "Update Supplier" Then
                    Suppliers.cmdupdate.Enabled = True
                ElseIf x = "View Records" Then
                    MainForm.cmdrecords.Enabled = True
                End If



            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub



    Public Sub generatesystemuserslistreport()
        Dim rptdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim strReportPath As String = My.Application.Info.DirectoryPath.ToString() + "\CrystalReports\Systemuserlist.rpt"
        rptdoc.Load(strReportPath)
        Dim rpt As New DataTable
        rpt.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT * FROM systemuser_details"
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

    Public Sub viewroles()
        con.Close()
        Dim rtbl As New DataTable
        rtbl.Clear()
        con.ConnectionString = cs
        cmd.CommandText = "SELECT Description FROM roles"
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(rtbl)
            Roles.DataGridView2.DataSource = rtbl
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub viewcheckroles(ByVal des As String)
        con.Close()
        Dim x As String
        con.ConnectionString = cs
        cmd.CommandText = "SELECT p.Description,r.Description FROM permissions p " & _
                          "INNER JOIN rolepermissions ro " & _
                          "ON p.permission_id=ro.Permissions_permission_id " & _
                          "INNER JOIN roles r " & _
                          "ON ro.roles_role_id=r.role_id " & _
                          "WHERE r.role_id=(SELECT role_id FROM roles WHERE Description='" & des & "')"
        cmd.Connection = con
        Try
            con.Open()
            dr = cmd.ExecuteReader
            While dr.Read = True
                x = dr.GetValue(0)
                If x = "Make Transaction" Then
                    Roles.cmdmaketransaction.Checked = True
                ElseIf x = "View System Users" Then
                    Roles.cmdviewsystemusers.Checked = True
                ElseIf x = "Add System Users" Then
                    Roles.cmdaddsystemusers.Checked = True
                ElseIf x = "Delete System Users" Then
                    Roles.cmddeletesystemusers.Checked = True
                ElseIf x = "Update System Users" Then
                    Roles.cmdupdatesystemusers.Checked = True
                ElseIf x = "View Roles" Then
                    Roles.cmdviewroles.Checked = True
                ElseIf x = "View Customer" Then
                    Roles.cmdviewcustomer.Checked = True
                ElseIf x = "Add Customer" Then
                    Roles.cmdaddcustomer.Checked = True
                ElseIf x = "Delete Customer" Then
                    Roles.cmddeletecustomer.Checked = True
                ElseIf x = "Update Customer" Then
                    Roles.cmdupdatecustomer.Checked = True
                ElseIf x = "View Inventory" Then
                    Roles.cmdviewinventory.Checked = True
                ElseIf x = "Add Product" Then
                    Roles.cmdaddproduct.Checked = True
                ElseIf x = "Delete Product" Then
                    Roles.cmddeleteproduct.Checked = True
                ElseIf x = "Update Inventory" Then
                    Roles.cmdupdateinventory.Checked = True
                ElseIf x = "View Supplier" Then
                    Roles.cmdviewsupplier.Checked = True
                ElseIf x = "Add Supplier" Then
                    Roles.cmdaddsupplier.Checked = True
                ElseIf x = "Delete Supplier" Then
                    Roles.cmddeletesupplier.Checked = True
                ElseIf x = "Update Supplier" Then
                    Roles.cmdupdatesupplier.Checked = True
                ElseIf x = "View Records" Then
                    Roles.cmdviewrecords.Checked = True

                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub insertrolepermission(ByVal query As String)
        con.Close()
        con.ConnectionString = cs
        cmd.CommandText = query
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteReader()
            MsgBox("Successfully Updated")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub insertnewroles(ByVal des As String)
        con.Close()
        con.ConnectionString = cs
        cmd.CommandText = "INSERT INTO roles (Description) VALUES (@des)"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@des", des)
        Try
            con.Open()
            cmd.ExecuteReader()
            MsgBox("Successfully Inserted")
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub deleteroles(ByVal des As String)
        con.Close()
        con.ConnectionString = cs
        cmd.CommandText = "DELETE FROM roles WHERE Description=@des"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@des", des)
        Try
            con.Open()
            cmd.ExecuteReader()
            MsgBox("Successfully Deleted")
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub
End Class
