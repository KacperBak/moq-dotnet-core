using System;

namespace Services.Model
{
  public class Card
  {
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public DateTime ValidTo { get; set; }
  }
}