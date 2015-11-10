namespace StudentsLearning.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using StudentsLearning.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> All();

        Category GetById(int id);

        int? GetId(string name);

        void Add(string category);

        void Update(Category category);
    }
}
