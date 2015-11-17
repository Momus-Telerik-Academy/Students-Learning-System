namespace StudentsLearning.Services.Data
{
    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;
    using System.Linq;

    public class LikesService : ILikesService
    {
        private readonly IUsersService users;
        private readonly IRepository<Like> likesRepo;
        private readonly ICommentService comments;

        public LikesService(IRepository<Like> likes, IUsersService users, ICommentService comments)
        {
            this.likesRepo = likes;
            this.users = users;
            this.comments = comments;
        }

        public IQueryable<Like> AllLikesForComment(int commentId)
        {
            return this.likesRepo
                .All()
                .Where(l => l.CommentId == commentId);
        }

        public void ChangeLikeStatus(int commentId, string userId, bool isPositive)
        {
            if (userId != null)
            {
                var like = this.likesRepo
                  .All()
                  .Where(l => l.UserId == userId && l.CommentId == commentId)
                  .FirstOrDefault();

                if (like == null)
                {
                    var newlike = new Like
                    {
                        CommentId = commentId,
                        UserId = userId,
                        IsPositive = isPositive
                    };

                    this.likesRepo.Add(newlike);
                    this.likesRepo.SaveChanges();
                }
                else
                {
                    like.IsPositive = isPositive;
                    this.likesRepo.Update(like);
                    this.likesRepo.SaveChanges();
                }

            }
        }
        
        public bool CommentIsLikesByUser(int commentId, string userId, bool isPositive)
        {
            return this.AllLikesForComment(commentId)
                        .Any(l => l.User.Id == userId && l.IsPositive== isPositive);
        }
    }
}
