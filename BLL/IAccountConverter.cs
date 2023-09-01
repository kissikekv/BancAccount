using Storage;

namespace BLL
{
    public interface IAccountConverter
    {
        public BlackAccount CreateBlackAccount(AccountDto accountDto);
        public GoldAccount CreateGoldAccount(AccountDto accountDto);
        public PlatinumAccount CreatePlatinumAccount(AccountDto accountDto);
    }
}