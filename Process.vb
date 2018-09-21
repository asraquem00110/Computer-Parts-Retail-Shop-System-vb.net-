Public Class Process
    Dim Transactions As Transactions = New Transactions(MainForm.cs)

    Private Sub Process_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub



    Private Sub cmdprocess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprocess.Click
        Transactions.maketransaction(POS.txtcustomerid.Text, MainForm.lblid.Text)
        POS.DataGridView2.Rows.Clear()
        txtchangeamount.Text = ""
        POS.txtcost.Text = "0.00"
        POS.txtdiscountamount.Text = "0.00"
        POS.txttotalamount.Text = "0.00"
        viewreport()
        Transactions.generatereceipt()
        POS.txtcustomerid.Text = 0
        Me.Close()

    End Sub

    Private Sub cmdcalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcalculate.Click
        Try
            txtchangeamount.Text = CDec(txtcashpayment.Text) - CDec(txttotalamount.Text)
            If txtchangeamount.Text >= 0 Then
                cmdprocess.Visible = True
                cmdcalculate.Visible = False
            Else
                txtcashpayment.Text = ""
                cmdprocess.Visible = False
                cmdcalculate.Visible = True
            End If
        Catch ex As Exception
            MsgBox("Invalid Input")
        End Try

    End Sub

 
End Class