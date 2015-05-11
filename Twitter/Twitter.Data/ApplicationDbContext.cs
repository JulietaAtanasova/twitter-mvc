namespace Twitter.Data
{
    using System.Data.Entity;

    using Twitter.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<Retweet> Retweets { get; set; }
 
        public IDbSet<Tweet> Tweets { get; set; }

        //public System.Data.Entity.DbSet<Twitter.Models.ApplicationUser> ApplicationUsers { get; set; }

    }
}