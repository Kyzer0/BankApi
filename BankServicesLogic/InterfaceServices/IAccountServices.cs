using CostumeResponse;
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
        /// <returns>Add Account response</returns>
        ApiResponse<AccountResponse> AddAccount(AccountRequest addAccount);

        /// <summary>
        /// List of All Accounts
        /// </summary>
        /// <returns>List of accounts response</returns>
        List<ApiResponse<AccountResponse>> ListAllAccounts();

        /// <summary>
        /// Get Account Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Return Get account by ID</returns>
        ApiResponse<AccountResponse> GetAccountID(Guid? Id);
    }
}
