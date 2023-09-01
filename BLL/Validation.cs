using System.Text.RegularExpressions;

namespace BLL
{
    public static class Validator
    {
        public static bool NullEqualValidator(object value)
        {
            if (value.Equals(null))
            {
                throw new ArgumentNullException(nameof(value));
            }
            return true;
        }

        public static bool NameValidator(string name)
        {
            NullEqualValidator(name);
            string pattern = @"\d+";
            if (Regex.IsMatch(pattern, name))
            {
                throw new ArgumentException(nameof(name));
            }
            return true;
        }

        public static bool AccountNumberValidator(string accountNumber)
        {
            NullEqualValidator(accountNumber);
            string pattern = @"^\d{4}\s{1}\d{4}\s{1}\d{4}\s{1}\d{4}$";
            if (!Regex.IsMatch(pattern, accountNumber))
            {
                throw new ArgumentException(nameof(accountNumber));
            }
            return true;
        }
    }
}