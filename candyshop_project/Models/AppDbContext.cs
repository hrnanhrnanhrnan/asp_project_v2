using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Candy> Candies { get; set; } //hejhej efter appsettings Freddy wuz here
        public DbSet<Category> Categores { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Chocolate Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Fruit Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Gummy Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Halloween Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Hard Candy" });

            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 1,
                Name = "Assorted Chocolet Candy",
                Price = 4.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolet.candy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\chocolateCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 2,
                Name = "Assorted Chocolet Candy",
                Price = 3.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolateCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\chocolateCandy-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 3,
                Name = "Assorted Chocolet Candy",
                Price = 2.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolateCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\chocolateCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });

            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 4,
                Name = "Assorted Fruit Candy",
                Price = 6.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 2,
                ImageUrl = "\\Images\\FruitCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\FruitCandy-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 5,
                Name = "Assorted Fruit Candy",
                Price = 3.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 2,
                ImageUrl = "\\Images\\fruitCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\fruitCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 6,
                Name = "Assorted Fruit Candy",
                Price = 4.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 2,
                ImageUrl = "\\Images\\fruitCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\fruitCandy3-small.jpg",
                IsInStock = false,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 7,
                Name = "Assorted Gummy Candy",
                Price = 4.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\gummyCandy-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 8,
                Name = "Assorted Gummy Candy",
                Price = 6.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\gummyCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 9,
                Name = "Assorted Gummy Candy",
                Price = 4.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\gummyCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 10,
                Name = "Assorted Halloween Candy",
                Price = 3.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\halloweenCandy-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 11,
                Name = "Assorted Halloween Candy",
                Price = 5.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\halloweenCandy2-small.jpg",
                IsInStock = false,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 12,
                Name = "Assorted Halloween Candy",
                Price = 6.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\halloweenCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 13,
                Name = "Assorted Hard Candy",
                Price = 3.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\hardCandy-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 14,
                Name = "Assorted Hard Candy",
                Price = 2.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\hardCandy2-small.jpg",
                IsInStock = false,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 15,
                Name = "Assorted Hard Candy",
                Price = 5.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\hardCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });



            //Orders
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 1,
                FirstName = "Peter",
                LastName = "D. Murphy",
                PhoneNumber = "720-323-6178",
                Address = "547 Davis Lane",
                City = "Denver",
                State = "Alabama",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 04, 24),
                OrderTotal = 118.75M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 2,
                FirstName = "Stella",
                LastName = "S. McElroy",
                PhoneNumber = "941-468-9331",
                Address = "2389 Medical Center Drive",
                City = "Denver",
                State = "Alabama",
                ZipCode = "33610",
                OrderPlaced = new DateTime(2022, 04, 24),
                OrderTotal = 59.4M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 3,
                FirstName = "John",
                LastName = "N. Jeffers",
                PhoneNumber = "925-439-8682",
                Address = "1078 Park Street",
                City = "Pittsburg",
                State = "California",
                ZipCode = "94565",
                OrderPlaced = new DateTime(2022, 04, 24),
                OrderTotal = 128.5M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 4,
                FirstName = "Joseph",
                LastName = " A. Schultz",
                PhoneNumber = "530-328-0168",
                Address = "4104 Riverwood Drive",
                City = "Pittsburg",
                State = "California",
                ZipCode = "95814",
                OrderPlaced = new DateTime(2022, 04, 25),
                OrderTotal = 114.55M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 5,
                FirstName = "Eunice",
                LastName = "T. Stroud",
                PhoneNumber = "774-563-0433",
                Address = "827 Kennedy Court",
                City = "Pittsburg",
                State = "California",
                ZipCode = "02132",
                OrderPlaced = new DateTime(2022, 04, 25),
                OrderTotal = 146.75M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 6,
                FirstName = "Robert",
                LastName = "A. McDonald",
                PhoneNumber = "757-548-3726",
                Address = "3897 Allison Avenue",
                City = "Denver",
                State = "Alabama",
                ZipCode = "23320",
                OrderPlaced = new DateTime(2022, 04, 26),
                OrderTotal = 157.45M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 7,
                FirstName = "Rosie",
                LastName = "J. Fails",
                PhoneNumber = "281-834-4587",
                Address = "2886 Grey Fox Farm Road",
                City = "Pittsburg",
                State = "California",
                ZipCode = "77520",
                OrderPlaced = new DateTime(2022, 04, 26),
                OrderTotal = 139.35M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 8,
                FirstName = "Antonio",
                LastName = "C. Real",
                PhoneNumber = "610-422-3906",
                Address = "3223 Stone Lane",
                City = "Pittsburg",
                State = "California",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 04, 26),
                OrderTotal = 148.35M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 9,
                FirstName = "Walter",
                LastName = "K. Clark",
                PhoneNumber = "209-762-7688",
                Address = "1233 Freed Drive",
                City = "Denver",
                State = "Alabama",
                ZipCode = "95204",
                OrderPlaced = new DateTime(2022, 04, 26),
                OrderTotal = 165.1M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 10,
                FirstName = "Keren",
                LastName = "R. Fields",
                PhoneNumber = "309-263-5674",
                Address = "1165 Apple Lane",
                City = "Denver",
                State = "Alabama",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 04, 27),
                OrderTotal = 167.6M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 11,
                FirstName = "Peter",
                LastName = "D. Murphy",
                PhoneNumber = "720-323-6178",
                Address = "547 Davis Lane",
                City = "Pittsburg",
                State = "California",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 04, 27),
                OrderTotal = 163.25M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 12,
                FirstName = "Keren",
                LastName = "R. Fields",
                PhoneNumber = "309-263-5674",
                Address = "1165 Apple Lane",
                City = "Denver",
                State = "Alabama",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 04, 28),
                OrderTotal = 173,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 13,
                FirstName = "Rosie",
                LastName = "J. Fails",
                PhoneNumber = "281-834-4587",
                Address = "2886 Grey Fox Farm Road",
                City = "Pittsburg",
                State = "California",
                ZipCode = "77520",
                OrderPlaced = new DateTime(2022, 04, 29),
                OrderTotal = 150.65M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 14,
                FirstName = "Peter",
                LastName = "D. Murphy",
                PhoneNumber = "720-323-6178",
                Address = "547 Davis Lane",
                City = "Denver",
                State = "Alabama",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 04, 29),
                OrderTotal = 149.05M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 15,
                FirstName = "Eunice",
                LastName = "T. Stroud",
                PhoneNumber = "774-563-0433",
                Address = "827 Kennedy Court",
                City = "Pittsburg",
                State = "California",
                ZipCode = "02132",
                OrderPlaced = new DateTime(2022, 04, 29),
                OrderTotal = 168.3M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 16,
                FirstName = "Peter",
                LastName = "D. Murphy",
                PhoneNumber = "720-323-6178",
                Address = "547 Davis Lane",
                City = "Pittsburg",
                State = "California",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 04, 30),
                OrderTotal = 138.9M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 17,
                FirstName = "Peter",
                LastName = "D. Murphy",
                PhoneNumber = "720-323-6178",
                Address = "547 Davis Lane",
                City = "Pittsburg",
                State = "California",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 05, 01),
                OrderTotal = 178.2M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 18,
                FirstName = "Keren",
                LastName = "R. Fields",
                PhoneNumber = "309-263-5674",
                Address = "1165 Apple Lane",
                City = "Denver",
                State = "Alabama",
                ZipCode = "80216",
                OrderPlaced = new DateTime(2022, 05, 01),
                OrderTotal = 173.75M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 19,
                FirstName = "Rosie",
                LastName = "J. Fails",
                PhoneNumber = "281-834-4587",
                Address = "2886 Grey Fox Farm Road",
                City = "Pittsburg",
                State = "California",
                ZipCode = "95204",
                OrderPlaced = new DateTime(2022, 05, 01),
                OrderTotal = 181.7M,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 20,
                FirstName = "Eunice",
                LastName = "T. Stroud",
                PhoneNumber = "774-563-0433",
                Address = "827 Kennedy Court",
                City = "Pittsburg",
                State = "California",
                ZipCode = "02132",
                OrderPlaced = new DateTime(2022, 05, 02),
                OrderTotal = 123.9M,
            });


            //orderdetails
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 1, OrderId = 1, CandyId = 1, Amount = 20, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 2, OrderId = 1, CandyId = 2, Amount = 5, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 3, OrderId = 2, CandyId = 1, Amount = 16, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 4, OrderId = 3, CandyId = 3, Amount = 15, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 5, OrderId = 3, CandyId = 6, Amount = 10, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 6, OrderId = 3, CandyId = 12, Amount = 5, Price = 6.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 7, OrderId = 4, CandyId = 10, Amount = 29, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 8, OrderId = 5, CandyId = 3, Amount = 14, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 9, OrderId = 5, CandyId = 14, Amount = 24, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10, OrderId = 5, CandyId = 1, Amount = 7, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 12, OrderId = 6, CandyId = 10, Amount = 10, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 13, OrderId = 6, CandyId = 12, Amount = 7, Price = 6.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 14, OrderId = 6, CandyId = 1, Amount = 8, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 15, OrderId = 6, CandyId = 6, Amount = 6, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 16, OrderId = 7, CandyId = 2, Amount = 30, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 17, OrderId = 7, CandyId = 12, Amount = 3, Price = 6.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 18, OrderId = 8, CandyId = 10, Amount = 15, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 19, OrderId = 8, CandyId = 9, Amount = 18, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 20, OrderId = 9, CandyId = 4, Amount = 15, Price = 6.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 21, OrderId = 9, CandyId = 14, Amount = 15, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 22, OrderId = 9, CandyId = 10, Amount = 13, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 23, OrderId = 10, CandyId = 14, Amount = 35, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 24, OrderId = 10, CandyId = 1, Amount = 13, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 25, OrderId = 11, CandyId = 3, Amount = 20, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 26, OrderId = 11, CandyId = 12, Amount = 15, Price = 6.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 27, OrderId = 12, CandyId = 2, Amount = 25, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 28, OrderId = 12, CandyId = 6, Amount = 15, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 29, OrderId = 13, CandyId = 14, Amount = 35, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 30, OrderId = 13, CandyId = 10, Amount = 12, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 31, OrderId = 14, CandyId = 3, Amount = 22, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 32, OrderId = 14, CandyId = 6, Amount = 17, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 33, OrderId = 15, CandyId = 9, Amount = 34, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 34, OrderId = 16, CandyId = 10, Amount = 15, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 35, OrderId = 16, CandyId = 3, Amount = 27, Price = 2.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 36, OrderId = 17, CandyId = 1, Amount = 17, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 37, OrderId = 17, CandyId = 6, Amount = 7, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 38, OrderId = 17, CandyId = 9, Amount = 12, Price = 4.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 39, OrderId = 18, CandyId = 12, Amount = 25, Price = 6.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 40, OrderId = 19, CandyId = 2, Amount = 17, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 41, OrderId = 19, CandyId = 10, Amount = 29, Price = 3.95M });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 42, OrderId = 20, CandyId = 14, Amount = 42, Price = 2.95M });


            //Seed admin role and user
            SeedAdminUser(modelBuilder);
            SeedAdminRole(modelBuilder);
            SeedAdminUserRole(modelBuilder);
        }


        private void SeedAdminUser(ModelBuilder builder)
        {
            var adminUser = new IdentityUser
            {
                Id = "1",
                UserName = "admin@admin.se",
                NormalizedUserName = "ADMIN@ADMIN.SE",
                Email = "admin@admin.se",
                NormalizedEmail = "ADMIN@ADMIN.SE"
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            var password = passwordHasher.HashPassword(adminUser, "admin");
            adminUser.PasswordHash = password;
            builder.Entity<IdentityUser>().HasData(adminUser);
        }

        private void SeedAdminRole(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "Admin"
            });
        }

        private void SeedAdminUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            });
        }
    }
}
