using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models

{
    public enum UserRole
    {
        Client,
        Admin
    }
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime ?DateCreated { get; set; } 
        public DateTime? LastLoginDate { get; set; }


        public virtual ICollection<Order> Orders { get; set; }= new HashSet<Order>();
        public virtual ICollection<CartItem> CartItems { get; set; }= new HashSet<CartItem>();

    }
}
