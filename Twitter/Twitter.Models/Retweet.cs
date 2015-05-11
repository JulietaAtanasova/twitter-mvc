namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Retweet
    {
        [Key]
        public int Id { get; set; }

        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
