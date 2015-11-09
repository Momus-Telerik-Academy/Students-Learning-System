namespace StudentsLearning.Services.Data
{
    using System.Linq;
    using Contracts;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categories;

        public CategoryService(
            IRepository<Category> categoriesRepository)
        {
            this.categories = categoriesRepository;
        }

        public void Add(string name)
        {
            this.categories.Add(new Category() { Name = name });
            this.categories.SaveChanges();
        }

        public IQueryable<Category> All()
        {
            return this.categories.All();
        }

        public int? GetId(string name)
        {
            return this.categories.All()
                .Where(x => x.Name == name)
                .Select(c => c.Id)
                .FirstOrDefault();
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public void Update(Category category)
        {
            this.categories.Update(category);
            this.categories.SaveChanges();
        }
    }
}
