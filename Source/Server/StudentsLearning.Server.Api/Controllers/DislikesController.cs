namespace StudentsLearning.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;


    public class DislikesController : ApiController
    {
        private readonly ILikesService likesService;
        private readonly ICommentService commentService;

        public DislikesController(ILikesService likeService, ICommentService commentsSevice)
        {
            this.likesService = likeService;
            this.commentService = commentsSevice;
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Post(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (this.likesService.CommentIsDislikedByUser(id, userId))
            {
                return this.BadRequest("You have already disliked this comment.");
            }

            var comment = this.commentService.GetById(id)
                              .FirstOrDefault();

            this.likesService.DislikeComment(id, userId);

            return this.Ok();
        }
    }
}
