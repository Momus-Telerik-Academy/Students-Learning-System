namespace StudentsLearning.Server.Api.Controllers
{
    using Services.Data.Contracts;
    using Models;
    using System.Linq;
    using System.Web.Http;

    public class TopicController : ApiController
    {
        private readonly ITopicsServices topics;
        private readonly IZipFilesService zipFiles;

        public TopicController(ITopicsServices topics, IZipFilesService zipFiles)
        {
            this.topics = topics;
           // this.zipFiles = zipFiles;
        }

        [HttpGet]
        public IHttpActionResult Get(int sectionId, int page = 1, int pageSize = 10)
        {
            var result =
                this.topics
                .All(sectionId, page, pageSize)
                .Select(x => new TopicResponseModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    VideoId = x.VideoId,
                    SectionId = x.SectionId,
                   // ZipFileId = x.ZipFileId,
                    Comments = x.Comments
                                .Select(c => new CommentResponseModel
                                {
                                    Id = c.Id,
                                    Author = c.Author,
                                    Content = c.Content,
                                    Dislikes = c.Dislikes,
                                    Likes = c.Likes,
                                    TopicId = c.TopicId

                                }).ToList(),
                    Examples = x.Examples
                              .Select(e => new ExampleResponseModel
                              {
                                  Content = e.Content,
                                  Description = e.Description,
                                  Id = e.Id,
                                  TopicId = e.TopicId
                              }).ToList()

                });
            return this.Ok(result);
        }

        //[HttpPost]
        //public IHttpActionResult Post(TopicRequestModel topic)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    if (this.artists.GetById(requestSong.ArtistId) == null)
        //    {
        //        return this.BadRequest("The artist doesn't exist");
        //    }
        //}
    }
}