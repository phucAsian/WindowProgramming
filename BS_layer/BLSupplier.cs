using System;
using System.Collections.Generic;
using System.Linq;
using Supermarket.DB_layer;


namespace Supermarket.BS_layer
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public bool IsActive { get; set; }
    }


    public class BLSupplier
    {
        private readonly SupermarketDBEntities db = new SupermarketDBEntities();

        /// <summary>
        /// Lấy toàn bộ nhà cung cấp đang active
        /// </summary>
        public List<SupplierDTO> LayNhaCungCap()
        {
            return db.Suppliers
                     .Where(s => s.IsActive)
                     .OrderBy(s => s.SupplierId)
                     .Select(s => new SupplierDTO
                     {
                         SupplierId = s.SupplierId,
                         SupplierName = s.SupplierName,
                         IsActive = s.IsActive
                     })
                     .ToList();
        }



        /// <summary>
        /// Thêm nhà cung cấp mới
        /// </summary>
        public bool ThemNCC(string ten, ref string err)
        {
            try
            {
                var ncc = new Supplier
                {
                    SupplierName = ten,
                    IsActive = true
                };
                db.Suppliers.Add(ncc);
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
        /// Cập nhật tên nhà cung cấp
        /// </summary>
        public bool SuaNCC(int ma, string ten, ref string err)
        {
            try
            {
                var ncc = db.Suppliers.Find(ma);
                if (ncc == null)
                {
                    err = "Nhà cung cấp không tồn tại.";
                    return false;
                }

                ncc.SupplierName = ten;
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
        /// Xóa (vô hiệu hóa) nhà cung cấp
        /// </summary>
        public bool XoaNCC(int ma, ref string err)
        {
            try
            {
                var ncc = db.Suppliers.Find(ma);
                if (ncc == null)
                {
                    err = "Nhà cung cấp không tồn tại.";
                    return false;
                }

                ncc.IsActive = false;
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

