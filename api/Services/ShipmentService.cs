using System;
using System.Collections.Generic;
using Services.Model;

namespace Services
{
    public class ShipmentService : IShipmentService
    {
        public void Ship(AddressInfo info, IEnumerable<CartItem> items)
        {
            System.Console.WriteLine("shipping...");
        }
    }
}