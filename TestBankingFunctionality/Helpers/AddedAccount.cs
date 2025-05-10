using ModelDto.AccountDto;
using Models.Enums;

namespace TestBankingFunctionality.Helpers
{
    public class AddedAccount
    {
        public static AccountRequest AddAccount()
        {
            return new AccountRequest
            {
                CostumerName = "Shimma",
                CostumerEmail = "shimma@gmail.com",
                BirthDay = DateTime.Parse("2015-11-11"),
                Gender = GenderOptions.Female,
            };
        }
    }
}
