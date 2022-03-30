
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
   }
}
