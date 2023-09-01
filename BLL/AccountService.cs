using Storage;

namespace BLL
{
    public class AccountService : IAccountService
    {
        private readonly IStorage _fileStorage;

        public AccountService(IStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }

        public void CreateNewAccount(string accountNumber,
            string nameOfOwner,
            string surnameOfOwner,
            decimal balance,
            int bonuses,
            string accountGradation)
        {
            AccountDto accountDto = new AccountDto()
            {
                AccountNumber = accountNumber,
                NameOfOwner = nameOfOwner,
                SurnameOfOwner = surnameOfOwner,
                Balance = balance,
                Bonuses = bonuses,
                AccountGradation = accountGradation
            };
            _fileStorage.AddAccount(accountDto);
            Console.WriteLine($"Account with number {accountNumber} has been created");
        }

        public bool FindAccountByNumber(string number)
        {
            if (_fileStorage.FindAccountByNumber(number) != null)
            {
                return true;
            }
            return false;
        }

        public void RefillMoney(string number, decimal amountOfMoney)
        {
            AccountDto? acc = new AccountDto();
            if (FindAccountByNumber(number))
            {
                Console.WriteLine($" {amountOfMoney} Money has been credited to your account");
                acc = _fileStorage.FindAccountByNumber(number);
                acc.Balance += amountOfMoney;
                _fileStorage.Update(acc);
                return;
            }
            Console.WriteLine($"Account with number {number} not found");
        }

        public void RemoveAccount(string number)
        {
            _fileStorage.DeleteAccount(number);
            Console.WriteLine("Account has beem removed");
        }

        public void WriteOffMoney(string number, decimal amountOfMoney)
        {
            AccountDto? acc = new AccountDto();
            if (_fileStorage.FindAccountByNumber(number) != null)
            {
                Console.WriteLine($" {amountOfMoney} Money has been credited to your account");
                acc = _fileStorage.FindAccountByNumber(number);
                if (acc.Balance < amountOfMoney)
                {
                    Console.WriteLine("not enough money");
                }
                else
                {
                    acc.Balance -= amountOfMoney;
                    _fileStorage.Update(acc);
                    Console.WriteLine($"{amountOfMoney} withdrawn from account. Account balance {acc.Balance}");
                }
            }
            return;
        }
    }
}