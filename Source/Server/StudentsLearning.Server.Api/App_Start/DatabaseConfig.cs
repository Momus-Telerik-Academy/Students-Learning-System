namespace StudentsLearning.Server.Api
{
    #region

    using System.Data.Entity;

    using StudentsLearning.Data;
    using StudentsLearning.Data.Migrations;

    #endregion

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsLearningDbContext, Configuration>());
            StudentsLearningDbContext.Create().Database.Initialize(true);
        }
    }
}