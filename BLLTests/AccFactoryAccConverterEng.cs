using BLL;
using Moq;
using Storage;

namespace BLLTest
{
    public class AccFnCEngagement
    {
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

        [Test]
        public void Convert_OneBlackAccount_OneBlackAccountConverted()
        {
            AccountConverter converter = new AccountConverter();
            AccountFactory accountFactory = new AccountFactory(converter);

            var acc = accountFactory.ReturnAccountGradation(testAccBlack);

            Assert.IsTrue(acc is BlackAccount);
        }

        [Test]
        public void Convert_OneGoldAccount_OneGoldAccountConverted()
        {
            AccountConverter converter = new AccountConverter();
            AccountFactory accountFactory = new AccountFactory(converter);

            var acc = accountFactory.ReturnAccountGradation(testAccGold);

            Assert.IsTrue(acc is GoldAccount);
        }

        [Test]
        public void Convert_OnePlatinumAccount_OneBlackPlatinumConverted()
        {
            AccountConverter converter = new AccountConverter();
            AccountFactory accountFactory = new AccountFactory(converter);

            var acc = accountFactory.ReturnAccountGradation(testAccPlatinum);

            Assert.IsTrue(acc is PlatinumAccount);
        }        
    }
}