namespace NSms.Tests.Unit
{
    using System;
    using NUnit.Framework;

    public class PhoneNumberTests
    {
        private PhoneNumber _phoneNumber;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            _phoneNumber = new PhoneNumber("7", "123", "4567890");
        }

        [Test]
        public void ShouldInitializePropertiesWithCorrectValuesAfterCreation()
        {
            Assert.AreEqual("7", _phoneNumber.CountryCode);
            Assert.AreEqual("123", _phoneNumber.CarrierCode);
            Assert.AreEqual("4567890", _phoneNumber.AbonentNumber);
        }

        [Test]
        public void ShouldThrowExceptionForNullCountryCode()
        {
            Assert.Throws<ArgumentException>(() => new PhoneNumber(null, "123", "4567890"));
        }

        [Test]
        public void ShouldThrowExceptionForNullCarrierCode()
        {
            Assert.Throws<ArgumentException>(() => new PhoneNumber("7", null, "4567890"));
        }

        [Test]
        public void ShouldThrowExceptionForNullAbonentNumber()
        {
            Assert.Throws<ArgumentException>(() => new PhoneNumber("7", "123", null));
        }

        [Test]
        public void ShouldThrowExceptionForInvalidPhoneNumber()
        {
            Assert.Throws<ArgumentException>(() => new PhoneNumber("7", "123", "456"));
        }

        [Test]
        public void ShouldCorrectlyFormatPhoneNumber()
        {
            var phoneNumberString = _phoneNumber.ToString();

            Assert.AreEqual("71234567890", phoneNumberString);
        }

        [Test]
        public void ShouldCorrectlyFormatPhoneNumberWithPlusSign()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.PlusSign);

            Assert.AreEqual("+71234567890", phoneNumberString);
        }

        [Test]
        public void ShouldCorrectlyFormatPhoneNumberWithBraces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.Braces);

            Assert.AreEqual("7(123)4567890", phoneNumberString);
        }

        [Test]
        public void ShouldCorrectlyFormatPhoneNumberWithSpaces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.Spaces);

            Assert.AreEqual("7 123 4567890", phoneNumberString);
        }

        [Test]
        public void ShouldCorrectlyFormatPhoneNumberWithPlusSignAndBraces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.PlusSign | PhoneNumberFormat.Braces);

            Assert.AreEqual("+7(123)4567890", phoneNumberString);
        }

        [Test]
        public void ShouldCorrectlyFormatPhoneNumberWithPlusSignAndSpaces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.PlusSign | PhoneNumberFormat.Spaces);

            Assert.AreEqual("+7 123 4567890", phoneNumberString);
        }

        [Test]
        public void ShouldCorrectlyFormatPhoneNumberWithBracesAndSpaces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.Braces | PhoneNumberFormat.Spaces);

            Assert.AreEqual("7 (123) 4567890", phoneNumberString);
        }

        [Test]
        public void ShouldCorrectlyFormatPhoneNumberWithPlusSignAndBracesAndSpaces()
        {
            var phoneNumberString = _phoneNumber.ToString(PhoneNumberFormat.PlusSign | PhoneNumberFormat.Braces | PhoneNumberFormat.Spaces);

            Assert.AreEqual("+7 (123) 4567890", phoneNumberString);
        }
    }
}