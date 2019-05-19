namespace conSpektas.Data.Entities
{
    public class ConspectRating
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ConspectId { get; set; }
        public Conspect Conspect { get; set; }
        public int Value { get; set; }
    }
}
