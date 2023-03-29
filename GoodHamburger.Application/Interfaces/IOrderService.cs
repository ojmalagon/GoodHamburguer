using GoodHamburger.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Interfaces
{
    public interface IOrderService
    {
        public double OrderPlacement(OrderPlacement orderPlacement);
        public List<OrderPlacement> ListAllOrders();
        public double UpdateOrderPlacement(OrderPlacement orderPlacement);
        public void DeleteOrderPlacement(String id);
        public List<BundleDiscount> GetAllBundleDiscount();
        public OrderPlacement GetOrderPlacement(String id);
    }
}
