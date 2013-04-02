namespace NSms.Tests
{
    using System.Configuration;

    public abstract class LiveTestsBase
    {
        private const string PhoneNumberKey = "PhoneNumber";
        private const string ApiKeyKey = "ApiKey";
        private const string PasswordKey = "Password";

        protected string PhoneNumber
        {
            get { return ConfigurationManager.AppSettings[PhoneNumberKey]; }
        }

        protected string ApiKey
        {
            get { return ConfigurationManager.AppSettings[ApiKeyKey]; }
        }

        protected string Password
        {
            get { return ConfigurationManager.AppSettings[PasswordKey]; }
        }
    }
}