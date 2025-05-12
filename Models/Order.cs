using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum OrderStatus
    {
        Pending,
        Approved,
        Denied,
        Shipped
    }

    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime? DateProcessed { get; set; }

        // Foreign key
        public int UserID { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public  virtual ICollection<OrderDetail> OrderDetails { get; set; }=new HashSet<OrderDetail>();
    }
}
