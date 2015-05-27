namespace Twitter.Data
{
    using System.Data.Entity;

    using Twitter.Models;


    public interface IApplicationDbContext
    {

        IDbSet<Message> Messages { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<Retweet> Retweets { get; set; }
 
        IDbSet<Tweet> Tweets { get; set; }

        int SaveChanges();
    }
}