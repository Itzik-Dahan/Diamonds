using System;
using System.Collections.Generic;
using Diamonds.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Diamonds.Repositories
{
   public class MongoDbItemsRepository : IItemsRepository
   {
      private const string dataBaseName = "diamonds";
      private const string collectionName = "items";

      private readonly IMongoCollection<Item> itemsCollection;

      private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

      public MongoDbItemsRepository(IMongoClient mongoClient)
      {
         IMongoDatabase database = mongoClient.GetDatabase(dataBaseName);
         itemsCollection = database.GetCollection<Item>(collectionName);
      }

      public void CreateItem(Item item)
      {
         itemsCollection.InsertOne(item);
      }

      public void DeleteItem(Guid id)
      {
         var filter = filterBuilder.Eq(item => item.Id, id);
         itemsCollection.DeleteOne(filter);
      }

      public Item GetItem(Guid id)
      {
         var filter = filterBuilder.Eq(item => item.Id, id);
         return itemsCollection.Find(filter).SingleOrDefault();
      }

      private bool filter(Item arg)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<Item> GetItems()
      {
         return itemsCollection.Find(new BsonDocument()).ToList();
      }

      public void UpdateItem(Item item)
      {
         var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
         itemsCollection.ReplaceOne(filter, item);
      }
   }
}