using System;
using System.Linq;
using System.Collections.Generic;
using Diamonds.Entities;

namespace Diamonds.Repositories
{
   public class InMemItemsRepository
   {
      private readonly List<Item> items = new()
      {
         new Item { Id = Guid.NewGuid(), Shape = "Round", Size = 1.02, Color = "D", Clarity = "IF", Price = 15000, ListPrice = 18000 },
         new Item { Id = Guid.NewGuid(), Shape = "Pear", Size = 1.5, Color = "E", Clarity = "VVS1", Price = 20000, ListPrice = 21000 },
         new Item { Id = Guid.NewGuid(), Shape = "Emerald", Size = 0.95, Color = "G", Clarity = "VVS2", Price = 12000, ListPrice = 10000 },
         new Item { Id = Guid.NewGuid(), Shape = "Round", Size = 2.15, Color = "F", Clarity = "I2", Price = 50000, ListPrice = 55000 },
         new Item { Id = Guid.NewGuid(), Shape = "Emerald", Size = 0.5, Color = "D", Clarity = "IF", Price = 2000, ListPrice = 3000 },
         new Item { Id = Guid.NewGuid(), Shape = "Pear", Size = 1.2, Color = "G", Clarity = "I1", Price = 15000, ListPrice = 12000 },
      };

      public IEnumerable<Item> GetItems()
      {
         return items;
      }

      public Item GetItem(Guid id)
      {
         return items.Where(item=> item.Id == id).SingleOrDefault();
      }
      
   }


}
