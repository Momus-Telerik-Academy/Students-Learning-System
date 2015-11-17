namespace StudentsLearning.Server.Api.Controllers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Microsoft.AspNet.Identity;

    using Models.CommentTransferModels;
    using Models.ExampleTransferModels;
    using Services.Data.Contracts;
    using Services.GoogleDrive.Contracts;
    using Services.GoogleDrive.Models;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Server.Api.Models.ContributorTransferModels;
    using StudentsLearning.Server.Api.Models.TopicTransferModels;
    using StudentsLearning.Server.Api.Models.ZipFileTransferModels;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;

    [RoutePrefix("api/Topics")]
    [EnableCors("*", "*", "*")]
    public class TopicsController : ApiController
    {
        private readonly ITopicsServices topics;

        private readonly IZipFilesService zipFiles;

        private readonly ISectionService sections;

        private readonly IExamplesService examples;

        private readonly IUsersService users;

        private readonly ICloudStorageService cloudStorage;

        public TopicsController(ITopicsServices topics, IZipFilesService zipFiles, ISectionService sections, IExamplesService examples, IUsersService usersService, ICloudStorageService drive)
        {
            this.topics = topics;
            this.sections = sections;
            this.examples = examples;
            this.zipFiles = zipFiles;
            this.users = usersService;
            this.cloudStorage = drive;
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
                Comments =
                                      topic.Comments.Select(
                                          c =>
                                          new CommentResponseModel
                                          {
                                              Id = c.Id,
                                              Username = this.users.GetUserById(c.UserId).FirstOrDefault().UserName,
                                              Content = c.Content,
                                              Dislikes = c.Dislikes,
                                              Likes = c.Likes,
                                              TopicId = c.TopicId
                                          }).ToList(),
                ZipFiles =
                                      topic.ZipFiles.Select(
                                          z =>
                                          new ZipFileResponseModel
                                          {
                                              DbName = z.DbName,
                                              OriginalName = z.OriginalName,
                                              Path = z.Path,
                                              TopicId = z.TopicId
                                          }).ToList(),
                Examples =
                                      topic.Examples.Select(
                                          e =>
                                          new ExampleResponseModel
                                          {
                                              Content = e.Content,
                                              Description = e.Description,
                                              Id = e.Id,
                                              TopicId = e.TopicId
                                          }).ToList(),
                Contributors =
                                      topic.Contributors.Select(
                                          c =>
                                          new ContributorResponseModel
                                          {
                                              Id = c.Id,
                                              UserName = c.UserName
                                          })
                                      .ToList()
            };

            return this.Ok(respone);
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
  "zipFiles":[{
    "originalName":"originalName1",
    "dbName":"dbName1",
    "path":"path"
  }]
}      */
        //TODO:Check if the current category exist and if exist do not let the user the make the same category twice

        [Authorize]
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

            var topic = Mapper.Map<TopicRequestModel, Topic>(requestTopic);

            var newContributor = this.users.GetUserById(this.User.Identity.GetUserId()).FirstOrDefault();

            this.topics.Add(topic, newContributor);

            return this.Ok(topic.Id);
        }

        [Authorize]
        public IHttpActionResult Put(int id, TopicRequestModel requestTopic)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var topic = this.topics.GetById(id).FirstOrDefault();

            if (topic == null)
            {
                return this.BadRequest();
            }

            Func<ExampleRequestModel, Example> mapToExample = c =>
            {
                var example = this.examples.GetById(c.Id).FirstOrDefault();

                if (example == null)
                {
                    example = new Example { Id = c.Id };
                }

                example.Description = c.Description;
                example.Content = c.Content;

                this.examples.Update(example);
                return example;
            };

            topic.Title = requestTopic.Title;
            topic.Content = requestTopic.Content;
            topic.VideoId = requestTopic.VideoId;
            topic.Examples = requestTopic.Examples.Select(mapToExample).ToList();

            if (!topic.Contributors.Any(c => c.Id == this.User.Identity.GetUserId()))
            {
                topic.Contributors.Add(this.users.GetUserById(this.User.Identity.GetUserId()).FirstOrDefault());
            }

            this.topics.Update(topic);

            return this.Ok();
        }

        [HttpPut]
        [Route("upload/{topicId}")]
        public async Task<IHttpActionResult> Put(int topicId, HttpRequestMessage upload)
        {
            var provider = new MultipartMemoryStreamProvider();

            await upload.Content.ReadAsMultipartAsync(provider);

            foreach (var file in provider.Contents)
            {
                string name = file.Headers.ContentDisposition.FileName;

                if (name == null)
                {
                    return this.BadRequest("Empty file");
                }

                var stream = await file.ReadAsStreamAsync();

                Console.WriteLine();

                ZipFileGoogleDriveResponseModel response = this.cloudStorage.Upload(new ZipFileGoogleDriveRequestModel { OriginalName = name, Content = stream });
                // TODO: Change evereywhere DbName to GoogleDriveId ?
                try
                {
                    this.zipFiles.Add(new ZipFile() { OriginalName = name, Path = response.DownloadLink, DbName = response.Id, TopicId = topicId });
                }

                catch (System.Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
            }

            return this.Ok();
        }
    }
}