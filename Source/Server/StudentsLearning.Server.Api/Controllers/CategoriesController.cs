namespace StudentsLearning.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentsLearning.Data;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data;
    using StudentsLearning.Services.Data.Contracts;
    using Models;
    using System.Web.Http.Cors;

    [RoutePrefix("api/Categories")]
    [EnableCors("*", "*", "*")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categories = categoryService;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.categories.All().ToList());
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(this.categories.GetById(id));
        }

        // TODO: [note] The update of the sections list will be done in post / delete in SectionsController through the foreign key automaticly
        public IHttpActionResult Put(int id, [FromBody]CategoryRequestModel updates)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var updatedCategory = this.categories.GetById(id);

            if (this.categories.GetId(updates.Name) != 0)
            {
                return this.BadRequest();
            }

            updatedCategory.Name = updates.Name;
            this.categories.Update(updatedCategory);

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] string name)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.categories.Add(name);
            return this.Ok(this.categories.GetId(name));
        }
    }
}