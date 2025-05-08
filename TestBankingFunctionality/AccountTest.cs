using BankServicesLogic;
using BankServicesLogic.InterfaceServices;
using ModelDto.AccountDto;
using TestBankingFunctionality.Helpers;
using Models.Enums;
using System.Resources;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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
    }
}
