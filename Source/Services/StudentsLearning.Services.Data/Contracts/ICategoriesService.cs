namespace StudentsLearning.Services.Data.Contracts
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;

    #endregion

    public interface ICategoriesService
    {
        IQueryable<Category> All();

        Category GetById(int id);

        int? GetId(string name);

        void Add(string category);

        void Update(Category category);

        void Delete(int id);
    }
}