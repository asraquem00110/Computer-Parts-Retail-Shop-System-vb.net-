Public Class Records
    Dim Transactions As Transactions = New Transactions(MainForm.cs)
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub

    Private Sub dtpstart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpstart.ValueChanged
        Transactions.filtertransactionsrecord()
    End Sub

    Private Sub dtpend_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpend.ValueChanged
        Transactions.filtertransactionsrecord()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim tanong = MessageBox.Show("Warning this will delete records permanently , Are you sure you want to Delete this?", "System Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If tanong = DialogResult.Yes Then
            Transactions.deletefilteredtransactionrecord()
            Transactions.viewrecordtransactions()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Transactions.generatefilteredreporttransactionrecord()
        viewreport()
    End Sub
End Class