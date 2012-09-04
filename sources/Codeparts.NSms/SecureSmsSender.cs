namespace Codeparts.NSms
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
    }
}