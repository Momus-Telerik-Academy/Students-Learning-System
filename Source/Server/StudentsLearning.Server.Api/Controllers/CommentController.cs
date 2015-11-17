namespace StudentsLearning.Server.Api.Controllers
{
    #region

    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using AutoMapper;
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

        public CommentsController(ICommentService commnentService)
        {
            this.commnents = commnentService;

        }
        /* Body for the comment post
        {

 "content":"aaaaaaaaaa",
 "topicId":"1"
 }*/

        [Authorize]
        [HttpPost]
        public IHttpActionResult Post([FromBody] CommentRequestModel commentModel)
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var comment = Mapper.Map<CommentRequestModel, Comment>(commentModel);
            comment.UserId = userId;
            //var comment = new Comment
            //{
            //    UserId = userId,
            //    Content = commentModel.Content,
            //    Likes = 0,
            //    Dislikes = 0,
            //    TopicId = commentModel.TopicId
            //};

            this.commnents.Add(comment);
            return this.Ok(comment);
        }
    }
}