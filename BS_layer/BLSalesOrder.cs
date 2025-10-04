using System;
using System.Collections.Generic;
using System.Linq;
using Supermarket.DB_layer;

namespace Supermarket.BS_layer
{
    public class BLSalesOrder
    {
        private SupermarketDBEntities db = new SupermarketDBEntities();

        /// <summary>
        /// Lấy toàn bộ hóa đơn (kèm tên SP, danh mục) theo thứ tự mới nhất
        /// </summary>
        public List<SalesOrderDTO> LayHoaDon()
        {
            var query = from so in db.SalesOrders
                        join p in db.Products on so.ProductId equals p.ProductId
                        join c in db.Categories on p.CategoryId equals c.CategoryId
                        orderby so.OrderId descending
                        select new SalesOrderDTO
                        {
                            OrderId = so.OrderId,
                            ProductId = so.ProductId,
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName,
                            SellPrice = so.SellPrice,
                            Quantity = so.Quantity,
                            TotalAmount = so.TotalAmount,
                            Status = so.Status,
                            IssueDate = so.IssueDate
                        };
            return query.ToList();
        }

        /// <summary>
        /// Thêm hóa đơn mới (Status mặc định = 'New', TotalAmount và CreateDate do DB tính)
        /// </summary>
        public bool ThemHoaDon(int maSP, decimal gia, int sl, ref string err)
        {
            try
            {
                var so = new SalesOrder
                {
                    ProductId = maSP,
                    SellPrice = gia,
                    Quantity = sl,
                    Status = "New"
                    // TotalAmount, IssueDate nếu DB tính tự động thì không cần set ở đây
                };
                db.SalesOrders.Add(so);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật hóa đơn (chỉ khi Status = 'New')
        /// </summary>
        public bool CapNhatHoaDon(int maHD, decimal gia, int sl, ref string err)
        {
            try
            {
                var so = db.SalesOrders.SingleOrDefault(o => o.OrderId == maHD && o.Status == "New");
                if (so == null)
                {
                    err = "Không tìm thấy hóa đơn hoặc trạng thái không hợp lệ.";
                    return false;
                }
                so.SellPrice = gia;
                so.Quantity = sl;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa hóa đơn (chỉ khi Status = 'New')
        /// </summary>
        public bool XoaHoaDon(int maHD, ref string err)
        {
            try
            {
                var so = db.SalesOrders.SingleOrDefault(o => o.OrderId == maHD && o.Status == "New");
                if (so == null)
                {
                    err = "Không tìm thấy hóa đơn hoặc trạng thái không hợp lệ.";
                    return false;
                }
                db.SalesOrders.Remove(so);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xuất hóa đơn (New → Issued)
        /// </summary>
        public bool XuatHoaDon(int maHD, DateTime ngayXuat, ref string err)
        {
            try
            {
                var so = db.SalesOrders.SingleOrDefault(o => o.OrderId == maHD && o.Status == "New");
                if (so == null)
                {
                    err = "Không tìm thấy hóa đơn hoặc trạng thái không hợp lệ.";
                    return false;
                }
                so.Status = "Issued";
                so.IssueDate = ngayXuat;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
    }

    public class SalesOrderDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime? IssueDate { get; set; }
    }

}
