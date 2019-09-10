Imports DevExpress.DashboardWin

Namespace WinDashboard_LinkedInteractivity
	Partial Public Class Form1
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Public Property DControl() As DashboardDesigner
		Public Sub New()
			InitializeComponent()
			DControl = Me.dashboardDesigner1

			dashboardDesigner1.AllowEditComponentName = True
			dashboardDesigner1.LoadDashboard("Data\Dashboard.xml")
		End Sub

		Private Sub btnShowChildForm_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowChildForm.ItemClick
			Dim f2 As New Form2(Me)
			f2.Show()
		End Sub
	End Class
End Namespace
