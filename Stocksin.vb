Public Class Stocksin
    Dim Productinventory As Productinventory = New Productinventory(MainForm.cs)
    Dim SupplierDetails As SupplierDetails = New SupplierDetails(MainForm.cs)


    Private Sub Stocksin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtid.Text = products.DataGridView2(0, products.DataGridView2.CurrentRow.Index).Value.ToString
        txtdescription.Text = products.DataGridView2(1, products.DataGridView2.CurrentRow.Index).Value.ToString

        Productinventory.viewstocksin()
    End Sub

    Private Sub dtpstart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpstart.ValueChanged
        Productinventory.filterstocksin()
    End Sub

    Private Sub dtpend_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpend.ValueChanged
        Productinventory.filterstocksin()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Productinventory.deletestocksin()
        Productinventory.viewstocksin()
    End Sub

    Private Sub cmbsupplier_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbsupplier.MouseClick
        cmbsupplier.Items.Clear()
        SupplierDetails.viewsupplierdescription()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim cost As Decimal
        Dim quantity As Integer
        Dim descrip As String
        Dim pid As Integer
        Dim datee As Date
   
        If cmbsupplier.Text = "" Then
            MsgBox("Please input Supplier")
        ElseIf txtcostprice.Text = "" Then
            MsgBox("Please input Cost Price")
        ElseIf txtquantity.Text = "" Then
            MsgBox("Please input Quantity")
        Else
            Try
                pid = txtid.Text
                cost = CDec(txtcostprice.Text)
                quantity = CInt(txtquantity.Text)
                descrip = cmbsupplier.Text
                datee = dtpstock.Text
                Productinventory.insertstocksin(pid, cost, quantity, descrip, datee)
                Productinventory.viewstocksin()
                Productinventory.viewproducts()
                Productinventory.lagaylahatngproduct()
                MsgBox("Successfully Inserted")
                txtcostprice.Clear()
                txtquantity.Clear()
            Catch ex As Exception
                MsgBox("Invalid Input of Price")
                txtcostprice.Clear()
                txtcostprice.Focus()
            End Try
        End If
       

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Productinventory.generatestocksinreport()
            viewreport()
        Catch ex As Exception
            MsgBox("No Data")
        End Try
     
    End Sub

    Private Sub txtcostprice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcostprice.TextChanged
        pricetrappings()
    End Sub

    Private Sub txtquantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.TextChanged
        quantitytrappings()
    End Sub

    Private Sub pricetrappings()
        Dim dec As String
        dec = txtcostprice.Text
        If isdec(txtcostprice.Text) = False Then
            txtcostprice.Text = Mid(txtcostprice.Text, 1, Len(txtcostprice.Text) - 1)
            txtcostprice.SelectionStart = txtcostprice.Text.Length + 1
        End If
    End Sub
    Private Sub quantitytrappings()
        Dim num As String
        num = txtquantity.Text
        If isnum(txtquantity.Text) = False Then
            txtquantity.Text = Mid(txtquantity.Text, 1, Len(txtquantity.Text) - 1)
            txtquantity.SelectionStart = txtquantity.Text.Length + 1
        End If
    End Sub

    Private Function isnum(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9]*$")
    End Function


    Private Function isdec(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[.0-9]*$")
    End Function
End Class