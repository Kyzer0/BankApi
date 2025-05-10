using Models;
using System.Reflection;
using Models.Enums;
using System.ComponentModel.DataAnnotations;
namespace ModelDto.AccountDto
{
    /// <summary>
    /// Creating Account Dto and this is used for Response, HTTGET, HTTPGETBYID
    /// </summary>
    public class AccountResponse : IEquatable<Account>
    {
        [Key]
        public Guid ID { get; set; }
        public string AccountNumber { get; set; }
        public string CostumerName { get; set; } 
        public string CostumerEmail { get; set; } 
        public string? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public int Age { get; set; }
        public decimal? CurrentBalance { get; set; }
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Comparing the Objects values of Account instead of adress only
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True otherwise false</returns>
        public bool Equals(Account? other)
        {
            if (other == null)
                return false;

            return
                ID == other.Id &&
                AccountNumber == other.AccountNumber &&
                CostumerName == other.CostumerName &&
                CostumerEmail == other.CostumerEmail &&
                Gender == other.Gender &&
                BirthDay == other.BirthDay &&
                CurrentBalance == other.CurrentBalance &&
                CreatedAt == other.CreatedAt;
        }
        //Overried  the Equals
        public override bool Equals(object? obj) => Equals(obj as Account);

        //used this for faster retrival 
        public override int GetHashCode()
        {
            return HashCode.Combine(AccountNumber, CostumerName, CostumerEmail, Gender, BirthDay, CurrentBalance, CreatedAt);
        }

        public override string ToString()
        {
            return $"ID {ID}, AccountNumber {AccountNumber}, CostumerEmail {CostumerEmail}, Gender {Gender}" +
                $"Age {Age}, CurrentBalance {CurrentBalance},Created At {CreatedAt} ";
        }
    }
    /// <summary>
    /// created for returning response for AccountResponse
    /// </summary>
    public static class AccountResponseExtension
    {
        public static AccountResponse GetAccountResponse(this Account account)
        {
            return new AccountResponse
            {
                ID = account.Id,
                AccountNumber = account.AccountNumber,
                CostumerName = account.CostumerName,
                CostumerEmail = account.CostumerEmail,
                Gender = account.Gender,
                BirthDay = account.BirthDay,
                CreatedAt = DateTime.Now,
                Age = account.BirthDay.HasValue ? CalculateAge(account.BirthDay.Value) : 0,
                CurrentBalance = account.CurrentBalance
            };
        }

        private static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
    
}
