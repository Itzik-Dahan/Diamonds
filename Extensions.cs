using Diamonds.Dtos;
using Diamonds.Entities;

namespace Diamonds
{
   public static class Extensions
   {
      public static ItemDto AsDto(this Item item)
      {
        return new ItemDto
         {
            Id = item.Id,
            Shape = item.Shape,
            Size = item.Size,
            Color = item.Color,
            Clarity = item.Clarity,
            Price = item.Price,
            ListPrice = item.ListPrice,
         };
      }
   }
}