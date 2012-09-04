namespace Codeparts.NSms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    public abstract class SmsSender
    {
        protected readonly WebClient WebClient;

        public static SmsSender Create(string apiId)
        {
            return new PlainSmsSender(apiId);
        }
        
        public static SmsSender Create(Guid apiId)
        {
            return Create(apiId.ToString());
        }
        
        public static SmsSender Create(string login, string password)
        {
            return new SecureSmsSender(login, password);
        }

        protected abstract IEnumerable<string> AdditionalParameters { get; }

        protected SmsSender()
        {
            WebClient = new WebClient();
        }

        protected virtual string CreateQueryString(object parameters)
        {
            var parametersPairs = parameters.GetType().GetProperties(BindingFlags.Public)
                .Select(x => string.Format("{0}={1}", x.Name, x.GetValue(parameters, null)))
                .Union(AdditionalParameters);

            return string.Format("?{0}", string.Join("&", parametersPairs));
        } 
    }
}