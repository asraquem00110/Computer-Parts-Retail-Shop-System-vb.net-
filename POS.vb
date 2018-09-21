Public Class POS

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub

    Private Sub cmdcustomersearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcustomersearch.Click
        Customer_Details.Hide()
        Customer_Details.MdiParent = MainForm
        Customer_Details.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Customer_Details.Location = New Point(x + 230, y + 0)
    End Sub

    Private Sub cmdviewproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdviewproduct.Click
        products.Hide()
        products.MdiParent = MainForm
        products.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        products.Location = New Point(x + 230, y + 0)
        With products
            .cmdshowadd.Visible = False
            .cmdupdate.Visible = False
            .cmddelete.Visible = False
            .cmdok.Visible = True
            .MenuStrip1.Visible = False
        End With
    End Sub




    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        For Each row As DataGridViewRow In DataGridView2.SelectedRows
            DataGridView2.Rows.Remove(row)
        Next
    End Sub

    Private Sub cmdremoveall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremoveall.Click
        DataGridView2.Rows.Clear()
        txtcost.Text = "0.00"
        txtdiscountamount.Text = "0.00"
        txttotalamount.Text = "0.00"
    End Sub



    Private Sub DataGridView2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        If DataGridView2.Rows.Count > 0 Then
            Try
                Dim Quantity As Integer = CInt(DataGridView2.Rows(e.RowIndex).Cells(3).Value)
                Dim UnitPrice As Decimal = (DataGridView2.Rows(e.RowIndex).Cells(4).Value)
                Dim discount As Decimal = (DataGridView2.Rows(e.RowIndex).Cells(5).Value)
                Dim Total As Decimal = (Quantity * UnitPrice) - discount
                DataGridView2.Rows(e.RowIndex).Cells(6).Value = Total
                updatedatagridview()
            Catch ex As Exception
                MsgBox("Invalid Input")
            End Try


        End If

    End Sub




    Public Sub updatedatagridview()
        Dim x As Integer
        Dim total As Decimal = 0
        Dim discountamount As Decimal = 0
        Dim costamount As Decimal = 0
        Dim discounts As Decimal = 0
        For x = 0 To DataGridView2.Rows.Count - 1
            costamount = costamount + (DataGridView2.Rows(x).Cells(3).Value * DataGridView2.Rows(x).Cells(4).Value)
        Next
        If costamount > 30000 And costamount <= 49999 Then
            Dim Systemusers_mysqlcon = New Systemusers_mysqlcon(MainForm.cs)
            discounts = Systemusers_mysqlcon.Kuhadiscount()

        ElseIf costamount >= 50000 And costamount <= 89999 Then
            Dim SupplierDetails As SupplierDetails = New SupplierDetails(MainForm.cs)
            discounts = SupplierDetails.Kuhadiscount()

        ElseIf costamount >= 90000 And costamount <= 99999 Then
            Dim Productinventory As Productinventory = New Productinventory(MainForm.cs)
            discounts = Productinventory.Kuhadiscount()

        ElseIf costamount > 100000 Then
            Dim Customers As Customers = New Customers(MainForm.cs)
            discounts = Customers.Kuhadiscount()

        Else
            discounts = 0

        End If

        For x = 0 To DataGridView2.Rows.Count - 1

            Dim discount_price As Decimal = Format(discounts * (DataGridView2.Rows(x).Cells(4).Value * DataGridView2.Rows(x).Cells(3).Value), "0.00")
            DataGridView2.Rows(x).Cells(5).Value = discount_price
        Next

        For i = 0 To DataGridView2.Rows.Count - 1
            total = total + DataGridView2.Rows(i).Cells(6).Value
        Next

        For x = 0 To DataGridView2.Rows.Count - 1
            discountamount = discountamount + DataGridView2.Rows(x).Cells(5).Value
        Next

        txtcost.Text = Format(costamount, "0.00")
        txtdiscountamount.Text = Format(discountamount, "0.00")
        txttotalamount.Text = Format(total, "0.00")
    End Sub

    Private Sub cmdtender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtender.Click
        Process.Show()
        Process.txttotalamount.Clear()
        Process.txttotalamount.Text = CDec(txttotalamount.Text)
    End Sub

    Private Sub txtcustomerid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcustomerid.TextChanged
        If txtcustomerid.Text > 0 Then
            cmdviewproduct.Enabled = True
        Else
            cmdviewproduct.Enabled = False
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        txtcustomerid.Text = 0
    End Sub

End Class