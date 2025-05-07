using BankServicesLogic;
using BankServicesLogic.InterfaceServices;
using ModelDto.AccountDto;
namespace TestBankingFunctionality
{
    public class UnitTest1
    {
        private readonly IAccountServices _account;
        public UnitTest1()
        {
            _account = new AccountServices();
        }

        [Fact]
        public void AddAccount_CheckPersonRequest_ifNull()
        {
            AccountRequest? account = null;

            Assert.Null(account);

        }
    }
}
