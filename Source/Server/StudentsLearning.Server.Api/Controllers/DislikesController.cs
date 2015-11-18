namespace StudentsLearning.Server.Api.Controllers
{
    using System.Web.Http;

    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    [RoutePrefix("api/Dislikes/")]
    public class DislikesController : ApiController
    {
        private readonly ILikesService likesService;

        public DislikesController(ILikesService likeService)
        {
            this.likesService = likeService;
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Post(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (this.likesService.CommentIsLikesByUser(id, userId, false))
            {
                return this.BadRequest("You have already disliked this comment.");
            }

            this.likesService.ChangeLikeStatus(id, userId, false);

            return this.Ok();
        }
    }
}
