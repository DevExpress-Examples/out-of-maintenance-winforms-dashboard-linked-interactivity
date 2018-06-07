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

- [DashboardViewer.SetMasterFilter](https://docs.devexpress.com/DevExpress.DashboardWin.DashboardViewer.SetMasterFilter)
- [DashboardViewer.SetRange](https://docs.devexpress.com/DevExpress.DashboardWin.DashboardViewer.SetRange)
- [DashboardViewer.PerformDrillDown](https://docs.devexpress.com/DevExpress.DashboardWin.DashboardViewer.PerformDrillDown)
- [DashboardViewer.PerformDrillUp](https://docs.devexpress.com/DevExpress.DashboardWin.DashboardViewer.PerformDrillUp)


![](https://github.com/DevExpress-Examples/winforms-dashboard-linked-interactivity/blob/18.1.3%2B/images/winforms-dashboard-linked-interactivity.png)