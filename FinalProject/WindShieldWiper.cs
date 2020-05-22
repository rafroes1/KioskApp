using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class WindShieldWiper : Item
    {
        private int length;

        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        public WindShieldWiper()
        {
            this.Id = 3;
            this.Cost = 15;
            this.Weight = 1;
            this.Ship = false;
            this.ShippingPrice = 10;
            this.length = 0;
            this.Name = "";
        }

        public WindShieldWiper(string name, int length, bool willBeShipped)
        {
            this.Id = 3;
            this.Cost = 15;
            this.Weight = 1;
            this.ShippingPrice = 10;
            this.length = length;
            this.Name = name;
            this.Ship = willBeShipped;
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
