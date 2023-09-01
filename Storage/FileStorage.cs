
namespace Storage
{
    public class FileStorage : IStorage
    {
        private readonly string _path;

        public FileStorage(string path)
        {
            StorageValidator.ValidateFilePath(path);
            _path = path;
        }

        public void AddAccount(AccountDto accountDto)
        {
            using (StreamWriter stwriter = new StreamWriter(_path, true))
            {
                stwriter.WriteLine(accountDto.AccountNumber);
                stwriter.WriteLine(accountDto.NameOfOwner);
                stwriter.WriteLine(accountDto.SurnameOfOwner);
                stwriter.WriteLine(accountDto.Balance);
                stwriter.WriteLine(accountDto.Bonuses);
                stwriter.WriteLine(accountDto.AccountGradation);
            }
        }

        public AccountDto? FindAccountByNumber(string? number)
        {
            if (!File.Exists(_path))
            {
                return default;
            }

            using (StreamReader sreader = new StreamReader(_path))
            {
                while (!sreader.EndOfStream)
                {
                    var tempAccountNumber = sreader.ReadLine();
                    var tempNameOfOwner = sreader.ReadLine();
                    var tempSurnameOfOwner = sreader.ReadLine();
                    var tempBalance = sreader.ReadLine();
                    var tempBonuses = sreader.ReadLine();
                    var tempAccountGradation = sreader.ReadLine();
                    if (tempAccountNumber == number)
                    {
                        return new AccountDto()
                        {
                            AccountNumber = tempAccountNumber,
                            NameOfOwner = tempNameOfOwner,
                            SurnameOfOwner = tempSurnameOfOwner,
                            Balance = Convert.ToDecimal(tempBalance),
                            Bonuses = Convert.ToInt32(tempBonuses),
                            AccountGradation = tempAccountGradation
                        };
                    }
                }
                return default;
            }
        }
        private void RewriteFileWith(List<AccountDto> accList)
        {
            File.Delete(_path);
            foreach (AccountDto item in accList)
            {
                AccountDto accTemp = new AccountDto()
                {
                    AccountNumber = item.AccountNumber,
                    NameOfOwner = item.NameOfOwner,
                    SurnameOfOwner= item.SurnameOfOwner,
                    Balance= Convert.ToDecimal(item.Balance),
                    Bonuses= Convert.ToInt32(item.Bonuses),
                    AccountGradation = item.AccountGradation                    
                };
                AddAccount(accTemp);
            }
        }
        public void DeleteAccount(string accountNumber)
        {
            List<AccountDto> accList = ReadAccounts();
            var bookForDelete = accList.FirstOrDefault(book => book.AccountNumber == accountNumber);
            if (ReferenceEquals(bookForDelete, null))
            {
                return;
            }
            accList.Remove(bookForDelete);
            RewriteFileWith(accList);
        }
        private List<AccountDto> ReadAccounts()
        {
            List<AccountDto> accList = new List<AccountDto>();

            using (StreamReader sreader = new StreamReader(_path))
            {
                while (!sreader.EndOfStream)
                {
                    AccountDto acc = new AccountDto()
                    {
                        AccountNumber = sreader.ReadLine(),
                        NameOfOwner = sreader.ReadLine(),
                        SurnameOfOwner = sreader.ReadLine(),
                        Balance = Convert.ToDecimal(sreader.ReadLine()),
                        Bonuses = Convert.ToInt32(sreader.ReadLine()),
                        AccountGradation = sreader.ReadLine()
                    };
                    accList.Add(acc);
                }
            }
            return accList;
        }
        public void Update(AccountDto? acc)
        {
            List<AccountDto> accList = ReadAccounts();
            for (int i = 0; i < accList.Count; i++)
            {
                if (accList[i].AccountNumber == acc.AccountNumber)
                {
                    accList[i] = acc;
                    break;
                }
            }
            RewriteFileWith(accList);
        }
    }
}