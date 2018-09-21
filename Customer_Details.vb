Public Class Customer_Details
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub

    Dim customers As Customers = New Customers(MainForm.cs)
    Dim fname As String
    Dim lname As String
    Dim phoneno As String
    Dim address As String
    Dim cid As Integer

    Private Sub txtlname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlname.TextChanged
        lnametrappings()
    End Sub
    Private Sub txtfname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfname.TextChanged
        fnametrappings()
    End Sub

    Private Sub txtphone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtphone.TextChanged
        phonetrappings()
    End Sub
    Private Sub txtaddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaddress.TextChanged
        addresstrappings()
    End Sub
 

    Private Sub lnametrappings()
        Dim lname As String

        lname = txtlname.Text
        If txtlname.Text = " " Then
            txtlname.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istexts(txtlname.Text) = False Then

            txtlname.Text = Mid(txtlname.Text, 1, Len(txtlname.Text) - 1)
            txtlname.SelectionStart = txtlname.Text.Length + 1
        ElseIf (lname.Contains("  ")) Then
            'prevent double space sa pag tytype
            lname = lname.Replace("  ", " ")
            txtlname.Text = lname
            txtlname.SelectionStart = txtlname.Text.Length + 1
        End If

    End Sub
    Private Sub addresstrappings()
        Dim address As String

        address = txtaddress.Text
        If txtaddress.Text = " " Then
            txtaddress.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf isaddress(txtaddress.Text) = False Then

            txtaddress.Text = Mid(txtaddress.Text, 1, Len(txtaddress.Text) - 1)
            txtaddress.SelectionStart = txtaddress.Text.Length + 1
        ElseIf (address.Contains("  ")) Then
            'prevent double space sa pag tytype
            address = address.Replace("  ", " ")
            txtaddress.Text = address
            txtaddress.SelectionStart = txtaddress.Text.Length + 1
        End If

    End Sub
    Private Sub fnametrappings()
        Dim fname As String

        fname = txtfname.Text
        If txtfname.Text = " " Then
            txtfname.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istexts(txtfname.Text) = False Then
            txtfname.Text = Mid(txtfname.Text, 1, Len(txtfname.Text) - 1)
            txtfname.SelectionStart = txtfname.Text.Length + 1
        ElseIf (fname.Contains("  ")) Then
            'prevent double space sa pag tytype
            fname = fname.Replace("  ", " ")
            txtfname.Text = fname
            txtfname.SelectionStart = txtfname.Text.Length + 1
        End If

    End Sub
    Private Sub phonetrappings()
        Dim num As String
        num = txtphone.Text
        If isnum(txtphone.Text) = False Then
            txtphone.Text = Mid(txtphone.Text, 1, Len(txtphone.Text) - 1)
            txtphone.SelectionStart = txtphone.Text.Length + 1
        End If
    End Sub

    Private Function isaddress(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[- #,.;'a-zA-Z0-9]*$")
    End Function
    Private Function istexts(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[a-zA-Z ]*$")
    End Function

    Private Function isnum(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9]*$")
    End Function


    Private Sub Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        customers.viewcustomers()
        customers.lagaylahatngcustomer()
    End Sub


    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        kuhadetails()
    End Sub

    Sub kuhadetails()
        If DataGridView2.RowCount > 0 Then
            txtid.Text = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            txtlname.Text = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            txtfname.Text = DataGridView2(2, DataGridView2.CurrentRow.Index).Value.ToString
            txtphone.Text = DataGridView2(4, DataGridView2.CurrentRow.Index).Value.ToString
            txtaddress.Text = DataGridView2(3, DataGridView2.CurrentRow.Index).Value.ToString
        Else
            MsgBox("No Information/s on datagrid")
        End If

    End Sub




    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            Dim Ngalan As String = "" & DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString & ", " & DataGridView2(2, DataGridView2.CurrentRow.Index).Value.ToString & ""
            Me.cid = CInt(DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString)
            Dim tanong = MessageBox.Show("Are you sure you want to delete " & Ngalan & "", "System Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tanong = DialogResult.Yes Then
                customers.deletecustomer(cid)
            End If
            clearinputs()
        Catch ex As Exception
            MsgBox("No Information/s on datagrid")
        End Try

        customers.viewcustomers()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim Transactions As Transactions = New Transactions(MainForm.cs)
        Try
            Purchase.txtcustomerid.Text = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            Transactions.createtemporarytablefororders()
            Me.Hide()
        Catch ex As Exception
            MsgBox("No Information/s on datagrid")
        End Try


    End Sub

    Private Sub cmdupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupdate.Click
        Try
            Dim Ngalan As String = "" & DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString & ", " & DataGridView2(2, DataGridView2.CurrentRow.Index).Value.ToString & ""
            Me.cid = CInt(txtid.Text)
            Dim tanong = MessageBox.Show("Are you sure you want to Update " & Ngalan & "", "System Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tanong = DialogResult.Yes Then
                Me.cid = CInt(txtid.Text)
                Me.fname = txtfname.Text
                Me.lname = txtlname.Text
                Me.phoneno = txtphone.Text
                Me.address = txtaddress.Text
                customers.updatecustomer(Me.fname, Me.lname, Me.phoneno, Me.address, Me.cid)
            End If
        Catch ex As Exception
            MsgBox("No Information/s on datagrid")
        End Try
        customers.viewcustomers()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupBox1.Visible = False
    End Sub

    Private Sub cmdadd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        If txtlname.Text.Trim = "" Then
            MsgBox("Please input Last Name")
            txtlname.Focus()
        ElseIf txtfname.Text.Trim = "" Then
            MsgBox("Please input First Name")
            txtfname.Focus()
        ElseIf customers.checkduplicates(txtlname.Text, txtfname.Text, txtaddress.Text) = True Then
            MsgBox("Already Existed")
            clearinputs()
        Else
            Me.fname = txtfname.Text
            Me.lname = txtlname.Text
            Me.phoneno = txtphone.Text
            Me.address = txtaddress.Text
            customers.addcustomer(Me.fname, Me.lname, Me.phoneno, Me.address)
            customers.viewcustomers()
            clearinputs()
        End If
    End Sub

    Sub clearinputs()
        txtlname.Clear()
        txtfname.Clear()
        txtphone.Clear()
        txtaddress.Clear()
    End Sub

    Private Sub cmddetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddetails.Click
        Label1.Visible = True
        txtid.Visible = True
        cmdadd.Visible = False
        cmdupdate.Visible = True
        GroupBox1.Visible = True
        kuhadetails()
    End Sub

    Private Sub cmdshowadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowadd.Click
        cmdadd.Visible = True
        cmdupdate.Visible = False
        GroupBox1.Visible = True
        txtfname.Clear()
        txtlname.Clear()
        txtphone.Clear()
        txtaddress.Clear()
        txtid.Clear()
        txtid.Visible = False
        Label1.Visible = False
    End Sub


    Private Sub txtcustomersearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcustomersearch.TextChanged
        customers.searchcustomer(txtcustomersearch.Text)
    End Sub



End Class