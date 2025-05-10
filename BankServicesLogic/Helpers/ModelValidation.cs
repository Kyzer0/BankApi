using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesLogic.Helpers
{
    internal class ModelValidation
    {
        /// <summary>
        /// Validate Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        internal static List<string> ValidateRequest<T>(T items)
        {
            ValidationContext validationContext = new ValidationContext(items);

            List<ValidationResult> validationResults = new();
            Validator.TryValidateObject(items, validationContext, validationResults, true);

            return validationResults.Select(x => x.ErrorMessage).ToList();
        }
        internal static void ValidateId(Guid? Id)
        {
            if(Id == null)
                
            if (Id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty", nameof(Id));
        }
        
    }
}
