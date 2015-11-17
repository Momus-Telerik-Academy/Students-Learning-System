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

        public void LikeComment(int commentId, string userId)
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
                        IsPositive = true
                    };

                    this.likesRepo.Add(newlike);
                    this.likesRepo.SaveChanges();
                }
                else
                {
                    like.IsPositive = true;
                    this.likesRepo.Update(like);
                    this.likesRepo.SaveChanges();
                }

            }
        }

        public void DislikeComment(int commentId, string userId)
        {
            if (userId != null)
            {
                var like = this.likesRepo
                    .All()
                    .Where(l => l.UserId == userId && l.CommentId == commentId)
                    .FirstOrDefault();

                if (like != null)
                {
                    if (like.IsPositive)
                    {
                        like.IsPositive = false;

                        this.likesRepo.Update(like);
                        this.likesRepo.SaveChanges();
                    }
                }
                else
                {
                    var newLike = new Like
                    {
                        CommentId = commentId,
                        UserId = userId,
                        IsPositive = false
                    };

                    this.likesRepo.Add(newLike);
                    this.likesRepo.SaveChanges();
                }
            }
        }

        public bool CommentIsLikedByUser(int commentId, string userId)
        {
            return this.AllLikesForComment(commentId)
                        .Any(l => l.User.Id == userId && l.IsPositive);
        }

        public bool CommentIsDislikedByUser(int commentId, string userId)
        {
            return this.AllLikesForComment(commentId)
                        .Any(l => l.User.Id == userId && !l.IsPositive);
        }
    }
}
