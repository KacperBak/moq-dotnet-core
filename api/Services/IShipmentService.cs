using System;
using System.Collections.Generic;
using Services.Model;

namespace Services
{
  public interface IShipmentService
  {
    void Ship(AddressInfo info, IEnumerable<CartItem> items);
  }
}