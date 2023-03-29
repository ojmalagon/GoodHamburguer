using GoodHamburger.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Domain.Order
{
    public class OrderDetail
    {
       public String Id { get; set; }
       public List<Item> Items { get;set; }
    }
}
