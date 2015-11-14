namespace StudentsLearning.Data
{
    #region

    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    #endregion

    public interface IStudentsLearningDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}