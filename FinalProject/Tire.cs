using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Tire : Item
    {
        private string model;
        private int diameter;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Diameter
        {
            get { return this.diameter; }
            set { this.diameter = value; }
        }

        public Tire()
        {
            this.Id = 1;
            this.Cost = 200;
            this.Weight = 30;
            this.Ship = false;
            this.ShippingPrice = 0;
            this.diameter = 0;
            this.model = "";
            this.Name = "";
        }

        public Tire(string name, string model, int diameter)
        {
            this.Id = 1;
            this.Cost = 200;
            this.Weight = 30;
            this.ship = false;
            this.ShippingPrice = 0;
            this.diameter = diameter;
            this.model = model;
            this.Name = name;
        }
        public override int ShipItem()
        {
            if (this.Ship)
            {
                return this.ShippingPrice;
            }
            else { return 0; }
        }
    }
}
