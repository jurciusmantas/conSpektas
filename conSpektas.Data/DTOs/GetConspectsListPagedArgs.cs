namespace conSpektas.Data.DTOs
{
    public class GetConspectsListPagedArgs
    {
        public int PageSize{ get; set; }
        public int PageNumber{ get; set; }
        public int? CategoryId{ get; set; }
        public string Title { get; set; }
        public int? UserId { get; set; }
    }
}
