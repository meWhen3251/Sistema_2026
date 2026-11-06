Public Class Form3

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 AndAlso (e.ColumnIndex = 1 OrElse e.ColumnIndex = 2) Then
            Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            Dim cantidad As Integer = 0
            Dim preciounitario As Decimal = 0

            Dim esCantidadValida As Boolean = Integer.TryParse(Convert.ToString(fila.Cells("colcantidad").Value), cantidad)
            Dim esPrecioUnitario As Boolean = Decimal.TryParse(Convert.ToString(fila.Cells("colPrecioUnitario").Value), preciounitario)

            If esCantidadValida AndAlso esPrecioUnitario Then
                fila.Cells("colPrecioTotal").Value = cantidad * preciounitario
            Else
                fila.Cells("colPrecioTotal").Value = DBNull.Value

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class