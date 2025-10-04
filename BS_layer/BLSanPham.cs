using System;
using System.Collections.Generic;
using System.Linq;
using Supermarket.DB_layer;


namespace Supermarket.BS_layer
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }  // Tên category để hiển thị
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }  // Tên supplier để hiển thị
        public decimal CostPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    public class BLSanPham
    {
        private SupermarketDBEntities db = new SupermarketDBEntities();

        // 1. Lấy danh sách sản phẩm active
        public IQueryable<ProductDTO> LaySanPham()
        {
            return db.Products
                     .Where(p => p.IsActive)
                     .Select(p => new ProductDTO
                     {
                         ProductId = p.ProductId,
                         ProductName = p.ProductName,
                         CategoryId = p.CategoryId,
                         SupplierId = p.SupplierId,
                         CostPrice = p.CostPrice,
                         Quantity = p.Quantity,
                         ExpiryDate = p.ExpiryDate,
                         CategoryName = p.Category.CategoryName,
                         SupplierName = p.Supplier.SupplierName
                     });
        }


        // 2. Thêm sản phẩm
        public bool ThemSanPham(string tenSP, int maDM, int? maNCC, DateTime? hanDung, ref string err)
        {
            try
            {
                var sp = new Product
                {
                    ProductName = tenSP,
                    CategoryId = maDM,
                    SupplierId = maNCC,
                    ExpiryDate = hanDung,
                    IsActive = true
                };

                db.Products.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // 3. Sửa sản phẩm
        public bool CapNhatSanPham(int maSP, string tenSP, int maDM, int? maNCC, DateTime? hanDung, ref string err)
        {
            try
            {
                var sp = db.Products.Find(maSP);
                if (sp == null)
                {
                    err = "Sản phẩm không tồn tại.";
                    return false;
                }

                sp.ProductName = tenSP;
                sp.CategoryId = maDM;
                sp.SupplierId = maNCC;
                sp.ExpiryDate = hanDung;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // 4. Xóa (soft-delete)
        public bool XoaSanPham(int maSP, ref string err)
        {
            try
            {
                var sp = db.Products.Find(maSP);
                if (sp == null)
                {
                    err = "Sản phẩm không tồn tại.";
                    return false;
                }

                sp.IsActive = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // Lấy tồn kho hiện tại của một sản phẩm
        public int GetQuantity(int productId)
        {
            var sp = db.Products.Find(productId);
            if (sp == null) return 0;
            return sp.Quantity;
        }

        // Thay đổi tồn kho: truyền delta dương để cộng, âm để trừ
        public bool ChangeQuantity(int productId, int delta, ref string err)
        {
            try
            {
                var sp = db.Products.Find(productId);
                if (sp == null)
                {
                    err = "Sản phẩm không tồn tại.";
                    return false;
                }

                if (sp.Quantity + delta < 0)
                {
                    err = $"Không đủ tồn kho (hiện có {sp.Quantity}).";
                    return false;
                }

                sp.Quantity += delta;
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
}


