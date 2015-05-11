namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Tweet> tweets;
        private ICollection<Tweet> favoriteTweets;
        private ICollection<Retweet> retweets; 
        private ICollection<Notification> notifications;
        private ICollection<Message> sendedMessages;
        private ICollection<Message> receivedMessages; 

        public ApplicationUser()
        {
            this.tweets = new HashSet<Tweet>();
            this.favoriteTweets = new HashSet<Tweet>();
            this.retweets = new HashSet<Retweet>();
            this.notifications = new HashSet<Notification>();
            this.sendedMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.Users = new HashSet<ApplicationUser>();
            this.Followers = new HashSet<ApplicationUser>();
            this.UsersFollowing = new HashSet<ApplicationUser>();
            this.Following = new HashSet<ApplicationUser>();
        }

        [InverseProperty("Followers")]
        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<ApplicationUser> Followers { get; set; }

        [InverseProperty("Following")]
        public virtual ICollection<ApplicationUser> UsersFollowing { get; set; }

        public virtual ICollection<ApplicationUser> Following { get; set; }

        [InverseProperty("Author")]
        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

        public virtual ICollection<Retweet> Retweets
        {
            get { return this.retweets; }
            set { this.retweets = value; }
        } 

        public virtual ICollection<Tweet> FavoriteTweets
        {
            get { return this.favoriteTweets; }
            set { this.favoriteTweets = value; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }

        [InverseProperty("Sender")]
        public virtual ICollection<Message> SendedMessages
        {
            get { return this.sendedMessages; }
            set { this.sendedMessages = value; }
        }

        [InverseProperty("Receiver")]
        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
