﻿namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("marco.vinicio.ortiz@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Marco",
                    LastName = "Ortiz",
                    Email = "marco.vinicio.ortiz@gmail.com",
                    UserName = "marco.vinicio.ortiz@gmail.com"
                };

                var result = await this.userHelper.AddUserAsync(user, "123458");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user
                /*
                User = new User
                {
                    FirstName = "Marco",
                    LastName = "Ortiz",
                    Email = "marco.vinicio.ortiz@gmail.com",
                    UserName = "marco.vinicio.ortiz@gmail.com"
                }*/
            });
        }
    }

}
