using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Battery : Item
    {
        private int voltage;

        public int Voltage
        {
            get { return this.voltage; }
            set { this.voltage = value; }
        }
        public Battery()
        {
            this.Id = 2;
            this.Cost = 100;
            this.Weight = 10;
            this.Ship = false;
            this.ShippingPrice = 30;
            this.voltage = 0;
            this.Name = "";
        }
        public Battery(string name, int voltage, bool willBeShipped)
        {
            this.Id = 2;
            this.Cost = 100;
            this.Weight = 10;
            this.Ship = willBeShipped;
            this.ShippingPrice = 30;
            this.voltage = voltage;
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
