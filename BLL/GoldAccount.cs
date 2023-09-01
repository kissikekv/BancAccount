﻿namespace BLL
{
    public class GoldAccount : Account
    {
        private const decimal coefficient = 1.7m;
        public GoldAccount(string accountNumber,
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
            return 2 + (int?)(cost * coefficient * coefficient);
        }
    }
}