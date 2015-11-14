﻿namespace StudentsLearning.Server.Api.Controllers
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Models.CommentTransferModels;
    using Models.ExampleTransferModels;
    using Services.Data.Contracts;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Server.Api.Models.ContributorTransferModels;
    using StudentsLearning.Server.Api.Models.TopicTransferModels;
    using StudentsLearning.Server.Api.Models.ZipFileTransferModels;
    using System;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/Topics")]
    [EnableCors("*", "*", "*")]
    public class TopicsController : ApiController
    {
        private readonly ITopicsServices topics;
        private readonly IZipFilesService zipFiles;

        private readonly ISectionService sections;

        private readonly IExamplesService examples;

        private readonly IUsersService users;

        public TopicsController(ITopicsServices topics, IZipFilesService zipFiles, ISectionService sections, IExamplesService examples, IUsersService usersService)
        {
            this.topics = topics;
            this.sections = sections;
            this.examples = examples;
            this.zipFiles = zipFiles;
            this.users = usersService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var topic = this.topics.GetById(id).FirstOrDefault();
            var topicC = topic.Contributors;
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
                Comments = topic.Comments
                                .Select(c => new CommentResponseModel
                                {
                                    Id = c.Id,
                                    UserId = c.UserId,
                                    Content = c.Content,
                                    Dislikes = c.Dislikes,
                                    Likes = c.Likes,
                                    TopicId = c.TopicId
                                })
                                .ToList(),
                ZipFiles = topic.ZipFiles
                                .Select(z => new ZipFileResponseModel
                                {
                                    DbName = z.DbName,
                                    OriginalName = z.OriginalName,
                                    Path = z.Path,
                                    TopicId = z.TopicId
                                }).ToList(),
                Examples = topic.Examples
                              .Select(e => new ExampleResponseModel
                              {
                                  Content = e.Content,
                                  Description = e.Description,
                                  Id = e.Id,
                                  TopicId = e.TopicId
                              }).ToList(),
                Contributors = topic.Contributors
                                .Select(c => new ContributorResponseModel
                                {
                                    Id = c.Id,
                                    UserName = c.UserName
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
                    ZipFiles = x.ZipFiles
                                .Select(c => new ZipFileResponseModel
                                {
                                    DbName = c.DbName,
                                    OriginalName = c.OriginalName,
                                    Path = c.Path,
                                    TopicId = c.TopicId
                                }).ToList(),
                    Comments = x.Comments
                                .Select(c => new CommentResponseModel
                                {
                                    Id = c.Id,
                                    UserId = c.UserId,
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
  "zipFiles":[{
    "originalName":"originalName1",
    "dbName":"dbName1",
    "path":"path"
  }]
}      */
        //TODO:Check if the current category exist and if exist do not let the user the make the same category twice
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

            var topic = new Topic()
            {
                Content = requestTopic.Content,
                SectionId = requestTopic.SectionId,
                Title = requestTopic.Title,
                VideoId = requestTopic.VideoId
            };

            var newZipFiles = new Collection<ZipFile>();
            foreach (var zipFile in requestTopic.ZipFiles)
            {
                var newFile = new ZipFile
                {
                    DbName = zipFile.DbName,
                    OriginalName = zipFile.OriginalName,
                    Path = zipFile.Path,
                    Topic = topic
                };
                newZipFiles
                    .Add(newFile);
            }

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

            var newContributor = this.users.GetUserById(this.User.Identity.GetUserId());
            this.topics
                 .Add(topic, newZipFiles, newExamples, newContributor);

            return this.Ok();
        }

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
            // topic.ZipFiles = requestTopic.ZipFiles;

            this.topics.Update(topic);

            return this.Ok();
        }
    }
}