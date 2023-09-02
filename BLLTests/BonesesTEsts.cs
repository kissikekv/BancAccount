using BLL;

namespace BLLTests
{
    public class BonesesTests
    {
        [Test]
        public void Bounuses_Accrual_BonusesAccrualed()
        {
            var blackAccount = new BlackAccount(
                "1111 1111 1111 1111",
                "Gnida", 
                "Gavno",
                123m, 
                123,
                "Black Account");
            var platinumAccount = new PlatinumAccount(
                "1111 1111 1111 1111",
                "Gnida", 
                "Gavno",
                123m, 
                123,
                "PlatinumAccount");
            var goldAccount = new GoldAccount(
                "1111 1111 1111 1111",
                "Gnida", 
                "Gavno",
                123m, 
                123,
                "GoldAccount");

            int? blackBonusAmount = blackAccount.BonusAmount(123m);
            int? platinumBonusAmount = platinumAccount.BonusAmount(123m);
            int? goldBonusAmount = goldAccount.BonusAmount(123m);

            Assert.IsTrue(blackBonusAmount == (1 + (int?)(123m * 1.6m * 1.6m)));
            Assert.IsTrue(platinumBonusAmount == (3 + (int?)(123m * 1.9m * 1.9m)));
            Assert.IsTrue(goldBonusAmount == (2 + (int?)(123m * 1.7m * 1.7m)));
        }
    }
}
