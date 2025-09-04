namespace core_api.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual IList<Movement> Movements { get; set; } = [];
    }
}
