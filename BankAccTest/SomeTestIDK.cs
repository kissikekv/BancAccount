using Storage;

namespace StorageLayerTest
{
    public class StorageTest
    {
        const string path = "E:\\EduBlya\\filecsv.csv";
        const string firstAccNumber = "1111 1111 1111 1111";
        const string secondAccNumber = "2222 2222 2222 2222";

        private AccountDto firstTestAcc = new AccountDto()
        {
            AccountNumber = firstAccNumber,
            NameOfOwner = "Alex",
            SurnameOfOwner = "Bobko",
            Balance = 123.123m,
            Bonuses = 123,
            AccountGradation = "BlackAccount"
        };

        private AccountDto secondTestAcc = new AccountDto()
        {
            AccountNumber = secondAccNumber,
            NameOfOwner = "Konstantsin",
            SurnameOfOwner = "Ermolenko",
            Balance = 124.123m,
            Bonuses = 122,
            AccountGradation = "GoldAccount"
        };

        [TearDown]
        public void DeleteData()
        {
            File.Delete(path);
        }

        [Test]
        public void Add_OneAccount_OneAccountAdded()
        {
            var fileStorage = new FileStorage(path);

            fileStorage.AddAccount(firstTestAcc);
            string? fileContent = File.ReadAllText(path);

            Assert.IsFalse(string.IsNullOrEmpty(fileContent));
        }

        [TestCase(firstAccNumber, true)]
        [TestCase(secondAccNumber, false)]
        public void Find_OneAccount_OneAccountFinded(string accNumb, bool expectation)
        {
            var fileStorage = new FileStorage(path);

            fileStorage.AddAccount(firstTestAcc);
            AccountDto? accForSearch = fileStorage.FindAccountByNumber(accNumb);
            bool equalOrNot = accForSearch != null &&
                (accForSearch.AccountNumber == firstTestAcc.AccountNumber) &&
                (accForSearch.NameOfOwner == firstTestAcc.NameOfOwner) &&
                (accForSearch.SurnameOfOwner == firstTestAcc.SurnameOfOwner) &&
                (accForSearch.Balance == firstTestAcc.Balance) &&
                (accForSearch.Bonuses == firstTestAcc.Bonuses) &&
                (accForSearch.AccountGradation == firstTestAcc.AccountGradation);

            Assert.That(expectation, Is.EqualTo(equalOrNot));
        }

        [TestCase(firstAccNumber)]
        [TestCase(secondAccNumber)]
        public void Delete_OneAccount_StorageDeleted(string accNumber)
        {
            var fileStorage = new FileStorage(path);
            var acc = new AccountDto()
            {
                AccountNumber = accNumber,
                NameOfOwner = firstTestAcc.NameOfOwner,
                SurnameOfOwner = firstTestAcc.SurnameOfOwner,
                Balance = firstTestAcc.Balance,
                Bonuses = firstTestAcc.Bonuses,
                AccountGradation = firstTestAcc.AccountGradation
            };

            fileStorage.AddAccount(acc);
            fileStorage.DeleteAccount(acc.AccountNumber);

            Assert.IsFalse(File.Exists(path));
        }

        [Test]
        public void Delete_OneAccount_AccountDeleted()
        {
            var fileStorage = new FileStorage(path);

            fileStorage.AddAccount(firstTestAcc);
            fileStorage.AddAccount(secondTestAcc);
            fileStorage.DeleteAccount(firstAccNumber);

            Assert.IsTrue(File.Exists(path));
            Assert.That(fileStorage.FindAccountByNumber(firstAccNumber), Is.EqualTo(null));
        }
        [Test]
        public void Update_OneAccount_AccountUpdated()
        {
            var fileStorage = new FileStorage(path);
            var acc = new AccountDto()
            {
                AccountNumber = firstTestAcc.AccountNumber,
                NameOfOwner = "Huesos",
                SurnameOfOwner = "Pidor",
                Balance = 123,
                Bonuses = 1488,
                AccountGradation = "BlackAccount"
            };

            fileStorage.AddAccount(firstTestAcc);
            fileStorage.Update(acc);

            Assert.That(true, Is.Not.EqualTo(Equals(fileStorage.FindAccountByNumber(firstAccNumber), firstTestAcc)));
        }
    }
}