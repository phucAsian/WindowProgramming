using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Supermarket.BS_layer;

namespace Supermarket
{
    public partial class UCStatistics : UserControl
    {
        private readonly BLThongKe _tk = new BLThongKe();

        public UCStatistics()
        {
            InitializeComponent();
            // Khi form load hoặc click Filter thì chạy báo cáo
            this.Load += UCStatistics_Load;
        }

        private void UCStatistics_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            // 1) Đọc khoảng ngày
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            // 2) Ép sang chuỗi nếu TableAdapter nhận string
            string f = from.ToString("yyyy-MM-dd");
            string t = to.ToString("yyyy-MM-dd");

            // 3) Fill DataSet
            var ds = new dsCostProfit();
            var taCost = new dsCostProfitTableAdapters.ImportCostTableAdapter();
            var taProfit = new dsCostProfitTableAdapters.ProfitTableAdapter();

            ds.ImportCostDataTable.Clear();
            taCost.Fill(ds.ImportCostDataTable, f, t);

            ds.ProfitDataTable.Clear();
            taProfit.Fill(ds.ProfitDataTable, f, t);

            // 4) Cấu hình ReportViewer
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath =
                Path.Combine(Application.StartupPath, "rptCostAndProfit.rdlc");

            // 5) Gán đúng tên DataSource như trong RDLC
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("ImportCostDS", ds.ImportCostDataTable as DataTable));
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("ProfitDS", ds.ProfitDataTable as DataTable));

            // 6) Render
            reportViewer1.RefreshReport();
        }
    }
}
