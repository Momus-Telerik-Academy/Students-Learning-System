namespace StudentsLearning.Server.Api.Controllers
{
    #region

    using System.Web.Http;
    using System.Web.Http.Cors;

    using AutoMapper;
    using Infrastructure.Filters;
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
        [ValidateModelState]
        [CheckNull]
        public IHttpActionResult Post([FromBody] CommentRequestModel commentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            var comment = Mapper.Map<CommentRequestModel, Comment>(commentModel);
            comment.UserId = userId;

            this.commnents.Add(comment);
            return this.Ok(comment);
        }
    }
}