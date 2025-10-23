using core_api.Enums;
using System.ComponentModel.DataAnnotations;

namespace core_api.Models.Request
{
    public class CreateMovementDto
    {
        [Required]
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public MovementTypes MovementType { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
    }
}
