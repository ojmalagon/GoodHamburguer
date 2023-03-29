using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Domain.Order
{
    public class OrderPlacement
    {
        public String Id { get; set; }
        public OrderDetail orderDetail { get; set; }
        public String usernaName { get; set; }
        public double OrderDiscount { get; set; }
        public double TotalAmount { get; set; }
    }
}
