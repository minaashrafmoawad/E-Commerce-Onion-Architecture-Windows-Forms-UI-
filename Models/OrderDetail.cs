using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int Quantity { get; set; }

        // Foreign keys
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }
        public  virtual Product Product { get; set; }
    }
}
