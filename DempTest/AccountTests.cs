using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;

namespace BLLTests
{
    [TestClass]
    public class DemoAccClassIDK
    {
        [NUnit.Framework.Test]
        public void AccountNumberStab()
        {
            IAccount acc = Mock.Of<IAccount>(
                d => d.AccountNumber == "1111 1111 1111 1111");

            string accountNumber = acc.AccountNumber;

            Assert.IsTrue(accountNumber.Equals("1111 1111 1111 1111"));
        }
    }
}
