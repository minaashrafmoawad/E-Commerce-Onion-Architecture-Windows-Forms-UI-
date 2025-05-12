using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
       

        // Foreign keys
        public int UserID { get; set; }
        public int ProductID { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }    
}
