using BankServicesLogic.Helpers;
using BankServicesLogic.InterfaceServices;
using CostumeResponse;
using ModelDto.AccountDto;
using Models;

namespace BankServicesLogic
{
    public class AccountServices : IAccountServices
    {
        private readonly List<Account> _account;
        public AccountServices()
        {
            _account = new List<Account>();
        }
        /// <summary>
        /// Add Account for User
        /// </summary>
        /// <param name="addAccount"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ApiResponse<AccountResponse> AddAccount(AccountRequest addAccount)
        {     
            var response = new ApiResponse<AccountResponse>();

            if(addAccount == null)
            {
                response.isSuccess = false; 
                response.Message = "Validation Failed";
                response.Errors.Add("Null request received");
                return response;
            }
            var validationError = ModelValidation.ValidateRequest(addAccount);

            if (validationError.Any())
            {
                response.isSuccess = false;
                response.Message = "Validation Failed";
                response.Errors.AddRange(validationError);
                return response;
            }
            bool emailExist = _account.Any(x => x.CostumerEmail == addAccount.CostumerEmail);

            if (emailExist)
            {
                response.isSuccess = false;
                response.Message = "Duplicate Email";
                response.Errors.Add("An Account with this Email  Already Exist");
                return response;
            }
            var mapAccount = addAccount.MapAccountModel();
            _account.Add(mapAccount);

            response.isSuccess = true;
            response.Message = "Successfully Added";
            response.Data = new AccountResponse();

            return response;

        }

        public List<ApiResponse<AccountResponse>> ListAllAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
