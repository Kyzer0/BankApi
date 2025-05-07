namespace ModelDto
{
    /// <summary>
    /// Models for Costumer Account
    /// </summary>
    public class Account
    {
        public Guid CostumerKey { get; set; }
        public string CostumerName { get; set; } 
        public string CostumerEmail { get; set; } 
        public string? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public decimal? CurrentBalance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
