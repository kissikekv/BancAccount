﻿namespace Storage
{
    public class AccountDto
    {
        public string AccountNumber { get; set; }
        public string NameOfOwner { get; set; }
        public string SurnameOfOwner { get; set; }
        public decimal Balance { get; set; }
        public int Bonuses { get; set; }
        public string AccountGradation { get; set;}
    }
}