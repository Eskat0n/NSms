namespace Codeparts.NSms
{
    using System.Collections.Generic;

    public class SmsMessage
    {
        private readonly IEnumerable<PhoneNumber> _recipients;

        public IEnumerable<PhoneNumber> Recipients
        {
            get { return _recipients; }
        }
    }
}