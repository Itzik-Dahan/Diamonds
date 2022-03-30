
using System;
using System.Collections.Generic;
using System.Linq;
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
      public IEnumerable<ItemDto> GetItems()
      {
         var items = repository.GetItems().Select(item => item.AsDto());
         return items;
      }

      // Get /items/{id}
      [HttpGet("{id}")]
      public ActionResult<ItemDto> GetItem(Guid id)
      {
         var item = repository.GetItem(id);

         if (item is null)
         {
            return NotFound();
         }

         return item.AsDto();
      }

      // Post /item
      [HttpPost]
      public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
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

         repository.CreateItem(item);

         return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
      }

      // PUT /items/id
      [HttpPut("{id}")]
      public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
      {
         var existingItem = repository.GetItem(id);

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

         repository.UpdateItem(updateItem);

         return NoContent();
      }

      // DELETE /items/id
      [HttpDelete("{id}")]
      public ActionResult DeleteItem(Guid id)
      {
         var existingItem = repository.GetItem(id);

         if (existingItem is null)
         {
            return NotFound();
         }

         repository.DeleteItem(id);

         return NoContent();
      }
   }
}
