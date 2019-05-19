namespace conSpektas.Data.Entities
{
    public class CommentRating
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public int Value { get; set; }
    }
}
