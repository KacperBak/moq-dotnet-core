using System.Collections.Generic;
using Services.Model;

namespace Services 
{
  public class CartService : ICartService 
  {
    public double Total()
    {
        return 0.0;
    }

    public IEnumerable<CartItem> Items()
    {
        return null;
    }
  }
}