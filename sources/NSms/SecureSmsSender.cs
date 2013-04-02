namespace NSms
{
    using System.Collections.Generic;

    internal class SecureSmsSender : SmsSender
    {
        private readonly string _login;

        public SecureSmsSender(string login, string password)
        {
            _login = login;
            
        }

        protected override IEnumerable<string> AdditionalParameters
        {
            get { yield break; }
        }

        public override SmsMessage Send(string recipient, string text)
        {
            throw new System.NotImplementedException();
        }

        public override SmsMessage Send(IEnumerable<string> recipients, string text)
        {
            throw new System.NotImplementedException();
        }
    }
}