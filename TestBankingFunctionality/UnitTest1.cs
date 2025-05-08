using BankServicesLogic;
using BankServicesLogic.InterfaceServices;
using ModelDto.AccountDto;
using TestBankingFunctionality.Helpers;
using Models.Enums;

namespace TestBankingFunctionality
{
    public class UnitTest1
    {
        private readonly IAccountServices _account;
        public UnitTest1()
        {
            _account = new AccountServices();
        }
        #region
        [Fact]
        public void AddAccount_ShouldReturnError_WhenNull()
        {
            var result = _account.AddAccount(null);

            AsserApiHelpers.AsserApiError(result, "Account Cannot be null", "Null request received");
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

            AsserApiHelpers.AsserApiError(added_account, "Name is Cannot be Empty", "Name is Required");
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

            AsserApiHelpers.AsserApiError(added_account, "Email is Cannot be Empty", "Email is Required");
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
