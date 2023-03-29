using GoodHamburger.Domain.Interfaces;
using GoodHamburger.Domain.Order;
using GoodHamburger.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MockDataContext _dataContext;
        public OrderRepository(MockDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteOrderPlacement(string id)
        {
            OrderPlacement orderPlacement = this.GetOrderPlacement(id);
            if (orderPlacement != null)
            {
                _dataContext.OrdersPlacement.Remove(orderPlacement);
            }
        }

        public List<BundleDiscount> GetAllBundleDiscount()
        {
            return _dataContext.BundlesDiscount;
        }

        public List<OrderPlacement> ListAllOrders()
        {
            return _dataContext.OrdersPlacement;
        }

        public double OrderPlacement(OrderPlacement orderPlacement)
        {
            OrderPlacement order = _dataContext.addOrderPlacement(orderPlacement);
            return order.TotalAmount;
        }

        public double UpdateOrderPlacement(OrderPlacement orderPlacement)
        {
            OrderPlacement order = _dataContext.updateOrderPlacement(orderPlacement);
            return order.TotalAmount;
        }

        public  OrderPlacement GetOrderPlacement(String id)
        {
            return _dataContext.OrdersPlacement.Where(o => o.Id == id).FirstOrDefault();
        }
    }
}
