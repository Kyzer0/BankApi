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
        public ApiResponse<AccountResponse> AddAccount(AccountRequest addAccount)
        {
            throw new NotImplementedException();
        }
    }
}
