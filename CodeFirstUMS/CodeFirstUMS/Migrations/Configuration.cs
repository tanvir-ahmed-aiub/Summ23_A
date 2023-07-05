namespace CodeFirstUMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstUMS.EF.UMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstUMS.EF.UMSContext context)
        {
            //for (int i = 1; i <= 10; i++) {
            //    context.Departments.AddOrUpdate(
            //            new EF.Models.Department() { 
            //                Name = "Department " + i
            //            }
            //        );
            //}
            Random rnd = new Random();
            /*for (int i = 1; i <= 100; i++) {
                context.Courses.AddOrUpdate(
                        new EF.Models.Course() { 
                            Name = "Course " + i,
                            OfferedBy = rnd.Next(1,11)
                        }
                    );
            }*/
            for (int i = 1; i <= 10000; i++) {
                context.Students.AddOrUpdate(
                        new EF.Models.Student() { 
                            Name = Guid.NewGuid().ToString().Substring(1,20),
                            DeptId = rnd.Next(1,11)
                        }
                    );
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
