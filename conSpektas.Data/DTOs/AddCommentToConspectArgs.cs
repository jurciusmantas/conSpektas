namespace conSpektas.Data.DTOs
{
    public class AddCommentToConspectArgs
    {
        public int ConspectId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
