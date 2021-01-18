using Services.Model;

namespace Services 
{
  public class PaymentService : IPaymentService
  {
    public bool Charge(double total, Card card)
    {
        return true;
    }
  }
}