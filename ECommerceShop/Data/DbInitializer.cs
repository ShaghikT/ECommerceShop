

using ECommerceShop.Models;

namespace ECommerceShop.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }

            /*var products = new Product[]
            {
                new Product() {
                        Id = 1,
                        Name = "Camera",
                        Photo = "Camera.jpg",
                        Price = 122.20m


                },

                new Product()
                {
                    Id = 2,
                        Name = "Phone",
                        Photo = "Phone.jpg",
                        Price = 50.896m

                },

                 new Product()
                {
                    Id = 3,
                        Name = "Laptop",
                        Photo = "Laptop.jpg",
                        Price = 200m

                },

                 new Product()
                {
                    Id = 4,
                        Name = "Car",
                        Photo = "Car.jpg",
                        Price = 500m

                },

                  new Product()
                {
                    Id = 5,
                        Name = "TV",
                        Photo = "TV.jpg",
                        Price = 150m

                },

            };

            foreach ( Product p in products )
            { 
            context.Products.Add( p );
            }

            context.SaveChanges();
        }*/

        }
    }
}
