namespace core_api.Models.Request
{
    public class UpdateAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}