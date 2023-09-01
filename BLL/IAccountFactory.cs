using Storage;

namespace BLL
{
    public interface IAccountFactory
    {
        public Account? ReturnAccountGradation(AccountDto accountDto);
    }
}