namespace core_api.Models.Response
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IList<GetSubcategoryDto> Subcategories { get; set; } = new List<GetSubcategoryDto>();
    }

    public class GetSubcategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
