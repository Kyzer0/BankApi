namespace Models
{
    public class Transfer
    {
        public string SourceAccountNumber { get; set; }
        public string DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
    }
}
