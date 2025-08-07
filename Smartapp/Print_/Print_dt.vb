

Partial Public Class Print_dt
    Partial Public Class TBL_Balance_Sheet2DataTable
        Private Sub TBL_Balance_Sheet2DataTable_TBL_Balance_Sheet2RowChanging(sender As Object, e As TBL_Balance_Sheet2RowChangeEvent) Handles Me.TBL_Balance_Sheet2RowChanging

        End Sub

    End Class

    Partial Public Class TBL_Balance_Sheet1DataTable
    End Class
    Partial Public Class TBL_Balance_Sheet1DataTable

    End Class

    Partial Public Class TBL_MonthlyDataTable
        Private Sub TBL_MonthlyDataTable_TBL_MonthlyRowChanging(sender As Object, e As TBL_MonthlyRowChangeEvent) Handles Me.TBL_MonthlyRowChanging

        End Sub

        Private Sub TBL_MonthlyDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DR_AmountColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Public Class TBL_DayBookDataTable
        Private Sub TBL_DayBookDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ParticularsColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Public Class TBL_ivc_gstDataTable
        Private Sub TBL_ivc_gstDataTable_TBL_ivc_gstRowChanging(sender As Object, e As TBL_ivc_gstRowChangeEvent) Handles Me.TBL_ivc_gstRowChanging

        End Sub

        Private Sub TBL_ivc_gstDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.CGSTColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Public Class TBL_ivc_item_detailsDataTable
        Private Sub TBL_ivc_item_detailsDataTable_TBL_ivc_item_detailsRowChanging(sender As Object, e As TBL_ivc_item_detailsRowChangeEvent) Handles Me.TBL_ivc_item_detailsRowChanging

        End Sub
    End Class

    Partial Public Class TBL_ivcDataTable
        Private Sub TBL_ivcDataTable_TBL_ivcRowChanging(sender As Object, e As TBL_ivcRowChangeEvent) Handles Me.TBL_ivcRowChanging

        End Sub

        Private Sub TBL_ivcDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.BarcodeColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
