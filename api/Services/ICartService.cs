using System.Collections.Generic;
using Services.Model;

namespace Services 
{
  public interface ICartService 
  {
    double Total();
    IEnumerable<CartItem> Items();
  }
}