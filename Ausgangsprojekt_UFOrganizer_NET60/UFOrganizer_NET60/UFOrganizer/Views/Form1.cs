namespace UFOrganizer.View
{
    public partial class Form1 : Form
    {
        public event EventHandler? OpenFileRequested;
        public event EventHandler? OpenFavoritesRequested;
        public event EventHandler? PreviousPageRequested;
        public event EventHandler? NextPageRequested;
        public event EventHandler<IList<IUfoReportListViewObject>>? SaveReportsRequested;

        public Form1()
        {
            InitializeComponent();

            // TEST CODE
            //var reports = new List<IUfoReportListViewObject>()
            //{
            //    new UfoReportListViewObject {Summary = "Summary1Summary1Summary1Summary1Summary1Summary1Summary1Summary1Summary1Summary1Summary1Summary1Summary1", City = "City1", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary2", City = "City2", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary3", City = "City3", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary4", City = "City4", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary1", City = "City1", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary2", City = "City2", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary3", City = "City3", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary4", City = "City4", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary1", City = "City1", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary2", City = "City2", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary3", City = "City3", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary4", City = "City4", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary1", City = "City1", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary2", City = "City2", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary3", City = "City3", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary4", City = "City4", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary1", City = "City1", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary2", City = "City2", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary3", City = "City3", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary4", City = "City4", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary1", City = "City1", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary2", City = "City2", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary3", City = "City3", DateTime= DateTime.Now},
            //    new UfoReportListViewObject {Summary = "Summary4", City = "City4", DateTime= DateTime.Now}
            //};
            //this.UpdateReports(reports, 0);
            // TEST CODE
        }

        public Form1(IList<IUfoReportListViewObject> reports, int pageIndex) : this()
        {
            UpdateReports(reports, pageIndex);
        }

        public void UpdateReports(IList<IUfoReportListViewObject> reports, int pageIndex)
        {
            if (reports == null) throw new ArgumentNullException(nameof(reports));
            if (reports.Count > 20) throw new ArgumentOutOfRangeException(nameof(reports), reports.Count, "Maximum number of elements (20) exceeded!");
            lblPageNunber.Text = pageIndex.ToString();
            if (pageIndex > 0) { btnBack.Enabled = true; }
            else { btnBack.Enabled = false; }

            lvReports.Items.Clear();
            foreach (var item in reports)
            {
                lvReports.Items.Add(ToListViewItem(item));
            }
            lvReports.Update();
        }

        private static ListViewItem ToListViewItem(IUfoReportListViewObject item) => new ListViewItem(new string[] { item.Summary, item.DateTime.ToString(), item.City }) { Tag = item };

        private class UfoReportListViewObject : IUfoReportListViewObject
        {
            public string Summary { get; set; }

            public string City { get; set; }

            public DateTime DateTime { get; set; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IList<IUfoReportListViewObject> selectedItems = new List<IUfoReportListViewObject>(lvReports.SelectedItems.Count);
            foreach (ListViewItem item in lvReports.SelectedItems)
            {
                selectedItems.Add(item.Tag as IUfoReportListViewObject);
            }

            SaveReportsRequested?.Invoke(this, selectedItems);

            lvReports.SelectedItems.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e) => PreviousPageRequested?.Invoke(this, EventArgs.Empty);

        private void btnNext_Click(object sender, EventArgs e) => NextPageRequested?.Invoke(this, EventArgs.Empty);

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvReports.SelectedItems.Count > 0) btnSave.Enabled = true;
            else btnSave.Enabled = false;
        }

        //private void openFile_Click(object sender, EventArgs e) => OpenFileRequested?.Invoke(this, EventArgs.Empty);
        //private void openFile_Click(object sender, EventArgs e)
        //{
            
        //}
        private void openFavorites_Click(object sender, EventArgs e) => OpenFavoritesRequested?.Invoke(this, EventArgs.Empty);

        private void openFile_Click_1(object sender, EventArgs e)
        {
            OpenFileRequested?.Invoke(this, EventArgs.Empty);
        }

        public List<ListObject> SelectedRows()
        {
            // schreibt ausgewählte Datensätze in Liste und übergibt diese, damit FavoriteView Beschrieben werden kann
            return null;
        }
    }
}