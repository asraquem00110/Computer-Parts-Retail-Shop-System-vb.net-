Public Class users
    Dim Systemusers_mysqlcon As Systemusers_mysqlcon = New Systemusers_mysqlcon(MainForm.cs)


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
    Sub clearinputs()
        txtid.Clear()
        txtfirstname.Clear()
        txtlastname.Clear()
        txtusername.Clear()
        txtpassword.Clear()
        cmbroles.Text = ""
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        If txtid.TextLength > 0 Then
            Dim tanong As String = MessageBox.Show("Are you sure you want to delete " & txtusername.Text & "?", "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tanong = DialogResult.Yes Then
                Systemusers_mysqlcon.deleteuser(txtid.Text)
                Systemusers_mysqlcon.viewusers()
                clearinputs()
            End If
        End If
    End Sub

    Private Sub cmdupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupdate.Click
        If txtid.TextLength > 0 Then
            Dim tanong As String = MessageBox.Show("Are you sure you want to update " & txtusername.Text & "?", "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tanong = DialogResult.Yes Then
                Systemusers_mysqlcon.updateuser(txtlastname.Text, txtfirstname.Text, txtusername.Text, txtpassword.Text, cmbroles.Text, txtid.Text)
                Systemusers_mysqlcon.viewusers()
                clearinputs()
            End If
        End If
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        If txtlastname.Text.Trim = "" Then
            MsgBox("Please input User Last Name")
            txtlastname.Focus()
        ElseIf txtfirstname.Text.Trim = "" Then
            MsgBox("Please input User First Name")
            txtfirstname.Focus()
        ElseIf txtusername.Text.Trim = "" Then
            MsgBox("Please input Username")
            txtusername.Focus()
        ElseIf txtpassword.Text.Trim = "" Then
            MsgBox("Password is required")
            txtpassword.Focus()
        ElseIf cmbroles.Text = "" Then
            MsgBox("Please Select User Role")
        ElseIf Systemusers_mysqlcon.checkduplicates(txtlastname.Text, txtfirstname.Text, txtusername.Text) = True Then
            MsgBox("Already Existed")
        Else
            With Systemusers_mysqlcon
                .kuhauserfname = txtfirstname.Text
                .kuhauserlname = txtlastname.Text
                .kuhausername = txtusername.Text
                .kuhauserpassword = txtpassword.Text
                .kuhauserrole = cmbroles.Text
                .adduser()
                .viewusers()
            End With
            clearinputs()
        End If
    End Sub

    Private Sub cmbroles_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbroles.MouseClick
        cmbroles.Items.Clear()
        Systemusers_mysqlcon.kuharoles()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub

    Private Sub txtlastname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlastname.TextChanged
        lnametrappings()
    End Sub

    Private Sub txtfirstname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfirstname.TextChanged
        fnametrappings()
    End Sub

    Private Sub txtusername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtusername.TextChanged
        Dim username As String
        username = txtusername.Text
        If txtusername.Text = " " Then
            txtusername.Text = ""
        ElseIf (username.Contains("  ")) Then
            username = username.Replace("  ", " ")
            txtusername.Text = username
            txtusername.SelectionStart = txtusername.Text.Length + 1
        End If
    End Sub

    Private Sub lnametrappings()
        Dim lname As String

        lname = txtlastname.Text
        If txtlastname.Text = " " Then
            txtlastname.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istexts(txtlastname.Text) = False Then

            txtlastname.Text = Mid(txtlastname.Text, 1, Len(txtlastname.Text) - 1)
            txtlastname.SelectionStart = txtlastname.Text.Length + 1
        ElseIf (lname.Contains("  ")) Then
            'prevent double space sa pag tytype
            lname = lname.Replace("  ", " ")
            txtlastname.Text = lname
            txtlastname.SelectionStart = txtlastname.Text.Length + 1
        End If

    End Sub

    Private Sub fnametrappings()
        Dim fname As String

        fname = txtfirstname.Text
        If txtfirstname.Text = " " Then
            txtfirstname.Text = ""

            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istexts(txtfirstname.Text) = False Then
            txtfirstname.Text = Mid(txtfirstname.Text, 1, Len(txtfirstname.Text) - 1)
            txtfirstname.SelectionStart = txtfirstname.Text.Length + 1
           
        ElseIf (fname.Contains("  ")) Then
            'prevent double space sa pag tytype
            fname = fname.Replace("  ", " ")
            txtfirstname.Text = fname
            txtfirstname.SelectionStart = txtfirstname.Text.Length + 1
           
        End If

    End Sub
  


    Private Function istexts(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[-'a-zA-Z ]*$")
    End Function

  

    Private Sub txtpassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpassword.TextChanged
        Dim password As String
        password = txtpassword.Text
        If txtpassword.Text = " " Then
            txtpassword.Text = ""
        ElseIf (password.Contains("  ")) Then
            password = password.Replace("  ", " ")
            txtpassword.Text = password
            txtpassword.SelectionStart = txtpassword.Text.Length + 1
        End If
    End Sub

    Private Sub cmdroles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdroles.Click
        pindotroles()
    End Sub

End Class