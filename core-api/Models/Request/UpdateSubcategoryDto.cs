namespace core_api.Models.Request
{
    public class UpdateSubcategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
