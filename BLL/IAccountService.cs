namespace BLL
{
    public interface IAccountService
    {
        public bool FindAccountByNumber(string number);

        public void RefillMoney(string number, decimal amountOfMoney);

        public void WriteOffMoney(string number, decimal amountOfMoney);

        public void CreateNewAccount(
            string accountNumber,
            string nameOfOwner,
            string surnameOfOwner,
            decimal balance,
            int bonuses,
            string accountGradation
            );

        public void RemoveAccount(string number);
    }
}