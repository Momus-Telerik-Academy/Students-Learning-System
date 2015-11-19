namespace StudentsLearning.Services.Data.Contracts
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;

    #endregion

    public interface IExamplesService
    {
        IQueryable<Example> All();

        IQueryable<Example> GetById(int id);

        void Add(Example example);

        void Update(Example example);

        void Delete(int id);
    }
}