using GoodHamburger.Application.Helpers;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Interfaces;
using GoodHamburger.Domain.Order;
using GoodHamburger.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void DeleteOrderPlacement(String id)
        {
            if (String.IsNullOrEmpty(id))
            {
                _orderRepository.DeleteOrderPlacement(id);
            }
            else
            {
                throw new AppException("The Id should has had a value");
            }
        }

        public List<BundleDiscount> GetAllBundleDiscount()
        {
            return _orderRepository.GetAllBundleDiscount();
        }

        public List<OrderPlacement> ListAllOrders()
        {
            return _orderRepository.ListAllOrders();
        }

        public double OrderPlacement(OrderPlacement orderPlacement)
        {
            double totalAmount =0, totalDiscount=0;
            if (this.validateOrderToBePlaced(orderPlacement))
            {
                totalDiscount = this.calculateDiscount(orderPlacement.orderDetail.Items.Select(i => i.Id).ToList());
                totalAmount = orderPlacement.orderDetail.Items.Sum(i => i.Amount);
                orderPlacement.OrderDiscount = totalDiscount>0? totalDiscount/100:0;
                orderPlacement.TotalAmount = totalAmount*(1- orderPlacement.OrderDiscount);
                _orderRepository.OrderPlacement(orderPlacement);
                return totalAmount;
            }
            else
            {
                throw new AppException("The order cannot contain more than one sandwich, fries, or soda");
            }
            
        }

        public double UpdateOrderPlacement(OrderPlacement orderPlacement)
        {
            double totalAmount = 0, totalDiscount = 0;
            if (this.validateOrderToBePlaced(orderPlacement))
            {
                totalDiscount = this.calculateDiscount(orderPlacement.orderDetail.Items.Select(i => i.Id).ToList());
                totalAmount = orderPlacement.orderDetail.Items.Sum(i => i.Amount);
                orderPlacement.OrderDiscount = totalDiscount > 0 ? totalDiscount / 100 : 0;
                orderPlacement.TotalAmount = totalAmount * (1 - orderPlacement.OrderDiscount);
                _orderRepository.UpdateOrderPlacement(orderPlacement);
                return totalAmount;
            }
            else
            {
                throw new AppException("The order cannot contain more than one sandwich, fries, or soda");
            }
        }

        public OrderPlacement GetOrderPlacement(String id) 
        {
            return _orderRepository.GetOrderPlacement(id);
        }

        private Boolean validateOrderToBePlaced(OrderPlacement orderPlacement)
        {
            int countSandwich = orderPlacement.orderDetail.Items.Where(i => i.Type == ItemType.Sandwich).Count();
            int countFries = orderPlacement.orderDetail.Items.Where(i => i.Type == ItemType.Extra && i.Name.ToUpper().Contains("Fries")).Count();
            int countSoda = orderPlacement.orderDetail.Items.Where(i => i.Type == ItemType.Extra && i.Name.ToUpper().Contains("Soft drink")).Count();
            return countSandwich>1 || countFries>1 || countSoda>1? false:true;
        }

        private double calculateDiscount(List<String> KeySet)
        {

            List <BundleDiscount>  bundlesDiscount= this.GetAllBundleDiscount();

            double value = 0;
            if (bundlesDiscount != null)
            {
                value= bundlesDiscount.Where(b => b.Keys.Where(k => KeySet.Contains(k)).Count() > 0).Select(d => d.Value).LastOrDefault();
            }    
                

            return value;
        }
    }
}
