Public Class Suppliers
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub

    Dim id As Integer
    Dim desc As String
    Dim address As String
    Dim phone As String

    Private Sub txtdes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdes.TextChanged
        destrappings()
    End Sub

    Private Sub txtphone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtphone.TextChanged
        phonetrappings()
    End Sub

    Private Sub txtaddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaddress.TextChanged
        addresstrappings()
    End Sub

    Private Sub destrappings()
        Dim des As String

        des = txtdes.Text
        If txtdes.Text = " " Then
            txtdes.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istext(txtdes.Text) = False Then

            txtdes.Text = Mid(txtdes.Text, 1, Len(txtdes.Text) - 1)
            txtdes.SelectionStart = txtdes.Text.Length + 1
        ElseIf (des.Contains("  ")) Then
            'prevent double space sa pag tytype
            des = des.Replace("  ", " ")
            txtdes.Text = des
            txtdes.SelectionStart = txtdes.Text.Length + 1
        End If

    End Sub
    Private Sub addresstrappings()
        Dim address As String

        address = txtaddress.Text
        If txtaddress.Text = " " Then
            txtaddress.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istext(txtaddress.Text) = False Then

            txtaddress.Text = Mid(txtaddress.Text, 1, Len(txtaddress.Text) - 1)
            txtaddress.SelectionStart = txtaddress.Text.Length + 1
        ElseIf (address.Contains("  ")) Then
            'prevent double space sa pag tytype
            address = address.Replace("  ", " ")
            txtaddress.Text = address
            txtaddress.SelectionStart = txtaddress.Text.Length + 1
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

    Private Function istext(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[- #,.;'a-zA-Z0-9]*$")
    End Function


    Private Function isnum(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9]*$")
    End Function

    Dim SupplierDetails As SupplierDetails = New SupplierDetails(MainForm.cs)
    Dim Productinventory As Productinventory = New Productinventory(MainForm.cs)
    Private Sub Suppliers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SupplierDetails.viewsuppliers()
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        If txtdes.Text.Trim = "" Then
            MsgBox("Please input Supplier Name")
            txtdes.Focus()
        ElseIf SupplierDetails.checkduplicates(txtdes.Text) = True Then
            MsgBox("Already Existed")
        Else
            Me.desc = txtdes.Text
            Me.address = txtaddress.Text
            Me.phone = txtphone.Text
            SupplierDetails.addsupplier(desc, address, phone)
            clearinputs()
            SupplierDetails.viewsuppliers()
        End If
    End Sub

    Sub clearinputs()
        txtid.Clear()
        txtdes.Clear()
        txtphone.Clear()
        txtaddress.Clear()
    End Sub


    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            Dim DES As String = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            Dim tanong = MessageBox.Show("Are you sure you want to delete " & DES & "", "System Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tanong = DialogResult.Yes Then
                Me.id = CInt(txtid.Text)
                SupplierDetails.deletesuppliers(id)
                clearinputs()
                Productinventory.viewstocksin()
            End If
        Catch ex As Exception
            MsgBox("No Information/s on datagrid")
        End Try


        SupplierDetails.viewsuppliers()
    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        If DataGridView2.RowCount > 0 Then
            txtid.Text = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            txtdes.Text = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            txtaddress.Text = DataGridView2(2, DataGridView2.CurrentRow.Index).Value.ToString
            txtphone.Text = DataGridView2(3, DataGridView2.CurrentRow.Index).Value.ToString
        Else
            MsgBox("No Information/s on datagrid")
        End If
    End Sub

    Private Sub cmdupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupdate.Click
        Try
                Dim DES As String = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            Dim tanong = MessageBox.Show("Are you sure you want to update " & DES & "", "System Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If tanong = DialogResult.Yes Then
                    Me.id = CInt(txtid.Text)
                Me.desc = txtdes.Text
                    Me.address = txtaddress.Text
                    Me.phone = txtphone.Text
                SupplierDetails.updatesuppliers(id, desc, address, phone)
                clearinputs()
                SupplierDetails.viewsuppliers()
            End If
        Catch ex As Exception
            MsgBox("No Information/s on datagrid")
            End Try

    End Sub

 

End Class