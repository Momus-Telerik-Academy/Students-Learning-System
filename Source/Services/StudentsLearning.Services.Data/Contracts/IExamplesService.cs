namespace StudentsLearning.Services.Data.Contracts
{
    using System.Linq;

    using StudentsLearning.Data.Models;

    public interface IExamplesService
    {
        IQueryable<Example> All();

        IQueryable<Example> GetById(int id);

        void Add(Example example);

        void Update(Example example);
    }
}
