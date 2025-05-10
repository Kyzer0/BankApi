using BankServicesLogic;
using BankServicesLogic.InterfaceServices;
using ModelDto.AccountDto;
using TestBankingFunctionality.Helpers;
using Models.Enums;
using System.Resources;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using CostumeResponse;

namespace TestBankingFunctionality
{
    public class AccountTest
    {
        private readonly IAccountServices _account;
        private readonly ITestOutputHelper _testOutput;
        public AccountTest(ITestOutputHelper testOutput)
        {
            _account = new AccountServices();
            _testOutput = testOutput;
        }
        #region
        [Fact]
        public void AddAccount_ShouldReturnError_WhenNull()
        {
            var result = _account.AddAccount(null);

            AsserApiHelpers.AsserApiError(result, "Validation Failed", "Null request received");
        }
        [Fact]
        public void AddAccount_EmptyAccountName_CheckWhenEmpty()
        {
            var addAccount = new AccountRequest()
            {
                CostumerName = "",
                CostumerEmail = "dsadas@gmail.com",
                BirthDay = DateTime.Parse("2022-11-11"),
                Gender = GenderOptions.Male
            };
            var added_account = _account.AddAccount(addAccount);

            AsserApiHelpers.AsserApiError(added_account, "Validation Failed", "Name is Required");
        }
        [Fact]
        public void AddAccount_EmptyAccountEmail_CheckWhenEmpty()
        {
            var addAccount = new AccountRequest()
            {
                CostumerName = "sadasdasd",
                CostumerEmail = "",
                BirthDay = DateTime.Parse("2022-11-11"),
                Gender = GenderOptions.Male
            };
            var added_account = _account.AddAccount(addAccount);

            AsserApiHelpers.AsserApiError(added_account, "Validation Failed", "Email is Required");
        }
        [Fact]
        public void ValidateEmail_WhenIs_Duplicated()
        {
            var addAccount = new AccountRequest()
            {
                CostumerName = "sadasdassssd",
                CostumerEmail = "maria@gmail.com",
                BirthDay = DateTime.Parse("2022-11-11"),
                Gender = GenderOptions.Male
            };
            var addAccount2 = new AccountRequest()
            {
                CostumerName = "sadasdasssd",
                CostumerEmail = "maria@gmail.com",
                BirthDay = DateTime.Parse("2022-11-11"),
                Gender = GenderOptions.Male
            };
            var added_account = _account.AddAccount(addAccount);
            var added_account2 = _account.AddAccount(addAccount2);

            AsserApiHelpers.AsserApiError(added_account2, "Duplicate Email", "An Account with this Email  Already Exist");
}
        [Fact]
        public void Add_ValidAccount_ReturnAssertResult()
        {
            var addAccount = new AccountRequest()
            {
                CostumerName = "sadasdasd",
                CostumerEmail = "sadasda@gmail.com",
                BirthDay = DateTime.Parse("2022-11-11"),
                Gender = GenderOptions.Male
            };
            var added_account = _account.AddAccount(addAccount);

            AsserApiHelpers.AsserApiSuccess(added_account, "Successfully Added");
        }

        #endregion

        #region List of Account Test
        [Fact]
        public void ListPersons_AccountsAdded_ReturnsAllAccounts()
        {
            var addedAccount = AddedAccount.AddAccount();

            var add = _account.AddAccount(addedAccount);

            var result = _account.ListAllAccounts();

            AsserApiHelpers.AsserApiSuccess(result, "Successfully Display All Accounts");
        }
        [Fact]
        public void Check_GetAllAccount_IfWorking()
        {
             var addedAccount = AddedAccount.AddAccount();
             var addedAccount2 = AddedAccount.AddAccount();
             var addedAccount3 = AddedAccount.AddAccount();

            var add = _account.AddAccount(addedAccount);

            //listing all Accounts 
            List<AccountRequest> accountRequestsList = new List<AccountRequest>()
            {
                addedAccount,addedAccount2,addedAccount3
            };

            var listAccounts = _account.ListAllAccounts();

            //container for list
            List<ApiResponse<AccountResponse>> responses_list_container = new();

            //Adding to list 
            foreach(var list in accountRequestsList)
            {
                var account_list_Add = _account.AddAccount(list);
                responses_list_container.Add(account_list_Add);
            }

            _testOutput.WriteLine("Expected Values");
            foreach(var account in responses_list_container)
            {
                _testOutput.WriteLine(account.ToString());
            }

            var lisAccount = _account.ListAllAccounts();

            //assert
            _testOutput.WriteLine("Actuall Values"); 
            foreach(var accounts in lisAccount)
            {
                AsserApiHelpers.AsserApiSuccess(accounts, "Successfully Display All Accounts");
                Assert.Contains(accounts, lisAccount);
            }
        }
        #endregion
    }
}
