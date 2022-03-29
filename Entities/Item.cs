using System;

namespace Diamonds.Entities

{
   public record Item
   {
      public Guid Id {get ; init; }
      public string Shape { get; init; }
      public double Size { get; init; }
      public string Color { get; init; }
      public string Clarity { get; init; }
      public decimal Price { get; init; }
      public decimal ListPrice { get; init; }
   }
}