namespace BLL
{
    public abstract class Account : IEquatable<Account>, IComparable, IComparable<Account>
    {
        private const decimal coefficient = 1.4m;

        private string? _accountNumber;
        private string? _nameOfOwner;
        private string? _surnameOfOwner;
        private decimal? _balance;
        private int? _bonuses;
        private string? _accountGradation;

        public Account(
            string accountNumber,
            string nameOfOwner,
            string surnameOfOwner,
            decimal balance,
            int bonuses,
            string accountGradation)
        {
            AccountNumber = accountNumber;
            NameOfOwner = nameOfOwner;
            SurnameOfOwner = surnameOfOwner;
            Balance = balance;
            Bonuses = bonuses;
            AccountGradation = accountGradation;
        }

        public string? AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                if ((Validator.NullEqualValidator(value)))
                {
                    _accountNumber = value;
                }
            }
        }
        public string? NameOfOwner
        {
            get
            {
                return _nameOfOwner;
            }
            set
            {
                if (Validator.NullEqualValidator(value) && Validator.NameValidator(value))
                {
                    _nameOfOwner = value;
                }
            }
        }
        public string? SurnameOfOwner
        {
            get
            {
                return _surnameOfOwner;
            }
            set
            {
                if ((Validator.NullEqualValidator(value) && Validator.NameValidator(value)))
                {
                    _surnameOfOwner = value;
                }
            }
        }
        public decimal? Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (Validator.NullEqualValidator(value))
                {
                    _balance = value;
                }
            }
        }
        public int? Bonuses
        {
            get
            {
                return _bonuses;
            }
            set
            {
                if (Validator.NullEqualValidator(value))
                {
                    _bonuses = value;
                }
            }
        }
        public string? AccountGradation
        {
            get
            {
                return _accountGradation;
            }
            set
            {
                if (Validator.NullEqualValidator(value))
                {
                    _accountGradation = value;
                }
            }
        }

        public override string ToString()
        {
            return "BankAccount: " + AccountNumber.ToString()
                + " Name of Owner: " + NameOfOwner.ToString()
                + " Surname of Owner: " + SurnameOfOwner.ToString()
                + " Balance: " + Balance.ToString()
                + " Bonuses: " + Bonuses.ToString()
                + " Account Gradation: " + AccountGradation.ToString();
        }

        public bool Equals(Account? other)
        {
            if (ReferenceEquals(other, this)) return true;
            if (ReferenceEquals(other, null)) return false;
            return AccountNumber == other.AccountNumber &&
            AccountNumber == other.AccountNumber &&
            NameOfOwner == other.NameOfOwner &&
            SurnameOfOwner == other.SurnameOfOwner &&
            Balance == other.Balance &&
            Bonuses == other.Bonuses &&
            AccountGradation == other.AccountGradation
            ;
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(obj, this) &&
                   ReferenceEquals(obj, null) &&
                   obj is Account acc &&
                   Equals(acc);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(AccountNumber);
            hash.Add(NameOfOwner);
            hash.Add(SurnameOfOwner);
            hash.Add(Balance);
            hash.Add(Bonuses);
            hash.Add(AccountGradation);
            return hash.ToHashCode();
        }

        public int CompareTo(Account? other)
        {
            if (ReferenceEquals(other, this))
            {
                return 0;
            }

            if (ReferenceEquals(other, null))
            {
                return -1;
            }

            return AccountNumber.CompareTo(other.AccountNumber);
        }

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return 0;
            }

            if (ReferenceEquals(obj, null))
            {
                return -1;
            }

            if (obj is Account acc)
            {
                return AccountNumber.CompareTo(acc);
            }

            throw new ArgumentException(nameof(acc));
        }

        public static bool operator <(Account left, Account right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Account left, Account right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Account left, Account right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Account left, Account right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator ==(Account left, Account right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Account left, Account right)
        {
            return !(left == right);
        }

        public virtual int? BonusAmount(decimal cost)
        {
            return (int?)(cost * coefficient);
        }
    }
}