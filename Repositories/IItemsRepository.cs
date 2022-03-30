using System;
using System.Collections.Generic;
using Diamonds.Entities;

namespace Diamonds.Repositories
{
    public interface IItemsRepository
   {
      Item GetItem(Guid id);
      IEnumerable<Item> GetItems();
   }
}