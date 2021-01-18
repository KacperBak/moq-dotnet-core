using Services.Model;

namespace Services 
{
  public interface IPaymentService 
  {
    bool Charge(double total, Card card);
  }
}