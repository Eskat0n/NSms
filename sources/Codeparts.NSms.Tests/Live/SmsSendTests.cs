namespace Codeparts.NSms.Tests.Live
{
    using System;
    using System.Configuration;
    using Xunit;

    public class SmsSendTests : LiveTestsBase
    {
        private readonly string _phoneNumber;
        private readonly string _apiKey;

        public SmsSendTests()
        {
            _phoneNumber = ConfigurationManager.AppSettings["PhoneNumber"];
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
        }

        [Fact]
        public void SendSimpleUtf8SmsToOneRecipient()
        {
            var smsSender = SmsSender.Create(_apiKey);
            var response = smsSender.Send(_phoneNumber, "Test message");

            Console.WriteLine("SMS message sent to number {0}", _phoneNumber);
            Console.WriteLine("Response is {0}", response);
        }
    }
}