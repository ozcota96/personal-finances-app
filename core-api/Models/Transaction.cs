using core_api.Enums;

namespace core_api.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public TransactionTypes Type { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
