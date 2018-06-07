using DevExpress.DashboardWin;

namespace WinDashboard_LinkedInteractivity
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DashboardDesigner DControl { get; set; }
        public Form1()
        {
            InitializeComponent();
            DControl = this.dashboardDesigner1;

            dashboardDesigner1.AllowEditComponentName = true;
            dashboardDesigner1.LoadDashboard("Data\\Dashboard.xml");
        }

        private void btnShowChildForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }
    }
}
