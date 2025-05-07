using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto
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
        public string? Gender { get; set; }
        public DateTime? BirthDay { get; set; }


        public Account MapAccountRequest()
        {
            return new Account
            {
                CostumerName = this.CostumerName,
                CostumerEmail = this.CostumerEmail,
                Gender = (Gender != null)? Gender.ToString() : "Invalid Null",
                BirthDay = this.BirthDay,
            };

        }
    }
}
