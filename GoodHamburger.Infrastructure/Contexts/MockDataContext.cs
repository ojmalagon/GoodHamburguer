
using GoodHamburger.Domain.Interfaces;
using GoodHamburger.Domain.Order;
using GoodHamburger.Domain.Product;
using GoodHamburger.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace GoodHamburger.Infrastructure.Data.Contexts
{
    public class MockDataContext: DataContext
    {
        private List<BundleDiscount> bundlesDiscount = new List<BundleDiscount>();
        private List<Item> items = new List<Item>();
        private List<OrderPlacement> ordersPlacement = new List<OrderPlacement>();
        public MockDataContext()
        {
            MockItems();
            MockBundleDiscounts();
            this.Items = this.items;
            this.BundlesDiscount = this.bundlesDiscount;
            this.OrdersPlacement = this.ordersPlacement;
        }
        private List<Item> MockItems()
        {
            this.items = new List<Item>
            {
                new Item{ Id = Guid.NewGuid().ToString(), Name="X Burger", Amount=5, Type= ItemType.Sandwich, Description=DateTime.Now.ToString()},
                new Item{ Id = Guid.NewGuid().ToString(), Name="X Egg", Amount=4.5, Type= ItemType.Sandwich, Description=DateTime.Now.ToString()},
                new Item{ Id = Guid.NewGuid().ToString(), Name="X Bacon", Amount=7, Type= ItemType.Sandwich, Description=DateTime.Now.ToString()},
                new Item{ Id = Guid.NewGuid().ToString(), Name="Fries", Amount=2, Type= ItemType.Extra, Description=DateTime.Now.ToString()},
                new Item{ Id = Guid.NewGuid().ToString(), Name="Soft drink", Amount=2.5, Type= ItemType.Extra, Description=DateTime.Now.ToString()}
            };

            return this.items;
        }

        private List<BundleDiscount> MockBundleDiscounts()
        {
            this.bundlesDiscount = new List<BundleDiscount>
            {
                new BundleDiscount{ Id= Guid.NewGuid().ToString(), Keys=this.items.Select(b=>b.Id).ToList(), Value=20  },
                new BundleDiscount{ Id= Guid.NewGuid().ToString(), Keys=this.items.Where(i=>i.Name.Equals("Soft drink") || i.Type==ItemType.Sandwich).Select(b=>b.Id).ToList(), Value=15  },
                new BundleDiscount{ Id= Guid.NewGuid().ToString(), Keys=this.items.Where(i=>i.Name.Equals("Fries") || i.Type==ItemType.Sandwich).Select(b=>b.Id).ToList(), Value=10  }
            };
            return this.bundlesDiscount;
        }

    }
}
