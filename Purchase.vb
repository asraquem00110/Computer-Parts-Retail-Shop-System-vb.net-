Public Class Purchase
    Dim Productinventory As Productinventory = New Productinventory(MainForm.cs)
    Dim Transactions As Transactions = New Transactions(MainForm.cs)
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub cmdcustomersearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcustomersearch.Click
        pindotcustomer()
    End Sub

    Private Sub Purchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Productinventory.lagaylahatngproductpurchase()
        Productinventory.viewproducts()

    End Sub


    Private Sub txtproductsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtproductsearch.TextChanged
        Productinventory.searchproductpurchase(txtproductsearch.Text)
    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        Try
            txtid.Text = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            txtdescription.Text = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            txtprice.Text = DataGridView2(2, DataGridView2.CurrentRow.Index).Value.ToString
            txtcategory.Text = DataGridView2(5, DataGridView2.CurrentRow.Index).Value.ToString
            txtstocks.Text = DataGridView2(3, DataGridView2.CurrentRow.Index).Value.ToString
        Catch ex As Exception
            MsgBox("No Selected Item")
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
    
        If txtcustomerid.Text = 0 Then
            MsgBox("Choose Customer First")
        ElseIf txtid.Text = "" Then
            MsgBox("Select Product First")
        ElseIf txtquantity.Text = "" Then
            MsgBox("Plese input quantity")
        ElseIf (CInt(txtquantity.Text) > CInt(txtstocks.Text)) Then
            MsgBox("Insufficient Stocks for Item " & DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString & "")
        Else
            Transactions.inserttemporder(txtquantity.Text)
            Transactions.selecttemporder()
            Transactions.computetotal()
        End If
    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        Try
            Transactions.deletefromtemporder(DataGridView1(0, DataGridView1.CurrentRow.Index).Value)
            Transactions.computetotal()
            Transactions.selecttemporder()
        Catch ex As Exception
            MsgBox("Select First Item you want to remove")
        End Try
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

    Private Sub txtquantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.TextChanged
        quantitytrappings()
    End Sub


    Private Sub cmdremoveall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremoveall.Click
        Transactions.removeallfromtemporder()
        DataGridView1.DataSource = Nothing
        txttotalamount.Text = "0.00"
    End Sub

    Private Sub cmdpurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpurchase.Click
        Panel3.Visible = True
        txttotal.Text = txttotalamount.Text
    End Sub


    Public Function generatediscount()
        Dim discount As Decimal
        If cmbdiscount.Text = "No Discount" Then
            discount = 0
        ElseIf cmbdiscount.Text = "5%" Then
            Dim Systemusers_mysqlcon As Systemusers_mysqlcon = New Systemusers_mysqlcon(MainForm.cs)
            discount = Systemusers_mysqlcon.Kuhadiscount
        ElseIf cmbdiscount.Text = "10%" Then
            Dim SupplierDetails As SupplierDetails = New SupplierDetails(MainForm.cs)
            discount = SupplierDetails.Kuhadiscount
        ElseIf cmbdiscount.Text = "15%" Then
            Dim Productinventory As Productinventory = New Productinventory(MainForm.cs)
            discount = Productinventory.Kuhadiscount
        ElseIf cmbdiscount.Text = "20%" Then
            Dim Customers As Customers = New Customers(MainForm.cs)
            discount = Customers.Kuhadiscount
        Else
            discount = 0
        End If
        Return discount
    End Function

   

 
    Private Sub cmbdiscount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdiscount.SelectedIndexChanged
        Dim discountamount As Decimal = generatediscount()
        Transactions.computetotal()
        txttotalamount.Text = txttotalamount.Text - (txttotalamount.Text * discountamount)
    End Sub

    Private Sub cmdcalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcalculate.Click
        Try
            txtchangeamount.Text = CDec(txtcashpayment.Text) - CDec(txttotal.Text)
            If txtchangeamount.Text >= 0 Then
                cmdprocess.Visible = True
                cmdcalculate.Visible = False
            Else
                txtcashpayment.Text = ""
                MsgBox("Insufficient Payment , Please Input again")
                cmdprocess.Visible = False
                cmdcalculate.Visible = True
            End If
        Catch ex As Exception
            MsgBox("Invalid Input")
        End Try
    End Sub

    Private Sub cmdprocess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprocess.Click
        Transactions.maketransaction(txtcustomerid.Text, MainForm.lblid.Text)
        Transactions.generatereceipt()
        viewreport()
        DataGridView1.DataSource = Nothing
        txtcustomerid.Text = 0
        txttotalamount.Text = "0.00"
        txtid.Clear()
        txtdescription.Clear()
        txtquantity.Clear()
        txtprice.Clear()
        txtstocks.Clear()
        txtcategory.Clear()
        txtcashpayment.Clear()
        txtchangeamount.Clear()
        txttotal.Clear()
        Panel3.Visible = False
        Productinventory.viewproducts()
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Panel3.Visible = False
    End Sub

    Private Sub txtcashpayment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcashpayment.TextChanged
        pricetrappings()
    End Sub
    Private Sub pricetrappings()
        Dim dec As String
        dec = txtcashpayment.Text
        If isdec(txtcashpayment.Text) = False Then
            txtcashpayment.Text = Mid(txtcashpayment.Text, 1, Len(txtcashpayment.Text) - 1)
            txtcashpayment.SelectionStart = txtcashpayment.Text.Length + 1
        End If
    End Sub

    Private Function isdec(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[.0-9]*$")
    End Function

 

    Private Sub txttotalamount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttotalamount.TextChanged
        If txttotalamount.Text = 0 Or txttotalamount.Text = "0.00" Then
            cmdpurchase.Enabled = False
            cmbdiscount.Enabled = False
        Else
            cmdpurchase.Enabled = True
            cmbdiscount.Enabled = True
        End If
    End Sub


End Class