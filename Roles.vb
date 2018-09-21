Public Class Roles
    Dim sql As String = ""

    Dim Systemusers_mysqlcon As Systemusers_mysqlcon = New Systemusers_mysqlcon(MainForm.cs)
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
        richtexxt.Clear()
    End Sub




    Private Sub Roles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Systemusers_mysqlcon.viewroles()
    End Sub

    Sub clearcheckboxes()
        cmdmaketransaction.Checked = False
        cmdaddsystemusers.Checked = False
        cmdviewsystemusers.Checked = False
        cmddeletesystemusers.Checked = False
        cmdupdatesystemusers.Checked = False
        cmdviewcustomer.Checked = False
        cmdaddcustomer.Checked = False
        cmddeletecustomer.Checked = False
        cmdupdatecustomer.Checked = False
        cmdviewinventory.Checked = False
        cmdaddproduct.Checked = False
        cmddeleteproduct.Checked = False
        cmdupdateinventory.Checked = False
        cmdviewsupplier.Checked = False
        cmdaddsupplier.Checked = False
        cmddeletesupplier.Checked = False
        cmdupdatesupplier.Checked = False
        cmdviewrecords.Checked = False
        cmdviewroles.Checked = False
    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        Dim description As String = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
        Panel2.Visible = True
        clearcheckboxes()
        Systemusers_mysqlcon.viewcheckroles(description)
    End Sub

    Function genereatequery(ByVal permission As String) As String
        Dim description As String = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
        Dim query As String = "INSERT INTO rolepermissions (Roles_role_id,Permissions_permission_id)  " & _
                      "VALUES ((SELECT role_id FROM roles WHERE Description='" & description & "')," & _
                      "(SELECT permission_id FROM permissions WHERE Description='" & permission & "')) " & _
                      "ON DUPLICATE KEY UPDATE Roles_role_id = (SELECT role_id FROM roles WHERE Description='" & description & "'), " & _
                      "Permissions_permission_id=(SELECT permission_id FROM permissions WHERE Description='" & permission & "'); "
        Return query
    End Function

    Function deletequery(ByVal permission As String) As String
        Dim description As String = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
        Dim query As String = "DELETE FROM rolepermissions WHERE Roles_role_id=(SELECT role_id FROM roles WHERE Description='" & description & "') " & _
                              "AND Permissions_permission_id=(SELECT permission_id FROM permissions WHERE Description='" & permission & "'); "
        Return query
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        sql = ""
        If cmdmaketransaction.Checked = True Then
            sql = sql + genereatequery("Make Transaction")
        End If
        If cmdmaketransaction.Checked = False Then
            sql = sql + deletequery("Make Transaction")
        End If
        If cmdviewsystemusers.Checked = True Then
            sql = sql + genereatequery("View System Users")
        End If
        If cmdviewsystemusers.Checked = False Then
            sql = sql + deletequery("View System Users")
        End If
        If cmdaddsystemusers.Checked = True Then
            sql = sql + genereatequery("Add System Users")
        End If
        If cmdaddsystemusers.Checked = False Then
            sql = sql + deletequery("Add System Users")
        End If
        If cmddeletesystemusers.Checked = True Then
            sql = sql + genereatequery("Delete System Users")
        End If
        If cmddeletesystemusers.Checked = False Then
            sql = sql + deletequery("Delete System Users")
        End If
        If cmdupdatesystemusers.Checked = True Then
            sql = sql + genereatequery("Update System Users")
        End If
        If cmdupdatesystemusers.Checked = False Then
            sql = sql + deletequery("Update System Users")
        End If
        If cmdviewroles.Checked = True Then
            sql = sql + genereatequery("View Roles")
        End If
        If cmdviewroles.Checked = False Then
            sql = sql + deletequery("View Roles")
        End If
        If cmdviewcustomer.Checked = True Then
            sql = sql + genereatequery("View Customer")
        End If
        If cmdviewcustomer.Checked = False Then
            sql = sql + deletequery("View Customer")
        End If
        If cmdaddcustomer.Checked = True Then
            sql = sql + genereatequery("Add Customer")
        End If
        If cmdaddcustomer.Checked = False Then
            sql = sql + deletequery("Add Customer")
        End If
        If cmddeletecustomer.Checked = True Then
            sql = sql + genereatequery("Delete Customer")
        End If
        If cmddeletecustomer.Checked = False Then
            sql = sql + deletequery("Delete Customer")
        End If
        If cmdupdatecustomer.Checked = True Then
            sql = sql + genereatequery("Update Customer")
        End If
        If cmdupdatecustomer.Checked = False Then
            sql = sql + deletequery("Update Customer")
        End If
        If cmdviewinventory.Checked = True Then
            sql = sql + genereatequery("View Inventory")
        End If
        If cmdviewinventory.Checked = False Then
            sql = sql + deletequery("View Inventory")
        End If
        If cmdaddproduct.Checked = True Then
            sql = sql + genereatequery("Add Product")
        End If
        If cmdaddproduct.Checked = False Then
            sql = sql + deletequery("Add Product")
        End If
        If cmddeleteproduct.Checked = True Then
            sql = sql + genereatequery("Delete Product")
        End If
        If cmddeleteproduct.Checked = False Then
            sql = sql + deletequery("Delete Product")
        End If
        If cmdupdateinventory.Checked = True Then
            sql = sql + genereatequery("Update Inventory")
        End If
        If cmdupdateinventory.Checked = False Then
            sql = sql + deletequery("Update Inventory")
        End If
        If cmdviewsupplier.Checked = True Then
            sql = sql + genereatequery("View Supplier")
        End If
        If cmdviewsupplier.Checked = False Then
            sql = sql + deletequery("View Supplier")
        End If
        If cmdaddsupplier.Checked = True Then
            sql = sql + genereatequery("Add Supplier")
        End If
        If cmdaddsupplier.Checked = False Then
            sql = sql + deletequery("Add Supplier")
        End If
        If cmddeletesupplier.Checked = True Then
            sql = sql + genereatequery("Delete Supplier")
        End If
        If cmddeletesupplier.Checked = False Then
            sql = sql + deletequery("Delete Supplier")
        End If
        If cmdupdatesupplier.Checked = True Then
            sql = sql + genereatequery("Update Supplier")
        End If
        If cmdupdatesupplier.Checked = False Then
            sql = sql + deletequery("Update Supplier")
        End If
        If cmdviewrecords.Checked = True Then
            sql = sql + genereatequery("View Records")
        End If
        If cmdviewrecords.Checked = False Then
            sql = sql + deletequery("View Records")
        End If
        richtexxt.Text = sql
        Systemusers_mysqlcon.insertrolepermission(sql)
    End Sub

  
    Private Sub cmdaddroles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdaddroles.Click
        Panel4.Visible = True
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Panel4.Visible = False
    End Sub

    Private Sub cmadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmadd.Click
        If txtroledes.Text = "" Then
            MsgBox("Please input Description")
        Else
            Systemusers_mysqlcon.insertnewroles(txtroledes.Text)
            Systemusers_mysqlcon.viewroles()
            Panel4.Visible = False
        End If
    End Sub
    Private Sub destrappings()
        Dim des As String

        des = txtroledes.Text
        If txtroledes.Text = " " Then
            txtroledes.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istexts(txtroledes.Text) = False Then

            txtroledes.Text = Mid(txtroledes.Text, 1, Len(txtroledes.Text) - 1)
            txtroledes.SelectionStart = txtroledes.Text.Length + 1
        ElseIf (des.Contains("  ")) Then
            'prevent double space sa pag tytype
            des = des.Replace("  ", " ")
            txtroledes.Text = des
            txtroledes.SelectionStart = txtroledes.Text.Length + 1
        End If

    End Sub
    Private Function istexts(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[a-zA-Z ]*$")
    End Function

    Private Sub txtroledes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtroledes.TextChanged
        destrappings()
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim des As String = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
        Dim tanong As String = MessageBox.Show("Are you sure you want to delete " & des & "?", "System Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If tanong = DialogResult.Yes Then
            Systemusers_mysqlcon.deleteroles(des)
            Systemusers_mysqlcon.viewroles()
            Panel4.Visible = False
        End If
    End Sub
End Class