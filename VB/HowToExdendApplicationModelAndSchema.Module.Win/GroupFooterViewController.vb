Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Public Class GroupFooterViewController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

	End Sub

    Private Sub GroupFooterViewController_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        AddHandler View.ControlsCreated, AddressOf View_ControlsCreated
        AddHandler View.InfoSynchronized, AddressOf View_InfoSynchronized
    End Sub
    Private Sub View_InfoSynchronized(ByVal sender As Object, ByVal e As EventArgs)
        Dim lv As ListView = TryCast(View, ListView)
        If lv IsNot Nothing Then
            Dim modelListView As IModelListViewExtender = TryCast(lv.Model, IModelListViewExtender)
            If modelListView IsNot Nothing AndAlso modelListView.IsGroupFooterVisible Then
                'Access the current List View's Grid List Editor
                'if the IsGroupFooterVisible attribute is set to true for the current List View
                Dim le As GridListEditor = TryCast(lv.Editor, GridListEditor)
                If le IsNot Nothing Then
                    'Access the Grid List Editor's current Grid View
                    Dim gridView As GridView = le.GridView
                    For i As Integer = 0 To gridView.GroupSummary.Count - 1
                        Dim columns As IModelList(Of IModelColumn) = lv.Model.Columns
                        Dim modelColumn As IModelColumnExtender = TryCast(columns(gridView.GroupSummary(i).FieldName), IModelColumnExtender)
                        If modelColumn IsNot Nothing Then
                            'Set the currently set summary type for the GroupFooterSummaryType attribute of the corresponding column
                            modelColumn.GroupFooterSummaryType = gridView.GroupSummary(i).SummaryType
                        End If
                    Next i
                End If
            End If
        End If
    End Sub
    Private Sub View_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
        Dim lv As ListView = TryCast(View, ListView)
        If lv IsNot Nothing Then
            Dim modelListView As IModelListViewExtender = TryCast(lv.Model, IModelListViewExtender)
            If modelListView IsNot Nothing AndAlso modelListView.IsGroupFooterVisible Then
                'Access the current List View's Grid List Editor
                'if the IsGroupFooterVisible attribute is set to true for the current List View
                Dim le As GridListEditor = TryCast(lv.Editor, GridListEditor)
                If le IsNot Nothing Then
                    'Access the Grid List Editor's current Grid View
                    Dim gridView As GridView = le.GridView
                    'Set the groop footer visible
                    gridView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
                    For Each modelColumn As IModelColumn In lv.Model.Columns
                        Dim modelColumnExtender As IModelColumnExtender = TryCast(modelColumn, IModelColumnExtender)
                        If modelColumnExtender IsNot Nothing Then
                            Dim gridColumn As GridColumn = gridView.Columns(modelColumn.ModelMember.MemberInfo.BindingName)
                            gridView.GroupSummary.Add(modelColumnExtender.GroupFooterSummaryType, modelColumn.Id, gridColumn)
                        End If
                    Next modelColumn
                End If
            End If
        End If
    End Sub
End Class
