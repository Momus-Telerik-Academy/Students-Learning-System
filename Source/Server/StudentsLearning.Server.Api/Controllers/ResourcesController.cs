namespace StudentsLearning.Server.Api.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Http;

    [RoutePrefix("api/Resources")]
    public class ResourcesController : ApiController
    {
        private readonly IZipFilesService zipFiles;

        public ResourcesController(IZipFilesService zipFiles)
        {
            this.zipFiles = zipFiles;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            this.zipFiles.Delete(id);
            return this.Ok();
        }
    }
}