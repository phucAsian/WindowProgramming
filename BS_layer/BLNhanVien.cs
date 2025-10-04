using System;
using System.Collections.Generic;
using System.Linq;
using Supermarket.DB_layer;

namespace Supermarket.BS_layer
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
    }



    public class BLNhanVien
    {
        private readonly SupermarketDBEntities db = new SupermarketDBEntities();

        /// <summary>
        /// Lấy toàn bộ nhân viên đang active
        /// </summary>
        public List<EmployeeDTO> LayNhanVien()
        {
            return db.Employees
                     .Where(e => e.IsActive)
                     .OrderBy(e => e.EmployeeId)
                     .Select(nv => new EmployeeDTO
                     {
                         EmployeeId = nv.EmployeeId,
                         FullName = nv.FullName,
                         Phone = nv.Phone,
                         Salary = nv.Salary,
                         HireDate = nv.HireDate
                     })
                     .ToList();
        }




        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        public bool ThemNhanVien(string fullName, string phone, string salary, string hireDate, ref string err)
        {
            try
            {
                Employee e = new Employee
                {
                    FullName = fullName,
                    Phone = phone,
                    Salary = decimal.Parse(salary),
                    HireDate = DateTime.Parse(hireDate),
                    IsActive = true
                };

                db.Employees.Add(e);
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
        /// Cập nhật nhân viên (chỉ khi còn active)
        /// </summary>
        public bool SuaNhanVien(string id, string fullName, string phone, string salary, string hireDate, ref string err)
        {
            try
            {
                int empId = int.Parse(id);
                var nv = db.Employees.FirstOrDefault(e => e.EmployeeId == empId && e.IsActive == true);

                if (nv != null)
                {
                    nv.FullName = fullName;
                    nv.Phone = phone;
                    nv.Salary = decimal.Parse(salary);
                    nv.HireDate = DateTime.Parse(hireDate);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa (vô hiệu hóa) nhân viên
        /// </summary>
        public bool XoaNhanVien(string id, ref string err)
        {
            try
            {
                int empId = int.Parse(id);
                var nv = db.Employees.FirstOrDefault(e => e.EmployeeId == empId);
                if (nv != null)
                {
                    nv.IsActive = false;
                    db.SaveChanges();
                }

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
