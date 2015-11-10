namespace StudentsLearning.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Data.Models;
    using Models;
    using Services.Data.Contracts;

    [RoutePrefix("api/Sections")]
    [EnableCors("*", "*", "*")]
    public class SectionsController : ApiController
    {
        private readonly ISectionService sections;

        public SectionsController(ISectionService sectionService)
        {
            this.sections = sectionService;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.sections.All().ToList());
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(this.sections.GetById(id));
        }

        // TODO: [note] The update of the sections list will be done in post / delete in SectionsController through the foreign key automaticly
        public IHttpActionResult Put(int id, [FromBody]SectionRequestModel updates)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var updatedSection = this.sections.GetById(id);

            if (this.sections.GetId(updates.Name) != 0)
            {
                return this.BadRequest();
            }
            
            // var newSection = new Section
            // {
            //     Name = updates.Name,
            //     Description = updates.Description,
            //     CategoryId = updates.CategoryId
            // };

            updatedSection.Name = updates.Name;
            updatedSection.Description = updates.Description;

            this.sections.Update(updatedSection);

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] SectionRequestModel sectionModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var section = new Section
            {
                Name = sectionModel.Name,
                Description = sectionModel.Description,
                CategoryId = sectionModel.CategoryId
            };

            this.sections.Add(section);
            return this.Ok(this.sections.GetId(section.Name));
        }
    }
}