namespace conSpektas.Data.DTOs
{
    public class UploadConspectArgs
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public byte[] Content { get; set; }
    }
}
