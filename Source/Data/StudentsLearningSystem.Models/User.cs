namespace StudentsLearning.Data.Models
{
    #region

    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    #endregion

    public class User : IdentityUser
    {
        private ICollection<Comment> comments;

        private ICollection<Topic> topicsContributions;

        public User()
        {
            this.topicsContributions = new HashSet<Topic>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Topic> TopicsContibutions
        {
            get
            {
                return this.topicsContributions;
            }

            set
            {
                this.topicsContributions = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User> manager, 
            string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}