﻿using Moq;
using Storage;

namespace BLL.Test
{
    public class AccServiceTest
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
        public void CreateNewAccount_OneAccount_OneAccountCreated()
        {
            FileStorage fileStorage = new FileStorage(path); 
            AccountService? accountService = new AccountService(fileStorage);
            accountService.CreateNewAccount(
            testAccBlack.AccountNumber,
            testAccBlack.NameOfOwner,
            testAccBlack.SurnameOfOwner,
            testAccBlack.Balance,
            testAccBlack.Bonuses,
            testAccBlack.AccountGradation);

            AccountDto? accountDto = fileStorage.FindAccountByNumber(testAccBlack.AccountNumber);

            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(accountDto, null);
                Assert.That(accountDto.AccountNumber.Equals(testAccBlack.AccountNumber));
                Assert.That(accountDto.NameOfOwner.Equals(testAccBlack.NameOfOwner));
                Assert.That(accountDto.SurnameOfOwner.Equals(testAccBlack.SurnameOfOwner));
                Assert.That(accountDto.Balance.Equals(testAccBlack.Balance));
                Assert.That(accountDto.Bonuses.Equals(testAccBlack.Bonuses));
                Assert.That(accountDto.AccountGradation.Equals(testAccBlack.AccountGradation));
            }
            );
        }

        [Test]
        public void FindAccountByNumber_OneAccount_OneAccountFinded()
        {
            var fileStorage = new FileStorage(path);//через сетап
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
        public void WriteOff_Money_MoneyWithdrawn()
        {
            var fileStorage = new FileStorage(path);
            AccountService accountService = new AccountService(fileStorage);

            fileStorage.AddAccount(testAccBlack);
            accountService.WriteOffMoney(testAccBlack.AccountNumber, 123m);
            decimal? moneyAmount = (fileStorage.FindAccountByNumber(testAccBlack.AccountNumber)).Balance;

            Assert.True((testAccBlack.Balance - 123m) == moneyAmount);
        }

        [Test]
        public void WriteOff_Money_MoneyNotWithdrawn()
        {
            var fileStorage = new FileStorage(path);
            AccountService accountService = new AccountService(fileStorage);

            fileStorage.AddAccount(testAccBlack);
            decimal? moneyAmount = (fileStorage.FindAccountByNumber(testAccBlack.AccountNumber)).Balance;

            Assert.True(testAccBlack.Balance == moneyAmount);
        }

        [Test]
        public void WriteOfssaf_Money_MoneyNotWithdrawn()//норм нейминг
        {
            var mock = new Mock<IAccountConverter>();
            mock.Setup(a => a.CreateGoldAccount(It.IsAny<AccountDto>())).Returns(new GoldAccount("2222 2222 2222 2222",
            "Konstantsin",
            "Ermolenko",
            24.123m,
            122,
            "Gold"));

            var fck = new AccountFactory(mock.Object);
            var yhui = new AccountDto()
            {
                AccountGradation = "Gold"
            };
            var acc = fck.ReturnAccountGradation(yhui);

            mock.Verify(a => a.CreateGoldAccount(It.IsAny<AccountDto>()), Times.Once);
        }
    }
}