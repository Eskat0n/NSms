namespace Codeparts.NSms
{
    using System.Collections.Generic;

    public class SmsMessage
    {
        public SmsMessage(IEnumerable<string> recipients, string text, string returnCode, string id)
        {
            Recipients = recipients;
            Text = text;
            ReturnCode = returnCode;
            Id = id;
        }

        public IEnumerable<string> Recipients { get; private set; }

        public string Text { get; private set; }

        public string ReturnCode { get; private set; }

        public string Id { get; private set; }
    }
}