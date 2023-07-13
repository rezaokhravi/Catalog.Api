using System.Collections.Generic;
using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> collection)
        {
            bool existProduct = collection.Find(p => true).Any();
            if (!existProduct)
            {
                collection.InsertManyAsync(GetSeedData());
            }
        }

        private static IEnumerable<Product> GetSeedData()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = "64abedfd11e83bc39891b3f3",
                    Category = "Fruits",
                    Name = "Apples",
                    Price = 350.00M,
                    Summery = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Egestas purus viverra accumsan in nisl nisi Arcu cursus vitae congue mauris rhoncus aenean vel elit scelerisque",
                    ImageFile = "Product_01.jpg"
                },
                new Product
                {
                    Id = "64abef6a11e83bc39891b3f4",
                    Category = "Fruits",
                    Name = "Avocados",
                    Price = 100.00M,
                    Summery = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Egestas purus viverra accumsan in nisl nisi Arcu cursus vitae congue mauris rhoncus aenean vel elit scelerisque",
                    ImageFile = "Product_02.jpg"
                },
                new Product
                {
                    Id = "64abef7211e83bc39891b3f5",
                    Category = "Fruits",
                    Name = "Bananas",
                    Price = 570.00M,
                    Summery = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Egestas purus viverra accumsan in nisl nisi Arcu cursus vitae congue mauris rhoncus aenean vel elit scelerisque",
                    ImageFile = "Product_03.jpg"
                },
                new Product
                {
                    Id = "64abef7711e83bc39891b3f6",
                    Category = "Fruits",
                    Name = "Grapes",
                    Price = 800.00M,
                    Summery = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Egestas purus viverra accumsan in nisl nisi Arcu cursus vitae congue mauris rhoncus aenean vel elit scelerisque",
                    ImageFile = "Product_04.jpg"
                }
            };
        }
    }
}