using System;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Model;

namespace api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CartController 
  {
    private readonly ICartService _cartService;
    private readonly IPaymentService _paymentService;
    private readonly IShipmentService _shipmentService;
    
    public CartController(
      ICartService cartService,
      IPaymentService paymentService,
      IShipmentService shipmentService
    ) 
    {
      _cartService = cartService;
      _paymentService = paymentService;
      _shipmentService = shipmentService;
    }

    [HttpPost]
    public string Post(CheckoutDto checkoutDto) 
    {
      var result = _paymentService.Charge(_cartService.Total(), checkoutDto.Card);
      if (result)
      {
          _shipmentService.Ship(checkoutDto.AddressInfo, _cartService.Items());
          return "charged";
      }
      else {
          return "not charged";
      }
    }

    [HttpGet]
    public CheckoutDto Get() 
    {
      Card card = new Card{
        CardNumber = "0000-1111-2222-3333-4444",
        Name = "Awesome Card",
        ValidTo = new DateTime().AddYears(1)
      };

      AddressInfo addressInfo = new AddressInfo
      {
        Street = "Happy Road",
        Address = "0815",
        City = "Happy Town",
        PostalCode = "0123456789",
        PhoneNumber = "0049-123456",
      };

      CheckoutDto result = new CheckoutDto{
        Card = card,
        AddressInfo = addressInfo
      };

      return result;
    }
  }
}