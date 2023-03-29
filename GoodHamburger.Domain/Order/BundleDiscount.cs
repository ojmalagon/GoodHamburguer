using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Domain.Order
{
    public class BundleDiscount
    {
        public String Id { get; set; }
        public List<String> Keys { get; set; }
        public long Value { get; set; }
    }
}
