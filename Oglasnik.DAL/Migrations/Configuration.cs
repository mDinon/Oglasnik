namespace Oglasnik.DAL.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Oglasnik.DAL.OglasnikDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Oglasnik.DAL.OglasnikDbContext context)
        {

            context.Currencies.AddOrUpdate(c => c.ID,
                new Currency() { ID = 1, Name = "HRK", DateCreated = DateTime.Now },
                new Currency() { ID = 2, Name = "EUR", DateCreated = DateTime.Now },
                new Currency() { ID = 3, Name = "USD", DateCreated = DateTime.Now });

            context.Categories.AddOrUpdate(c => c.ID,
                new Category() { ID = 1, Name = "Auti", DateCreated = DateTime.Now },
                new Category() { ID = 2, Name = "Ljubimci", DateCreated = DateTime.Now },
                new Category() { ID = 3, Name = "Ostalo", DateCreated = DateTime.Now });

            context.Ads.AddOrUpdate(a => a.ID,
                new Ad() { ID = 1, Name = "Prodajem auto", DateCreated = DateTime.Now, Category_ID = 1, Currency_ID = 2, IsNew = false, Price = 5000, User_ID = "6fbfbc5e-f8c6-45c4-a869-1bc366239641" },
                new Ad() { ID = 2, Name = "Prodajem macku", DateCreated = DateTime.Now, Category_ID = 2, Currency_ID = 1, IsNew = true, Price = 7000, User_ID = "6fbfbc5e-f8c6-45c4-a869-1bc366239641" },
                new Ad() { ID = 3, Name = "Prodajem mobitel", DateCreated = DateTime.Now, Category_ID = 3, Currency_ID = 1, IsNew = false, Price = 1000, User_ID = "6fbfbc5e-f8c6-45c4-a869-1bc366239641" });

            context.AdDetails.AddOrUpdate(a => a.ID,
                new AdDetails() { ID = 1, Detail = "Fiat Punto plave boje", DateCreated = DateTime.Now, Ad_ID = 1, },
                new AdDetails() { ID = 2, Detail = "150 konja", DateCreated = DateTime.Now, Ad_ID = 1 },
                new AdDetails() { ID = 3, Detail = "Diesel", DateCreated = DateTime.Now, Ad_ID = 1 },
                new AdDetails() { ID = 4, Detail = "Maine Coon", DateCreated = DateTime.Now, Ad_ID = 2 },
                new AdDetails() { ID = 5, Detail = "Samsung Galaxy S8", DateCreated = DateTime.Now, Ad_ID = 3 });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
