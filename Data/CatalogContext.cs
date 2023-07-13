using Catalog.Api.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext:ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        
        
        public CatalogContext(IConfiguration configuration)
        {
            var settings = new MongoClientSettings
            {
                Credential = MongoCredential.CreateCredential(
                     databaseName:configuration.GetValue<string>("DatabaseStrings:DatabaseName"),
                     username:configuration.GetValue<string>("DatabaseStrings:UserName"),
                     password:configuration.GetValue<string>("DatabaseStrings:Password")
                    ),
                Server = new MongoServerAddress(
                     host:configuration.GetValue<string>("DatabaseStrings:Host"),
                     port:configuration.GetValue<int>("DatabaseStrings:Port")
                    ),
            };
            var client = new MongoClient(settings);

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseStrings:DatabaseName"));

           Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseStrings:CollectionName"));
           
           CatalogContextSeed.SeedData(Products);
        }
      
    }
}