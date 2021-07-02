<!-- default file list -->
*Files to look at*:

* [Form2.cs](./CS/WinDashboard_LinkedInteractivity/Form2.cs) (VB: [Form2.vb](./VB/WinDashboard_LinkedInteractivity/Form2.vb))
<!-- default file list end -->

# How to: Synchronize Master Filter and Drill Down Actions Between Dashboards

This example demonstrates how to synchronize Master Filter and Drill-Down actions between different dashboards.

The main form contains the [Dashboard Designer](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner) control. The _Show Child Form_ command in the _Example_ group on the _Home_ tab invokes a child form with a [Dashboard Viewer](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer) control.

[Master Filtering](https://docs.devexpress.com/Dashboard/15702/creating-dashboards/creating-dashboards-in-the-winforms-designer/interactivity/master-filtering) and 
[Drill-Down](https://docs.devexpress.com/Dashboard/15703/creating-dashboards/creating-dashboards-in-the-winforms-designer/interactivity/drill-down) actions performed in the main form are applied to the child form.

To accomplish this, the child form subscribes to the following events of the main form's **DashboardDesigner** control:

- [DashboardDesigner.MasterFilterSet](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.MasterFilterSet)
- [DashboardDesigner.MasterFilterCleared](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.MasterFilterCleared)
- [DashboardDesigner.DrillDownPerformed](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.DrillDownPerformed)
- [DashboardDesigner.DrillUpPerformed](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.DrillUpPerformed)

When an event occurs, the following methods are used to apply filter values to the child form's **DashboardViewer** control or to perform the data drill-down or drill-up operations:

- [DashboardViewer.SetMasterFilter](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.SetMasterFilter.overloads
)
- [DashboardViewer.SetRange](https://docs.devexpress.com//Dashboard/DevExpress.DashboardWin.DashboardViewer.SetRange.overloads
)
- [DashboardViewer.ClearMasterFilter](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.ClearMasterFilter(System.String))
- [DashboardViewer.PerformDrillDown](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.PerformDrillDown.overloads
)
- [DashboardViewer.PerformDrillUp](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.PerformDrillUp(System.String))


![](images/winforms-dashboard-linked-interactivity.png)

## Documentation

- [Synchronize Master Filter and Drill Down Actions Between Dashboards](https://docs.devexpress.com/Dashboard/400078/)
- [Drill-Down](https://docs.devexpress.com/Dashboard/116913)
- [Master Filtering](https://docs.devexpress.com/Dashboard/116912)
