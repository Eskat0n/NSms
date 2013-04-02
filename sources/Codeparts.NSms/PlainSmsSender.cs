namespace NSms
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

        public override SmsMessage Send(string recipient, string text)
        {
            var responseLines = SendInner(new[] {recipient}, text);

            return new SmsMessage(new[] {recipient}, text, responseLines[0], responseLines.Length > 1
                                                                                 ? responseLines[1]
                                                                                 : null);
        }

        public override SmsMessage Send(IEnumerable<string> recipients, string text)
        {
            var responseLines = SendInner(recipients, text);

            return new SmsMessage(recipients, text, responseLines[0], responseLines.Length > 1
                                                                          ? responseLines[1]
                                                                          : null);
        }

        private string[] SendInner(IEnumerable<string> recipients, string text)
        {
            var parameters = new {to = string.Join(",", recipients), text};
            var queryString = CreateQueryString(parameters);

            var response = WebClient.DownloadString(string.Format("/sms/send{0}", queryString));

            return response.Split('\n');
        }
    }
}