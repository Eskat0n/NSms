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
    }
}