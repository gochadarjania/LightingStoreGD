using LightingStore_GD.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.MyDbContexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Product> products = new List<Product>();
            List<Category> categories = new List<Category>();
            List<ProductImage> productImages = new List<ProductImage>();
            List<string> catName = new List<string>() { " ", "Chandelier", "Wall Light", "Table Light" };

            int ImgId = 1;

            for (int i = 1; i < 100; i++)
            {
                if (i < 4)
                {
                    categories.Add(new Category()
                    {
                        CategoryId = i,
                        Name = catName[i]
                    });
                }
                int rndId = new Random().Next(1, 4);
                products.Add(new Product()
                {
                    ProductId = i,
                    Name = "Product - " + catName[rndId],
                    Description = "Description" + i,
                    Price = new Random().Next(20, 500),
                    CategoryId = rndId,
                    CategoryName = catName[rndId]
                });

                for (int j = 1; j < 5; j++)
                {
                    productImages.Add(new ProductImage()
                    {
                        Id = ImgId,
                        ImageUrl = Images(rndId),
                        ProductId = i
                    });
                    ImgId++;
                }
            }



            static string Images(int id)
            {
                string url;
                if (id == 1 && id != 0)
                {
                    url = "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg";
                }
                else if (id == 2)
                {
                    url = "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg";
                }
                else
                {
                    url = "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg";
                }
                return url;
            }

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Cart>();
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ProductImage>().HasData(productImages);



            base.OnModelCreating(modelBuilder);
        }
             
    }
}
