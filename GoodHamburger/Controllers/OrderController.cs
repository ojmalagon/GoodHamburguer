using GoodHamburger.Api.Cache;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Application.Services;
using GoodHamburger.Domain.Order;
using GoodHamburger.Infrastructure.Data.Contexts;
using GoodHamburger.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : Controller
    {

        static OrderService CreateService()
        {
            MockDataContext dataContext = CacheManage.getCacheDataContext("MockDataContext");


            if (dataContext == null)
            {
                dataContext = new MockDataContext();
                CacheManage.setCacheDataContext(dataContext, "MockDataContext");
            }

            OrderRepository orderRepository = new OrderRepository(dataContext);
            OrderService orderService = new OrderService(orderRepository);
            return orderService;
        }

        [HttpGet("all")]
        public Task<List<OrderPlacement>> ListAll()
        {
            OrderService orderService = CreateService();
            return Task.FromResult(orderService.ListAllOrders());
        }

        [HttpPost()]
        public Task<Double> RegisterOrderPlacement(OrderPlacement orderPlacement)
        {
            OrderService orderService = CreateService();
            return Task.FromResult(orderService.OrderPlacement(orderPlacement));
        }

        [HttpPut()]
        public Task<Double> UpdateOrderPlacement(OrderPlacement orderPlacement)
        {
            OrderService orderService = CreateService();
            return Task.FromResult(orderService.UpdateOrderPlacement(orderPlacement));
        }

        [HttpDelete("{id}")]
        public Task<String> RemoveOrderPlacement(String id)
        {
            OrderService orderService = CreateService();
            if (!String.IsNullOrEmpty(id))
            {
                orderService.DeleteOrderPlacement(id);
            }
            
            return Task.FromResult("Ok");
        }
    }
}
