namespace StudentsLearning.Services.Data
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;

    #endregion

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categories = categoriesRepository;
        }

        public void Add(string name)
        {
            this.categories.Add(new Category { Name = name });
            this.categories.SaveChanges();
        }

        public IQueryable<Category> All()
        {
            return this.categories.All();
        }

        public int? GetId(string name)
        {
            return this.categories.All().Where(x => x.Name == name).Select(c => c.Id).FirstOrDefault();
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

       public void Delete(int id)
        {
           var category =  this.categories.GetById(id);

            if(category != null)
            {
                this.categories.Delete(category);
                this.categories.SaveChanges();
            }
        }
    }
}