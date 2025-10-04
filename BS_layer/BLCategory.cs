using System;
using System.Collections.Generic;
using System.Linq;
using Supermarket.DB_layer;


namespace Supermarket.BS_layer
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class BLCategory
    {
        private SupermarketDBEntities db = new SupermarketDBEntities();

        /// <summary>
        /// Lấy danh sách CategoryId, CategoryName
        /// </summary>
        public List<CategoryDTO> GetAll()
        {
            return db.Categories
                     .Select(c => new CategoryDTO
                     {
                         CategoryId = c.CategoryId,
                         CategoryName = c.CategoryName
                     }).ToList();
        }

    }



}
