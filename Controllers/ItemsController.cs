
using System;
using System.Collections.Generic;
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
      private readonly InMemItemsRepository repository;

      public ItemsController()
      {
         repository = new InMemItemsRepository();
      }

      [HttpGet]
      public IEnumerable<Item> GetItems()
      {
         var items = repository.GetItems();
         return items;
      }

      // Get /items/{id}
      [HttpGet("{id}")]
      public ActionResult<Item> GetItem(Guid id)
      {
         var item = repository.GetItem(id);

         if (item is null)
         {
            return NotFound();
         }
         
         return item;
      }
   }
}
