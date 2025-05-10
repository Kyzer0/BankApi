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
            mapAccount.Id = new Guid(); // generating new Id whenever you are adding Account
            _account.Add(mapAccount);


            response.isSuccess = true;
            response.Message = "Successfully Added";
            response.Data = new AccountResponse();

            return response;

        }

        public ApiResponse<AccountResponse> GetAccountID(Guid? Id)
        {
            var response = new ApiResponse<AccountResponse>();

            if (Id == Guid.Empty)
            {
                response.isSuccess = false;
                response.Message = "Validation Failed";
                response.Errors.Add("Account Id Cannot be Empty");
                return response;
            } 
            var findId = _account.FirstOrDefault(x => x.Id == Id);

            if (findId == null)
            {
                response.isSuccess = false;
                response.Message = "Validation Failed";
                response.Errors.Add("Account Id Cannot be Found");
                return response;
            }

            response.isSuccess = true;
            response.Message = "ID is Retrive completly";
            response.Data = new AccountResponse();

            return response;
        }

        public List<ApiResponse<AccountResponse>> ListAllAccounts()
        {
            var response = new ApiResponse<AccountResponse>();
            //container
            List<ApiResponse<AccountResponse>> apiResponsesList = new();
            response.isSuccess = true;
            response.Message = "Successfully Display All Accounts";
            response.Data = new AccountResponse();

            apiResponsesList.Add(response);

            return apiResponsesList;
        }
    }
}
