namespace Codeparts.NSms.Tests.Live
{
    using System;
    using System.Configuration;
    using System.Linq;
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
            var message = smsSender.Send(_phoneNumber, "One recipient");

            DumpMessageToConsole(message);
        }

        [Fact]
        public void SendSimpleUtf8SmsToManyRecipients()
        {
            var smsSender = SmsSender.Create(_apiKey);
            var message = smsSender.Send(new[] {_phoneNumber, _phoneNumber}, "Many recipients");

            DumpMessageToConsole(message);
        }

        private static void DumpMessageToConsole(SmsMessage message)
        {
            Console.WriteLine("SMS message with text \"{0}\" sent to numbers {1}",
                              message.Text,
                              string.Join(", ", message.Recipients));
            Console.WriteLine("Return code is {0}", message.ReturnCode);
            if (string.IsNullOrEmpty(message.Id))
                Console.WriteLine("Message id is not specified");
            else
                Console.WriteLine("Message id is {0}", message.Id);
        }
    }
}