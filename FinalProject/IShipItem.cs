using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    interface IShipItem
    {
        bool Ship { get; set; }
        int ShippingPrice { get; set; }
        int ShipItem();
    }
}
