Public Class Categories
    Dim Productinventory As Productinventory = New Productinventory(MainForm.cs)
    Dim category As String
    Dim id As Integer

    Private Sub categories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Productinventory.viewcategory()
    End Sub


    Private Sub txtcategoryadd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        trappings()
    End Sub

    Sub trappings()
        Dim str As String
        str = txtcategory.Text
        If txtcategory.Text = " " Then
            txtcategory.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istexts(txtcategory.Text) = False Then

            txtcategory.Text = Mid(txtcategory.Text, 1, Len(txtcategory.Text) - 1)
            txtcategory.SelectionStart = txtcategory.Text.Length + 1
        ElseIf (str.Contains("  ")) Then
            'prevent double space sa pag tytype
            str = str.Replace("  ", " ")
            txtcategory.Text = str
            txtcategory.SelectionStart = txtcategory.Text.Length + 1
        End If
    End Sub

    Private Function istexts(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[a-zA-Z ]*$")
    End Function



    Private Sub cmdshowadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowadd.Click
        If txtcategory.Text.Trim = "" Then
            MsgBox("Please input category")
            txtcategory.Focus()
        Else
            category = txtcategory.Text
            txtid.Clear()
            txtcategory.Clear()
            Productinventory.addcategory(category)
            Productinventory.viewcategory()
        End If
    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        Try
            txtid.Text = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            txtcategory.Text = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
        Catch ex As Exception
            MsgBox("No Information/s on Datagrid")
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            id = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            Productinventory.deletecategory(id)
            txtid.Clear()
            txtcategory.Clear()
            Productinventory.viewcategory()
            Productinventory.viewproducts()
        Catch ex As Exception
            MsgBox("No Information/s on Datagrid")
        End Try
     
    End Sub


    Private Sub txtcategory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcategory.TextChanged
        trappings()
    End Sub
End Class