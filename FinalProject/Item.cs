using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public abstract class Item : IShipItem
    {
        private int id;
        private int cost;
        private int weight;
        private string name;
        protected bool ship;
        protected int shippingPrice;

        public int Id {
            get { return this.id; }
            set { this.id = value; }
        }

        public int Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }

        public bool Ship { get => ship; set => ship = value; }
        public int ShippingPrice { get => shippingPrice; set => shippingPrice = value; }

        public Item(){
            this.id = 0;
            this.cost = 0;
            this.weight = 0;
            this.ship = false;
            this.shippingPrice = 0;
        }

        public abstract int ShipItem();
    }
}
