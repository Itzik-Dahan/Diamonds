namespace Diamonds.Settings
{
   public class MongoDbSettings
   {
      public string Host { get; set; }
      public int Port { get; set; }
      public string ConnetionSring
      {
         get
         {
            return $"mongodb://{Host}:{Port}";
         }
      }

   }

}