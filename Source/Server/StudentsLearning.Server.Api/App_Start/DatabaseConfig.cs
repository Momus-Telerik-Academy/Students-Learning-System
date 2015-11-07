namespace StudentsLearning.Server.Api
{
    using StudentsLearning.Data;
    using StudentsLearning.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsLearningDbContext, Configuration>());
            StudentsLearningDbContext.Create().Database.Initialize(true);
        }
    }
}