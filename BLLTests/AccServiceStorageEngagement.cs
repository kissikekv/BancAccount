using BLL;
using Moq;
using Storage;

namespace BLLTest
{
    public class AccServiceStorageEngagement
    {
        const string path = "E:\\EduBlya\\filecsv.csv";

        private AccountDto testAccBlack = new AccountDto()
        {
            AccountNumber = "1111 1111 1111 1111",
            NameOfOwner = "Alex",
            SurnameOfOwner = "Bobko",
            Balance = 123.123m,
            Bonuses = 123,
            AccountGradation = "Black"
        };

        private AccountDto testAccGold = new AccountDto()
        {
            AccountNumber = "2222 2222 2222 2222",
            NameOfOwner = "Konstantsin",
            SurnameOfOwner = "Ermolenko",
            Balance = 124.123m,
            Bonuses = 122,
            AccountGradation = "Gold"
        };

        private AccountDto testAccPlatinum = new AccountDto()
        {
            AccountNumber = "3333 3333 3333 3333",
            NameOfOwner = "Gnide",
            SurnameOfOwner = "Jopenko",
            Balance = 124.123m,
            Bonuses = 122,
            AccountGradation = "Platinum"
        };

        [TearDown]
        public void DeleteData()
        {
            File.Delete(path);
        }

        [Test]
        public void Create_OneAccount_OneAccountCreated()
        {
            var fileStorage = new FileStorage(path);
            AccountService accountService = new AccountService(fileStorage);

            accountService.CreateNewAccount(
                testAccBlack.AccountNumber,
                testAccBlack.NameOfOwner,
                testAccBlack.SurnameOfOwner,
                testAccBlack.Balance,
                testAccBlack.Bonuses,
                testAccBlack.AccountGradation);
            AccountDto? accountDto = fileStorage.FindAccountByNumber(testAccBlack.AccountNumber);

            Assert.IsNotNull(accountDto);
        }

        [Test]
        public void Find_OneAccount_OneAccountFinded()
        {
            var fileStorage = new FileStorage(path);
            AccountService accountService = new AccountService(fileStorage);

            fileStorage.AddAccount(testAccBlack);
            bool exist = accountService.FindAccountByNumber(testAccBlack.AccountNumber);
            bool notExist = accountService.FindAccountByNumber(testAccPlatinum.AccountNumber);

            Assert.IsTrue(exist);
            Assert.IsFalse(notExist);
        }

        [Test]
        public void Refill_Money_MoneuRefilled()
        {
            var fileStorage = new FileStorage(path);
            AccountService accountService = new AccountService(fileStorage);

            fileStorage.AddAccount(testAccBlack);
            accountService.RefillMoney(testAccBlack.AccountNumber, 123m);

            Assert.True((testAccBlack.Balance + 123m) == (246.123m));
        }

        [Test]
        public void Remove_OneAccount_AccountRemoved()
        {
            var fileStorage = new FileStorage(path);
            AccountService accountService = new AccountService(fileStorage);

            fileStorage.AddAccount(testAccBlack);
            accountService.RemoveAccount(testAccBlack.AccountNumber);
            bool exist = accountService.FindAccountByNumber(testAccBlack.AccountNumber);

            Assert.IsFalse(exist);
        }

        [Test]        
        public void WriteOff_Money_()
        {
            var fileStorage = new FileStorage(path);
            AccountService accountService = new AccountService(fileStorage);

            fileStorage.AddAccount(testAccBlack);
            accountService.WriteOffMoney(testAccBlack.AccountNumber, 123m);

            Assert.True((testAccBlack.Balance - 123m) == (0.123m));
        }
    }
}