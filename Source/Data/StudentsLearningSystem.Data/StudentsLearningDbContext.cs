﻿namespace StudentsLearning.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class StudentsLearningDbContext : IdentityDbContext<User>, IStudentsLearningDbContext
    {
        public StudentsLearningDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Section> Sections { get; set; }

        public virtual IDbSet<Topic> Topics { get; set; }

        public virtual IDbSet<Example> Examples { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<ZipFile> Materials { get; set; }

        public static StudentsLearningDbContext Create()
        {
            return new StudentsLearningDbContext();
        }
    }
}