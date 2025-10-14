namespace core_api.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual IList<Subcategory> Subcategories { get; set; } = [];
        public virtual IList<Movement> Movements { get; set; } = [];
    }
}
