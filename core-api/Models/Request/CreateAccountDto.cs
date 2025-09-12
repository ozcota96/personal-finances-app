using System.ComponentModel.DataAnnotations;

namespace core_api.Models.Request
{
    public class CreateAccountDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; }
        public int UserId { get; set; }
    }
}
