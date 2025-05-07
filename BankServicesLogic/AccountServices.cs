using BankServicesLogic.InterfaceServices;
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
        public AccountResponse AddAccount(AccountRequest addAccount)
        {
            throw new NotImplementedException();
        }
    }
}
