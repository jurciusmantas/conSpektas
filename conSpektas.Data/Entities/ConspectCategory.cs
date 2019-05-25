namespace conSpektas.Data.Entities
{
    public class ConspectCategory
    {
        public int ConspectId { get; set; }
        public Conspect Conspect { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
