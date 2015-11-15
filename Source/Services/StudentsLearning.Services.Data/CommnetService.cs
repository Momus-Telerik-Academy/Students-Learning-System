namespace StudentsLearning.Services.Data
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;

    #endregion

    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void Add(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }

        public IQueryable<Comment> All()
        {
            return this.comments.All();
        }

        public IQueryable<Comment> GetById(int id)
        {
            return this.comments.All().Where(x => x.Id == id);
        }

        IQueryable<Comment> ICommentService.GetId(string commentContent)
        {
            return this.comments.All().Where(x => x.Content == commentContent);
        }

        public void Update(Comment comment)
        {
            this.comments.Update(comment);
            this.comments.SaveChanges();
        }
    }
}