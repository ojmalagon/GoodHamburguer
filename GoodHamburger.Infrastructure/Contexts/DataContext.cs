using GoodHamburger.Domain.Order;
using GoodHamburger.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Infrastructure.Data.Contexts
{
    public class DataContext
    {

        public DataContext() { }
        public List<Item> Items { get; set; }
        public List<OrderPlacement> OrdersPlacement { get; set; }
        public List<OrderDetail> OrdersDetail { get; set; }
        public List<BundleDiscount> BundlesDiscount { get; set; }


        public OrderPlacement addOrderPlacement(OrderPlacement orderPlacement)
        {
            orderPlacement.Id = Guid.NewGuid().ToString();
            this.OrdersPlacement.Add(orderPlacement);
            return orderPlacement;
        }

        public OrderPlacement updateOrderPlacement(OrderPlacement orderPlacement)
        {

            OrderPlacement orderToBeUpdate = this.OrdersPlacement.Where(o => o.Id == orderPlacement.Id).FirstOrDefault();
            if (orderToBeUpdate != null)
            {
                orderToBeUpdate.orderDetail = orderPlacement.orderDetail;
                orderToBeUpdate.usernaName = orderPlacement.usernaName;
                orderToBeUpdate.OrderDiscount = orderPlacement.OrderDiscount;
                orderToBeUpdate.TotalAmount = orderPlacement.TotalAmount;
                orderPlacement = orderToBeUpdate;
            }
            return orderPlacement;
        }

    }
}
