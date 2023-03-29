using GoodHamburger.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Domain.Interfaces
{
    public interface IItemRepository
    {
        public List<Item> List();
        public List<Item> ListByItemType(String itemType);
    }
}
