using GoodHamburger.Application.Helpers;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Interfaces;
using GoodHamburger.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Services
{
    public  class ItemService: IItemService
    {

        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<Item> List()
        {
            return _itemRepository.List();
        }

        public List<Item> ListByItemType(String itemType)
        {
            return String.IsNullOrEmpty(itemType) ? throw new AppException("item type should has had a value") : _itemRepository.ListByItemType(itemType);
        }
    }
}
