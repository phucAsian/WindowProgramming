using System;
using System.Collections.Generic;
using System.Linq;
using Supermarket.DB_layer;

namespace Supermarket.BS_layer
{
    public class ProfitByMonth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Profit { get; set; }
    }

    public class CostByMonth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Cost { get; set; }
    }

    public class BLThongKe
    {
        private readonly SupermarketDBEntities db = new SupermarketDBEntities();

        /// <summary>
        /// Tổng lợi nhuận bán hàng theo tháng
        /// </summary>
        public List<ProfitByMonth> GetProfitByDate(DateTime fromDate, DateTime toDate)
        {
            var query = from so in db.SalesOrders
                        join p in db.Products on so.ProductId equals p.ProductId
                        where so.Status == "Issued"
                              && so.IssueDate >= fromDate && so.IssueDate <= toDate
                        group new { so, p } by new
                        {
                            Year = so.IssueDate.Value.Year,
                            Month = so.IssueDate.Value.Month
                        }
                into g
                        orderby g.Key.Year, g.Key.Month
                        select new ProfitByMonth
                        {
                            Year = g.Key.Year,
                            Month = g.Key.Month,
                            Profit = g.Sum(x => (x.so.SellPrice - x.p.CostPrice) * x.so.Quantity)
                        };

            return query.ToList();
        }


        /// <summary>
        /// Tổng chi phí nhập kho theo tháng
        /// </summary>
        public List<CostByMonth> GetImportCostByDate(DateTime startDate, DateTime to)
        {
            var query = from io in db.ImportOrders
                        where io.Status == "Issued"
                              && (io.IssueDate >= startDate && io.IssueDate <= to)
                        group io by new
                        {
                            Year = io.IssueDate.Value.Year,
                            Month = io.IssueDate.Value.Month
                        }
                into g
                        orderby g.Key.Year, g.Key.Month
                        select new CostByMonth
                        {
                            Year = g.Key.Year,
                            Month = g.Key.Month,
                            Cost = g.Sum(x => x.TotalAmount ?? 0)
                        };

            return query.ToList();
        }

    }

}
