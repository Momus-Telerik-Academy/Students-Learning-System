namespace StudentsLearning.Data.Migrations
{
    #region

    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using StudentsLearning.Data.Models;

    #endregion

    public sealed class Configuration : DbMigrationsConfiguration<StudentsLearningDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsLearningDbContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );

            // var cukiUser = new CustomUser
            // {
            // UserName = "Cuki"
            // };

            // var peshoUser = new CustomUser
            // {
            // UserName = "Pesho"
            // };

            // context.Users.AddOrUpdate(cukiUser);
            // context.Users.AddOrUpdate(peshoUser);
            var programming = new Category { Name = "Programming" };

            programming.Sections.Add(
                new Section
                    {
                        Name = "Algorithms", 
                        Description = "Algorithms Lorem Ipsum Dolor", 
                        Topics =
                            new HashSet<Topic>
                                {
                                    new Topic
                                        {
                                            Title = "Graphs", 
                                            Content =
                                                "Graph algorithms article. Graphs are this and that", 
                                            Examples =
                                                new HashSet<Example>
                                                    {
                                                        new Example
                                                            {
                                                                Description
                                                                    =
                                                                    "Graph example", 
                                                                Content
                                                                    =
                                                                    "some content"
                                                            }, 
                                                        new Example
                                                            {
                                                                Description
                                                                    =
                                                                    "Algo Academy 2012 Task 1", 
                                                                Content
                                                                    =
                                                                    "some content"
                                                            }
                                                    }, 
                                            VideoId = "Xr21-vMs_XM"
                                        }
                                }
                    });

            context.Categories.AddOrUpdate(c => c.Name, programming);
        }
    }
}