namespace StudentsLearning.Server.Api.Controllers
{
    using Services.Data.Contracts;
    using System.Linq;
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
            var zipfile = this.zipFiles.GetById(id).FirstOrDefault();

            if(zipfile == null)
            {
                return this.NotFound();
            }

            this.zipFiles.Delete(zipfile);
            return this.Ok();
        }
    }
}