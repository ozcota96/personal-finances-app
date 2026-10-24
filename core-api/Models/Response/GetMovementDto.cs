using core_api.Enums;

namespace core_api.Models.Response
{
    public class GetMovementDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public MovementTypes MovementType { get; set; }
        public DateTime Date { get; set; }
        public string Account { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Subcategory { get; set; } = string.Empty;
    }
}
