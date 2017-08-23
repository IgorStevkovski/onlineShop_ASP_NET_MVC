namespace MySQLConnectionDemo.Migrations
{
    using MySQLConnectionDemo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MySQLConnectionDemo.Models.ProdavnicaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(MySQLConnectionDemo.Models.ProdavnicaDbContext context)
        {
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

            var tipovi = new List<Tip>{
                new Tip {Ime = "BelaTehnika" },
                new Tip {Ime = "Hrana"}
            };
            foreach (var temp in tipovi)
            {
                context.Tipovi.Add(temp);
            }
            context.SaveChanges();
        }
    }
}
