using Storage;

namespace BLL
{
    public class AccountConverter : IAccountConverter
    {
        public BlackAccount CreateBlackAccount(AccountDto accountDto) 
        {
            return new BlackAccount(
                accountDto.AccountNumber,
                accountDto.NameOfOwner,
                accountDto.SurnameOfOwner,
                accountDto.Balance,
                accountDto.Bonuses,
                accountDto.AccountGradation
                );            
        }

        public GoldAccount CreateGoldAccount(AccountDto accountDto) 
        {
            return new GoldAccount(
                accountDto.AccountNumber,
                accountDto.NameOfOwner,
                accountDto.SurnameOfOwner,
                accountDto.Balance,
                accountDto.Bonuses,
                accountDto.AccountGradation
                );             
        }

        public PlatinumAccount CreatePlatinumAccount(AccountDto accountDto) 
        {
            return new PlatinumAccount(
                accountDto.AccountNumber,
                accountDto.NameOfOwner,
                accountDto.SurnameOfOwner,
                accountDto.Balance,
                accountDto.Bonuses,
                accountDto.AccountGradation
                );            
        }
    }
}
