using GoodHamburger.Api.Cache;
using GoodHamburger.Application.Services;
using GoodHamburger.Domain.Order;
using GoodHamburger.Domain.Product;
using GoodHamburger.Infrastructure.Data.Contexts;
using GoodHamburger.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Api.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : Controller
    {
        static ItemService CreateService()
        {
            MockDataContext dataContext = CacheManage.getCacheDataContext("MockDataContext");


            if (dataContext == null) {
                dataContext = new MockDataContext();
                CacheManage.setCacheDataContext(dataContext, "MockDataContext");
            }
           
            ItemRepository itemRepository = new ItemRepository(dataContext);
            ItemService itemService = new ItemService(itemRepository);
            return itemService;
        }


        [HttpGet("all")]
        public Task<List<Item>> ListAll()
        {
            ItemService itemService = CreateService();
            return Task.FromResult(itemService.List());
        }

        [HttpGet("{itemType}")]
        public Task<List<Item>> ListByItemType(String itemType)
        {
            ItemService itemService = CreateService();
            return Task.FromResult(itemService.ListByItemType(itemType));
        }


    }
}
