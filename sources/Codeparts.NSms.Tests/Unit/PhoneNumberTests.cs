namespace Codeparts.NSms.Tests.Unit
{
    using Xunit;

    public class PhoneNumberTests
    {
        private readonly PhoneNumber _phoneNumber;

        public PhoneNumberTests()
        {
            _phoneNumber = new PhoneNumber("7", "123", "4567890");
        }

        [Fact]
        public void ShouldInitializePropertiesWithCorrectValuesAfterCreation()
        {
            Assert.Equal("7", _phoneNumber.CountryCode);
            Assert.Equal("123", _phoneNumber.CarrierCode);
            Assert.Equal("4567890", _phoneNumber.AbonentNumber);
        }

        [Fact]
        public void ShouldCorrectlyFormatPhoneNumber()
        {
            var phoneNumberString = _phoneNumber.ToString();

            Assert.Equal("71234567890", phoneNumberString);
        }

        [Fact]
        public void ShouldCorrectlyFormatPhoneNumberWithPlusSign()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.PlusSign);

            Assert.Equal("+71234567890", phoneNumberString);
        }

        [Fact]
        public void ShouldCorrectlyFormatPhoneNumberWithBraces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.Braces);

            Assert.Equal("7(123)4567890", phoneNumberString);
        }
        
        [Fact]
        public void ShouldCorrectlyFormatPhoneNumberWithSpaces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.Spaces);

            Assert.Equal("7 123 4567890", phoneNumberString);
        }
        
        [Fact]
        public void ShouldCorrectlyFormatPhoneNumberWithPlusSignAndBraces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.PlusSign | PhoneNumberFormat.Braces);

            Assert.Equal("+7(123)4567890", phoneNumberString);
        }
        
        [Fact]
        public void ShouldCorrectlyFormatPhoneNumberWithPlusSignAndSpaces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.PlusSign | PhoneNumberFormat.Spaces);

            Assert.Equal("+7 123 4567890", phoneNumberString);
        }
        
        [Fact]
        public void ShouldCorrectlyFormatPhoneNumberWithBracesAndSpaces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.Braces | PhoneNumberFormat.Spaces);

            Assert.Equal("7 (123) 4567890", phoneNumberString);
        }
        
        [Fact]
        public void ShouldCorrectlyFormatPhoneNumberWithPlusSignAndBracesAndSpaces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.PlusSign | PhoneNumberFormat.Braces | PhoneNumberFormat.Spaces);

            Assert.Equal("+7 (123) 4567890", phoneNumberString);
        }
    }
}