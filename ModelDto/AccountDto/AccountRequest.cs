using System.ComponentModel.DataAnnotations;
using Models;
using Models.Enums;

namespace ModelDto.AccountDto
{
    /// <summary>
    /// Creating Dto for Account. Use for HTTPOST, HTTPATCH, HTTPUT
    /// </summary>
    public class AccountRequest
    {
        [Required(ErrorMessage = "Name is Required")]
        public string CostumerName { get; set; } = string.Empty;
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string CostumerEmail { get; set; } = string.Empty;
        public GenderOptions? Gender { get; set; }
        public DateTime? BirthDay { get; set; }

        public Account MapAccountModel () // Fully qualify the 'Account' type to avoid ambiguity
        {
            return new Account
            {
                CostumerName = CostumerName,
                CostumerEmail = CostumerEmail,
                Gender = Gender != null ? Gender.ToString() : "Invalid Null",
                BirthDay = BirthDay,
            };
        }
    }
}
