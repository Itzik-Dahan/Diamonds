using System.ComponentModel.DataAnnotations;

namespace Diamonds.Dtos


{
   public record CreateItemDto
   {
      [Required]
      public string Shape { get; init; }

      [Required]
      // [Rang(,)] => the way to set rage to num input
      public double Size { get; init; }

      [Required]
      public string Color { get; init; }

      [Required]
      public string Clarity { get; init; }

      [Required]
      public decimal Price { get; init; }

      [Required]
      public decimal ListPrice { get; init; }
   }
}