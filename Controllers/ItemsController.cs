
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diamonds.Dtos;
using Diamonds.Entities;
using Diamonds.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Diamonds.Controllers
{
   // Get /items

   [ApiController]
   [Route("items")]
   public class ItemsController : ControllerBase
   {
      private readonly IItemsRepository repository;

      public ItemsController(IItemsRepository repository)
      {
         this.repository = repository;
      }

      [HttpGet]
      public async Task<IEnumerable<ItemDto>> GetItemsAsync()
      {
         var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
         return items;
      }

      // Get /items/{id}
      [HttpGet("{id}")]
      public async Task< ActionResult<ItemDto>> GetItemAsync(Guid id)
      {
         var item = await repository.GetItemAsync(id);

         if (item is null)
         {
            return NotFound();
         }

         return item.AsDto();
      }

      // Post /item
      [HttpPost]
      public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
      {
         Item item = new()
         {
            Id = Guid.NewGuid(),
            Shape = itemDto.Shape,
            Size = itemDto.Size,
            Color = itemDto.Color,
            Clarity = itemDto.Clarity,
            Price = itemDto.Price,
            ListPrice = itemDto.ListPrice,
         };

         await repository.CreateItemAsync(item);

         return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
      }

      // PUT /items/id
      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
      {
         var existingItem = await repository.GetItemAsync(id);

         if (existingItem is null)
         {
            return NotFound();
         }

         Item updateItem = existingItem with
         {
            Shape = itemDto.Shape,
            Size = itemDto.Size,
            Color = itemDto.Color,
            Clarity = itemDto.Clarity,
            Price = itemDto.Price,
            ListPrice = itemDto.ListPrice
         };

         await repository.UpdateItemAsync(updateItem);

         return NoContent();
      }

      // DELETE /items/id
      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteItemAsync(Guid id)
      {
         var existingItem = await repository.GetItemAsync(id);

         if (existingItem is null)
         {
            return NotFound();
         }

         await repository.DeleteItemAsync(id);

         return NoContent(); 
      }
   }
}
