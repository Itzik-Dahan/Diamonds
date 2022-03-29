
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
   }
}
