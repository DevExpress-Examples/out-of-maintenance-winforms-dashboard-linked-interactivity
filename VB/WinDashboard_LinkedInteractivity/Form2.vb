Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.ViewerData
Imports DevExpress.DashboardWin
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq

Namespace WinDashboard_LinkedInteractivity
	Partial Public Class Form2
		Inherits DevExpress.XtraEditors.XtraForm

		Public Shadows Property ParentForm() As Form1

		Public Sub New(ByVal parentForm As Form1)
			InitializeComponent()
			Me.dashboardViewer1.LoadDashboard("Data\DashboardChild.xml")
			Me.ParentForm = parentForm
			Dim dParentControl As DashboardDesigner = Me.ParentForm.DControl
			AddHandler dParentControl.MasterFilterSet, AddressOf DControl_MasterFilterSet
			AddHandler dParentControl.MasterFilterCleared, AddressOf DControl_MasterFilterCleared
			AddHandler dParentControl.DrillDownPerformed, AddressOf DControl_DrillDownPerformed
			AddHandler dParentControl.DrillUpPerformed, AddressOf DControl_DrillUpPerformed
		End Sub

		Private Function HasDashboardItem(ByVal itemName As String) As Boolean
			Return Me.dashboardViewer1.Dashboard.Items.Select(Function(i) i.ComponentName).Contains(itemName)
		End Function

		Private Sub DControl_MasterFilterSet(ByVal sender As Object, ByVal e As MasterFilterSetEventArgs)
			If HasDashboardItem(e.DashboardItemName) Then
				Dim itemName As String = e.DashboardItemName
				If e.SelectedValues IsNot Nothing Then
					Me.dashboardViewer1.SetMasterFilter(itemName, e.SelectedValues)
				End If
				If e.SelectedRange IsNot Nothing Then
					Me.dashboardViewer1.SetRange(itemName, e.SelectedRange)
				End If
			End If
		End Sub
		Private Sub DControl_MasterFilterCleared(ByVal sender As Object, ByVal e As MasterFilterClearedEventArgs)
			If HasDashboardItem(e.DashboardItemName) Then
				Dim itemName As String = e.DashboardItemName
				If Me.dashboardViewer1.CanClearMasterFilter(itemName) Then
					Me.dashboardViewer1.ClearMasterFilter(itemName)
				End If
			End If
		End Sub
		Private Sub DControl_DrillDownPerformed(ByVal sender As Object, ByVal e As DrillActionEventArgs)
			If HasDashboardItem(e.DashboardItemName) Then
				Dim itemName As String = e.DashboardItemName
				Dim row As DashboardDataRow = e.Values(0)
				Dim value As Object = row(row.Length - 1)

				Dim tuple As IList(Of AxisPointTuple) = Me.dashboardViewer1.GetAvailableDrillDownValues(itemName)
				Dim availableValues As IEnumerable(Of Object) = tuple.Select(Function(t) t.GetAxisPoint().UniqueValue)
				If availableValues.Contains(value) Then
					Me.dashboardViewer1.PerformDrillDown(e.DashboardItemName, value)
				End If
			End If
		End Sub
		Private Sub DControl_DrillUpPerformed(ByVal sender As Object, ByVal e As DrillActionEventArgs)
			If HasDashboardItem(e.DashboardItemName) Then
				Dim itemName As String = e.DashboardItemName
				Dim level As Integer = e.DrillDownLevel
				Dim tuple As AxisPointTuple = Me.dashboardViewer1.GetCurrentDrillDownValues(itemName)
				If tuple IsNot Nothing Then
					Dim point As AxisPoint = Me.dashboardViewer1.GetCurrentDrillDownValues(itemName).GetAxisPoint()
					Dim l As Integer = 0
					Do While point.Parent IsNot Nothing
						l += 1
						point = point.Parent
					Loop
					If level + 1 = l AndAlso Me.dashboardViewer1.CanPerformDrillUp(itemName) Then
						Me.dashboardViewer1.PerformDrillUp(itemName)
					End If
				End If
			End If
		End Sub
	End Class
End Namespace
