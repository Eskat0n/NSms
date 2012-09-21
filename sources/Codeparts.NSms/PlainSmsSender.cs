namespace Codeparts.NSms
{
    using System.Collections.Generic;

    internal class PlainSmsSender : SmsSender
    {
        private readonly string _apiId;

        public PlainSmsSender(string apiId)
        {
            _apiId = apiId;
        }

        protected override IEnumerable<string> AdditionalParameters
        {
            get { yield return string.Format("api_id={0}", _apiId); }
        }

        public override string Send(string recipient, string text)
        {
            var parameters = new {to = recipient, text};
            var queryString = CreateQueryString(parameters);

            return WebClient.DownloadString(string.Format("/sms/send{0}", queryString));
        }
    }
}