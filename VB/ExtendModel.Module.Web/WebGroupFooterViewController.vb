Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Data
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports DevExpress.Web.ASPxGridView

Namespace ExtendModel.Module.Web
    Public Class WebGroupFooterViewController
        Inherits ViewController(Of ListView)
        Protected Overrides Sub OnViewControlsCreated()
            MyBase.OnViewControlsCreated()
            Dim modelListView As IModelListViewExtender = TryCast(View.Model, IModelListViewExtender)
            If modelListView IsNot Nothing AndAlso modelListView.IsGroupFooterVisible Then
                Dim gridListEditor As ASPxGridListEditor = TryCast(View.Editor, ASPxGridListEditor)
                If gridListEditor IsNot Nothing Then
                    Dim gridView As ASPxGridView = gridListEditor.Grid
                    gridView.Settings.ShowGroupFooter = GridViewGroupFooterMode.VisibleAlways
                    For Each modelColumn As IModelColumn In View.Model.Columns
                        Dim modelColumnExtender As IModelColumnExtender = TryCast(modelColumn, IModelColumnExtender)
                        If modelColumnExtender IsNot Nothing AndAlso modelColumnExtender.GroupFooterSummaryType <> SummaryItemType.None Then
                            Dim fieldName As String = modelColumn.ModelMember.MemberInfo.BindingName
                            Dim summaryItem As ASPxSummaryItem = Nothing
                            For Each currentItem As ASPxSummaryItem In gridView.GroupSummary
                                If currentItem.FieldName = fieldName Then
                                    currentItem.ShowInGroupFooterColumn = modelColumn.Caption
                                    summaryItem = currentItem
                                    Exit For
                                End If
                            Next currentItem
                            If summaryItem Is Nothing Then
                                summaryItem = New ASPxSummaryItem(fieldName, modelColumnExtender.GroupFooterSummaryType)
                                summaryItem.ShowInGroupFooterColumn = modelColumn.Caption
                                gridView.GroupSummary.Add(summaryItem)
                            End If
                        End If
                    Next modelColumn
                End If
            End If
        End Sub
    End Class
End Namespace
