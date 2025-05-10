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
        public static AccountRequest AddAccount1()
        {
            return new AccountRequest
            {
                CostumerName = "marina",
                CostumerEmail = "marina@gmail.com",
                BirthDay = DateTime.Parse("2015-11-11"),
                Gender = GenderOptions.Female,
            };
        } 
        public static AccountRequest AddAccount2()
        {
            return new AccountRequest
            {
                CostumerName = "Ashley",
                CostumerEmail = "Ashley@gmail.com",
                BirthDay = DateTime.Parse("2015-11-11"),
                Gender = GenderOptions.Female,
            };
        }
    }
}
