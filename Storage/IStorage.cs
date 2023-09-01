﻿namespace Storage
{
    public interface IStorage
    {
        public void AddAccount(AccountDto acc);
        public AccountDto? FindAccountByNumber(string? number);       
        public void DeleteAccount(string accountNumber);        
        public void Update(AccountDto? acc);
    }
}