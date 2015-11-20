namespace StudentsLearning.Server.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Microsoft.AspNet.Identity;
    using Models.ExampleTransferModels;
    using Services.Data.Contracts;
    using Services.GoogleDrive.Contracts;
    using Services.GoogleDrive.Models;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Server.Api.Models.TopicTransferModels;
    using AutoMapper;

    using StudentsLearning.Server.Api.Infrastructure.Filters;

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

            var response = Mapper.Map<Topic, TopicResponseModel>(topic);
            return this.Ok(response);
        }

       
        [Authorize]
        [HttpPost]
        [ValidateModelState]
        [CheckNull]
        public IHttpActionResult Post(TopicRequestModel requestTopic)
        {
            //if (!this.ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (this.sections.GetById(requestTopic.SectionId) == null)
            {
                return this.NotFound();
            }

            var topic = Mapper.Map<TopicRequestModel, Topic>(requestTopic);

            var newContributor = this.users.GetUserById(this.User.Identity.GetUserId()).FirstOrDefault();

            this.topics.Add(topic, newContributor);

            return this.Ok(topic.Id);
        }

        [Authorize]
        [ValidateModelState]
        [CheckNull]
        public IHttpActionResult Put(int id, TopicRequestModel requestTopic)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
                    return this.BadRequest("File cannot be empty");
                }

                var stream = await file.ReadAsStreamAsync();

              //  Console.WriteLine();

                ZipFileGoogleDriveResponseModel response =
                    this.cloudStorage.Upload(new ZipFileGoogleDriveRequestModel
                    {
                        OriginalName = name,
                        Content = stream
                    });

                try
                {
                    this.zipFiles.Add(new ZipFile() {
                        OriginalName = name,
                        Path = response.DownloadLink,
                        DbName = response.Id,
                        TopicId = topicId
                    });
                }

                catch (System.Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
            }

            return this.Ok();
        }

        [Authorize]
        [HttpDelete]
        [CheckNull]
        public IHttpActionResult Delete(int id)
        {
            var topic = this.topics.GetById(id).FirstOrDefault();

            if(topic == null)
            {
                return this.NotFound();
            }

            this.topics.Delete(topic);
            return this.Ok();
        }
    }
}