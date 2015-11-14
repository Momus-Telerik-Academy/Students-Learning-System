namespace StudentsLearning.Server.Api.Controllers
{
    using Services.Data.Contracts;
    using Models.CommentTransferModels;
    using System.Linq;
    using System.Web.Http;
    using Data.Models;
    using System.Web.Http.Cors;

    [RoutePrefix("api/Commnets")]
    [EnableCors("*", "*", "*")]
    public class CommentsController : ApiController
    {
        private readonly ICommentService commnents;

        public CommentsController(ICommentService commnentService)
        {
            this.commnents = commnentService;
        }

        public IHttpActionResult Get()
        {
            var comments = this.commnents.All()
                               .Select(x => new CommentResponseModel
                               {
                                   UserId = x.UserId,
                                   Content = x.Content,
                                   Dislikes = x.Dislikes,
                                   Likes = x.Likes,
                                   TopicId = x.TopicId
                               })
                               .ToList();

            return this.Ok(comments);
        }

        public IHttpActionResult Get(int id)
        {
            var commentResult = this.commnents.GetById(id)
                                    .Select(x => new CommentResponseModel
                                    {
                                        UserId = x.UserId,
                                        Content = x.Content,
                                        Likes = x.Likes,
                                        Dislikes = x.Dislikes,
                                        TopicId = x.TopicId
                                    })
                                   .FirstOrDefault();

            return this.Ok(commentResult);
        }

        // TODO: [note] The update of the sections list will be done in post / delete in SectionsController through the foreign key automaticly
        public IHttpActionResult Put(int id, [FromBody]CommentRequestModel updates)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var newComment = new Comment
            {
                Id = id,
                UserId = updates.UserId,
                Content = updates.Content,
                Dislikes = updates.Dislikes,
                Likes = updates.Likes,
                TopicId = updates.TopicId
            };

            this.commnents.Update(newComment);

            return this.Ok(newComment);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CommentRequestModel commentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var comment = new Comment
            {
                UserId = commentModel.UserId,
                Content = commentModel.Content,
                Likes = 0,
                Dislikes = 0,
                TopicId = commentModel.TopicId
            };

            this.commnents.Add(comment);
            return this.Ok(comment);
        }
    }
}
