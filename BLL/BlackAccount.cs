﻿namespace BLL
{    public class BlackAccount : Account
    {
        private const decimal coefficient = 1.6m;

        public BlackAccount(string accountNumber,
            string nameOfOwner,
            string surnameOfOwner,
            decimal balance,
            int bonuses,
            string accountGradation) : base(accountNumber,
                nameOfOwner,
                surnameOfOwner,
                balance,
                bonuses,
                accountGradation)
        {}

        public override int? BonusAmount(decimal cost)
        {
            return 1 + (int?)(cost * coefficient * coefficient);
        }
    }
}