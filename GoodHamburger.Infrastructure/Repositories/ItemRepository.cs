using GoodHamburger.Domain.Interfaces;
using GoodHamburger.Domain.Product;
using GoodHamburger.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Infrastructure.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly MockDataContext _dataContext;
        public ItemRepository(MockDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Item> List()
        {
            return _dataContext.Items;
        }

        public List<Item> ListByItemType(string itemType)
        {
            return _dataContext.Items.Where(i => i.Type == itemType).ToList();
        }
    }
}
