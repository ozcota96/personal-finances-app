namespace core_api.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual IList<Movement> Movements { get; set; } = [];
    }
}