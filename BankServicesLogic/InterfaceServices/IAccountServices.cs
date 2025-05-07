using ModelDto.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankServicesLogic.InterfaceServices
{
    public interface IAccountServices
    {
        /// <summary>
        /// Add Account for users
        /// </summary>
        /// <param name="addAccount"></param>
        /// <returns></returns>
        AccountResponse AddAccount(AccountRequest addAccount);
    }
}
