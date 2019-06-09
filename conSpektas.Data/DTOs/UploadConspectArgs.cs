namespace conSpektas.Data.DTOs
{
    public class UploadConspectArgs
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
    }
}
