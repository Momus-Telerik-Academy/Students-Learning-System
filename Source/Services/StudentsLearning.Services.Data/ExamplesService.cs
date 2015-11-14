namespace StudentsLearning.Services.Data
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;

    #endregion

    public class ExamplesService : IExamplesService
    {
        private readonly IRepository<Example> examples;

        public ExamplesService(IRepository<Example> examples)
        {
            this.examples = examples;
        }

        public IQueryable<Example> All()
        {
            return this.examples.All();
        }

        public IQueryable<Example> GetById(int id)
        {
            return this.examples.All().Where(x => x.Id == id);
        }

        public void Add(Example example)
        {
            this.examples.Add(example);
            this.examples.SaveChanges();
        }

        public void Update(Example example)
        {
            this.examples.Update(example);
            this.examples.SaveChanges();
        }
    }
}