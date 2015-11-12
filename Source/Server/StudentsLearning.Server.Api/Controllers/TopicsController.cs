namespace StudentsLearning.Server.Api.Controllers
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Models.CommentTransferModels;
    using Models.ExampleTransferModels;
    using Services.Data.Contracts;
    using StudentsLearning.Data.Models;

    using StudentsLearning.Server.Api.Models.TopicTransferModels;
    using StudentsLearning.Server.Api.Models.ZipFileTransferModels;

    [RoutePrefix("api/Topics")]
    [EnableCors("*", "*", "*")]
    public class TopicsController : ApiController
    {
        private readonly ITopicsServices topics;
        private readonly IZipFilesService zipFiles;

        private readonly ISectionService sections;

        private readonly IExamplesService examples;

        public TopicsController(ITopicsServices topics, IZipFilesService zipFiles, ISectionService sections, IExamplesService examples)
        {
            this.topics = topics;
            this.sections = sections;
            this.examples = examples;
            this.zipFiles = zipFiles;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var topic = this.topics.GetById(id).FirstOrDefault();

            if (topic == null)
            {
                return this.BadRequest();
            }
            var respone = new TopicResponseModel
            {
                Id = topic.Id,
                Title = topic.Title,
                Content = topic.Content,
                VideoId = topic.VideoId,
                ZipFile = new ZipFileResponseModel
                {
                    TopicId = topic.Id,
                    Path = topic.ZipFile.Path,
                    DbName = topic.ZipFile.DbName,
                    OriginalName = topic.ZipFile.OriginalName,
                },
                Comments = topic.Comments
                                .Select(c => new CommentResponseModel
                                {
                                    Id = c.Id,
                                    Author = c.Author,
                                    Content = c.Content,
                                    Dislikes = c.Dislikes,
                                    Likes = c.Likes,
                                    TopicId = c.TopicId
                                })
                                .ToList(),
                Examples = topic.Examples
                              .Select(e => new ExampleResponseModel
                              {
                                  Content = e.Content,
                                  Description = e.Description,
                                  Id = e.Id,
                                  TopicId = e.TopicId
                              }).ToList(),

            };
            return this.Ok(respone);
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
                    ZipFile = new ZipFileResponseModel
                    {
                        TopicId = x.Id,
                        Path = x.ZipFile.Path,
                        DbName = x.ZipFile.DbName,
                        OriginalName = x.ZipFile.OriginalName,
                    },
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
                              })
                              .ToList()
                });
            return this.Ok(result);
        }

        //http://localhost:56350/api/Topics
        //body example:
        /*

       {
  "title":"neshto",
  "content":"neshto1",
  "videoId":"ssidhs",
  "sectionId":"1",
  "examples":[
    {
      "description":"description",
      "content":"secitonContent",
          }
  ],
  "zipFile":{
    "originalName":"originalName1",
    "dbName":"dbName1",
    "path":"path"
  }
}       */
        [HttpPost]
        public IHttpActionResult Post(TopicRequestModel requestTopic)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.sections.GetById(requestTopic.SectionId) == null)
            {
                return this.BadRequest("The section id doesn't exist");
            }

            var topic = new Topic
            {
                Content = requestTopic.Content,
                SectionId = requestTopic.SectionId,
                Title = requestTopic.Title,
                VideoId = requestTopic.VideoId,

            };
            var zipFile = new ZipFile
            {
                DbName = requestTopic.ZipFile.DbName,
                OriginalName = requestTopic.ZipFile.OriginalName,
                Path = requestTopic.ZipFile.Path,
            };
            var newExamples = new Collection<Example>();
            foreach (var example in requestTopic.Examples)
            {
                var newExample = new Example
                {
                    Content = example.Content,
                    Description = example.Description,
                    Topic = topic
                };
                newExamples
                    .Add(newExample);
            }

            this.topics
                .Add(topic, zipFile, newExamples);

            return this.Ok();
        }
    }
}