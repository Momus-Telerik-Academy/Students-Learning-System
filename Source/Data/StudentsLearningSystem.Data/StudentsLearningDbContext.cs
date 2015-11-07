namespace StudentsLearning.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class StudentsLearningDbContext : IdentityDbContext<User>, IStudentsLearningDbContext
    {
        public StudentsLearningDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static StudentsLearningDbContext Create()
        {
            return new StudentsLearningDbContext();
        }
    }
}