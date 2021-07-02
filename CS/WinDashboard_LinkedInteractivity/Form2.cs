using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.DashboardWin;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WinDashboard_LinkedInteractivity {
    public partial class Form2 : DevExpress.XtraEditors.XtraForm {
        public new Form1 ParentForm { get; set; }        
        public Form2(Form1 parentForm) {
            InitializeComponent();
            this.dashboardViewer1.LoadDashboard("Data\\DashboardChild.xml");
            this.ParentForm = parentForm;
            DashboardDesigner dParentControl = this.ParentForm.DControl;
            dParentControl.MasterFilterSet += DControl_MasterFilterSet;
            dParentControl.MasterFilterCleared += DControl_MasterFilterCleared;
            dParentControl.DrillDownPerformed += DControl_DrillDownPerformed;
            dParentControl.DrillUpPerformed += DControl_DrillUpPerformed;
        }

        bool HasDashboardItem(string itemName) {
            return this.dashboardViewer1.Dashboard.Items.
                Select(i => i.ComponentName).Contains(itemName);
        }

        private void DControl_MasterFilterSet(object sender, MasterFilterSetEventArgs e) {
            if (HasDashboardItem(e.DashboardItemName)) {
                string itemName = e.DashboardItemName;
                if (e.SelectedValues != null)
                    this.dashboardViewer1.SetMasterFilter(itemName, e.SelectedValues);
                if (e.SelectedRange != null)
                    this.dashboardViewer1.SetRange(itemName, e.SelectedRange);
            }
        }
        private void DControl_MasterFilterCleared(object sender, MasterFilterClearedEventArgs e) {
            if (HasDashboardItem(e.DashboardItemName)) {
                string itemName = e.DashboardItemName;
                if (this.dashboardViewer1.CanClearMasterFilter(itemName))
                    this.dashboardViewer1.ClearMasterFilter(itemName);
            }
        }
        private void DControl_DrillDownPerformed(object sender, DrillActionEventArgs e) {
            if (HasDashboardItem(e.DashboardItemName)) {
                string itemName = e.DashboardItemName;
                DashboardDataRow row = e.Values[0];
                object value = row[row.Length - 1];

                IList<AxisPointTuple> tuple = this.dashboardViewer1.GetAvailableDrillDownValues(itemName);
                IEnumerable<object> availableValues = tuple.Select(t => t.GetAxisPoint().UniqueValue);
                if (availableValues.Contains(value)) {
                    this.dashboardViewer1.PerformDrillDown(e.DashboardItemName, value);
                }
            }
        }
        private void DControl_DrillUpPerformed(object sender, DrillActionEventArgs e) {
            if (HasDashboardItem(e.DashboardItemName)) {
                string itemName = e.DashboardItemName;
                int level = e.DrillDownLevel;
                AxisPointTuple tuple = this.dashboardViewer1.GetCurrentDrillDownValues(itemName);
                if (tuple != null) {
                    AxisPoint point = this.dashboardViewer1.GetCurrentDrillDownValues(itemName).GetAxisPoint();
                    int l = 0;
                    while (point.Parent != null) {
                        l++;
                        point = point.Parent;
                    }
                    if (level + 1 == l && this.dashboardViewer1.CanPerformDrillUp(itemName))
                        this.dashboardViewer1.PerformDrillUp(itemName);
                }
            }
        }
    }
}
