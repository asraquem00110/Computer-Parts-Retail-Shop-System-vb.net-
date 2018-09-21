Public Class SystemUsers
    Dim Systemusers_mysqlcon As Systemusers_mysqlcon = New Systemusers_mysqlcon(MainForm.cs)
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub


    Private Sub SystemUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Systemusers_mysqlcon.viewusers()
    End Sub


    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        Try
            txtid.Text = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            txtlastname.Text = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            txtfirstname.Text = DataGridView2(2, DataGridView2.CurrentRow.Index).Value.ToString
            txtusername.Text = DataGridView2(3, DataGridView2.CurrentRow.Index).Value.ToString
            txtpassword.Text = DataGridView2(4, DataGridView2.CurrentRow.Index).Value.ToString
            cmbroles.Text = DataGridView2(5, DataGridView2.CurrentRow.Index).Value.ToString
        Catch ex As Exception
            MsgBox("No Data in Datagrid")
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        If txtid.TextLength > 0 Then

        End If
    End Sub

    Private Sub cmdupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupdate.Click
        If txtid.TextLength > 0 Then

        End If
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Systemusers_mysqlcon.adduser(txtlastname.Text, txtfirstname.Text, txtusername.Text, txtpassword.Text, cmbroles.Text)
        txtid.Clear()
        txtfirstname.Clear()
        txtlastname.Clear()
        txtusername.Clear()
        txtpassword.Clear()
        cmbroles.Text = ""
    End Sub

    Private Sub cmbroles_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbroles.MouseClick
        cmbroles.Items.Clear()
        Systemusers_mysqlcon.kuharoles()
    End Sub

End Class