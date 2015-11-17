namespace StudentsLearning.Server.Api.Controllers
{
    #region

    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Microsoft.AspNet.Identity;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Server.Api.Models.CommentTransferModels;
    using StudentsLearning.Services.Data.Contracts;

    #endregion

    [RoutePrefix("api/Comments")]
    [EnableCors("*", "*", "*")]
    public class CommentsController : ApiController
    {
        private readonly ICommentService commnents;

        private readonly IUsersService users;

        public CommentsController(ICommentService commnentService, IUsersService users)
        {
            this.commnents = commnentService;
            this.users = users;
        }

        public IHttpActionResult Get()
        {
            var comments =
                this.commnents.All();

            var result = comments.Select(
                 x =>
                 new CommentResponseModel
                 {
                     Username = this.users.GetUserById(x.UserId).FirstOrDefault().UserName,
                     Content = x.Content,
                     Dislikes = x.Dislikes,
                     Likes = x.Likes,
                     TopicId = x.TopicId
                 })
             .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var commentResult =
                this.commnents.GetById(id)
                    .Select(
                        x =>
                        new CommentResponseModel
                        {
                            Username = x.UserId,
                            Content = x.Content,
                            Likes = x.Likes,
                            Dislikes = x.Dislikes,
                            TopicId = x.TopicId
                        })
                    .FirstOrDefault();

            return this.Ok(commentResult);
        }

        /* Body for the comment post
        {

 "content":"aaaaaaaaaa",
 "topicId":"1"
 }*/
        //TODO:Do we need update of comments..I guess no(Aleks :))
        //// TODO: [note] The update of the sections list will be done in post / delete in SectionsController through the foreign key automaticly
        //public IHttpActionResult Put(int id, [FromBody] CommentRequestModel updates)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest();
        //    }

        //    var newComment = new Comment
        //    {
        //        Id = id,
        //        UserId = updates.UserId,
        //        Content = updates.Content,
        //        Dislikes = updates.Dislikes,
        //        Likes = updates.Likes,
        //        TopicId = updates.TopicId
        //    };

        //    this.commnents.Update(newComment);

        //    return this.Ok(newComment);
        //}
        [Authorize]
        [HttpPost]
        public IHttpActionResult Post([FromBody] CommentRequestModel commentModel)
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var comment = new Comment
            {
                UserId = userId,
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