using Storage;

namespace BLL
{
    public class AccountFactory : IAccountFactory
    {
        private readonly IAccountConverter _accountConverter;
        public AccountFactory(IAccountConverter converter)
        {
            _accountConverter = converter;
        }
        public Account? ReturnAccountGradation(AccountDto accountDto)
        {
            switch (accountDto.AccountGradation)
            {
                case "Gold":
                    return _accountConverter.CreateGoldAccount(accountDto);
                case "Black":
                    return _accountConverter.CreateBlackAccount(accountDto);
                case "Platinum":
                    return _accountConverter.CreatePlatinumAccount(accountDto);
                default: 
                    return default;
            }
        }
    }
}
