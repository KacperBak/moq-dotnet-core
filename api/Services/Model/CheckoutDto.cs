using System;

namespace Services.Model
{
  public class CheckoutDto
  {
    public Card Card { get; set; }
    public AddressInfo AddressInfo { get; set; }
  }
}