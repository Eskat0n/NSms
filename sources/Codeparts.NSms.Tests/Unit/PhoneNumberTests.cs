namespace Codeparts.NSms.Tests.Unit
{
    using Xunit;

    public class PhoneNumberTests
    {
        [Fact]
        public void ShouldInitializePropertiesWithCorrectValuesAfterCreation()
        {
            var phoneNumber = new PhoneNumber("7", "123", "4567890");

            Assert.Equal("7", phoneNumber.CountryCode);
            Assert.Equal("123", phoneNumber.CarrierCode);
            Assert.Equal("4567890", phoneNumber.AbonentNumber);
        }
    }
}