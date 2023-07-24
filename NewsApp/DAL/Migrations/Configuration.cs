namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.NewsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            string[] cats = new string[] {"Sports","International Affairs","Business","Entertainment","Health","Tech" };
            foreach (var c in cats) {
                context.Categories.AddOrUpdate(new EF.Models.Category { Name = c }) ;
            }
            Random random = new Random();
            for (int i = 1; i < 101; i++) {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                 
                context.News.AddOrUpdate(
                    new EF.Models.News() { 
                        Title = Guid.NewGuid().ToString(),
                        Date = start.AddDays(random.Next(range)),
                        CId = random.Next(1,7)

                        }
                    );
            }
        }
    }
}
