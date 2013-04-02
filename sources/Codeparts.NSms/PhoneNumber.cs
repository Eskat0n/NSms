namespace NSms
{
    using System;
    using System.Text;

    public class PhoneNumber
    {
        private readonly string _abonentNumber;
        private readonly string _carrierCode;
        private readonly string _countryCode;

        public PhoneNumber(string countryCode, string carrierCode, string abonentNumber)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
                throw new ArgumentException("Country code must be specified", "countryCode");
            if (string.IsNullOrWhiteSpace(carrierCode))
                throw new ArgumentException("Carrier code must be specified", "countryCode");
            if (string.IsNullOrWhiteSpace(abonentNumber))
                throw new ArgumentException("Abonent number must be specified", "abonentNumber");

            var phoneNumberLength = countryCode.Length + carrierCode.Length + abonentNumber.Length;
            if (phoneNumberLength != 11)
                throw new ArgumentException(string.Format("Invalid phone number length. Excepted 11 but was {0}",
                                                          phoneNumberLength));

            _countryCode = countryCode;
            _carrierCode = carrierCode;
            _abonentNumber = abonentNumber;
        }

        public string CountryCode
        {
            get { return _countryCode; }
        }

        public string CarrierCode
        {
            get { return _carrierCode; }
        }

        public string AbonentNumber
        {
            get { return _abonentNumber; }
        }

        public static PhoneNumber Parse(string input)
        {
            return new PhoneNumber(null, null, null);
        }

        public static bool TryParse(string input, out PhoneNumber phoneNumber)
        {
            phoneNumber = new PhoneNumber(null, null, null);
            return false;
        }

        protected bool Equals(PhoneNumber other)
        {
            return string.Equals(_countryCode, other._countryCode) &&
                   string.Equals(_carrierCode, other._carrierCode) &&
                   string.Equals(_abonentNumber, other._abonentNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PhoneNumber) obj);
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", _countryCode, _carrierCode, _abonentNumber);
        }

        public string ToString(PhoneNumberFormat format)
        {
            var phoneNumber = new StringBuilder();

            if (format.HasFlag(PhoneNumberFormat.PlusSign))
                phoneNumber.AppendFormat("+{0}", _countryCode);
            else
                phoneNumber.Append(_countryCode);

            if (format.HasFlag(PhoneNumberFormat.Spaces))
                phoneNumber.Append(" ");

            if (format.HasFlag(PhoneNumberFormat.Braces))
                phoneNumber.AppendFormat("({0})", _carrierCode);
            else
                phoneNumber.Append(_carrierCode);

            if (format.HasFlag(PhoneNumberFormat.Spaces))
                phoneNumber.Append(" ");

            phoneNumber.Append(_abonentNumber);

            return phoneNumber.ToString();
        }
    }
}