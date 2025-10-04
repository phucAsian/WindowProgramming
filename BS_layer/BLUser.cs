using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Supermarket.DB_layer;

namespace Supermarket.BS_layer
{    /// <summary>
     /// DTO đơn giản để chứa kết quả Authenticate
     /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
    public class BLUser
    {
        private readonly SupermarketDBEntities db = new SupermarketDBEntities();

        /// <summary>
        /// Xác thực username/password, trả về thông tin user nếu đúng, ngược lại null.
        /// </summary>
        public User Authenticate(string username, string plainPassword)
        {
            // Hash SHA256 (chỉ demo)
            byte[] raw = Encoding.UTF8.GetBytes(plainPassword);
            byte[] hashed = SHA256.Create().ComputeHash(raw);
            string hashHex = BitConverter.ToString(hashed).Replace("-", "");

            // Truy vấn EF
            var user = (from u in db.Users
                        where u.Username == username
                              && u.PasswordHash == hashHex
                              && u.IsActive == true
                        select new User
                        {
                            UserId = u.UserId,
                            Username = u.Username,
                            RoleName = u.Role.RoleName
                        }).FirstOrDefault();

            return user;
        }
    }


}
