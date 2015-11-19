namespace StudentsLearning.Server.Api.Controllers
{
    #region

    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using AutoMapper;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Server.Api.Models;
    using StudentsLearning.Server.Api.Models.SectionTransferModels;
    using StudentsLearning.Services.Data.Contracts;
    using System.Collections.Generic;

    using StudentsLearning.Server.Api.Infrastructure.Filters;

    #endregion

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
            var sections = this.sections.All().ToList();

            var response =
                 Mapper.Map<IEnumerable<Section>, IEnumerable<SectionResponseMinifiedModel>>(sections);

            return this.Ok(response);
        }

        public IHttpActionResult Get(int id)
        {
            Section section = this.sections.GetById(id).FirstOrDefault();
            SectionResponseModel response = Mapper.Map<Section, SectionResponseModel>(section);

            return this.Ok(response);
        }

        [ValidateModelState]
        [CheckNull]
        public IHttpActionResult Put(int id, [FromBody] SectionRequestModel updates)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSection = new Section
            {
                Id = id,
                Name = updates.Name,
                Description = updates.Description,
                CategoryId = updates.CategoryId
            };

            this.sections.Update(newSection);

            return this.Ok();
        }

        [HttpPost]
        [ValidateModelState]
        [CheckNull]
        public IHttpActionResult Post([FromBody] SectionRequestModel sectionModel)
        {
            var section = Mapper.Map<SectionRequestModel, Section>(sectionModel);

            this.sections.Add(section);
            return this.Ok(section);
        }
    }
}