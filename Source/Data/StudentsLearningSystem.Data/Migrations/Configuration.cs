namespace StudentsLearning.Data.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsLearning.Data.StudentsLearningDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsLearning.Data.StudentsLearningDbContext context)
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

            //var cukiUser = new CustomUser
            //{
            //    UserName = "Cuki"
            //};

            //var peshoUser = new CustomUser
            //{
            //    UserName = "Pesho"
            //};

            //context.Users.AddOrUpdate(cukiUser);
            //context.Users.AddOrUpdate(peshoUser);

            var programming = new Category() { Name = "Programming" };

            programming.Sections
                .Add(new Section()
                {
                    Name = "Algorithms",
                    Description = "Algorithms Lorem Ipsum Dolor",
                    Topics = new HashSet<Topic> {
                        new Topic() {
                            Title = "Graphs",
                            Content ="Graph algorithms article. Graphs are this and that",
                            Comments = new HashSet<Comment>
                            {
                                new Comment() {UserId="09bea2be-d614-490c-939d-1a562f4fd89e", Content="I have learned that when I was 2 years old.. ", Likes=2, Dislikes = 0 },
                                new Comment() {UserId="4dac58c0-e459-47c7-9e55-f4f15d0e66b7", Content="Sad panda", Likes=3, Dislikes = 0 }
                            },
                            Examples = new HashSet<Example>
                            {
                                new Example() { Description = "Graph example", Content="some content"},
                                new Example() { Description = "Algo Academy 2012 Task 1", Content="some content"}
                            },
                          VideoId="Xr21-vMs_XM"
                        },

                    }
                });

            context.Categories.AddOrUpdate(
                c => c.Name,
               programming
                );
        }
    }
}
