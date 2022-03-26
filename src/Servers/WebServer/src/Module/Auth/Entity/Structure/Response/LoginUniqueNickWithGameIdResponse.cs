using System.Xml.Linq;
using UniSpyServer.Servers.WebServer.Abstraction;
using UniSpyServer.Servers.WebServer.Entity.Structure;
using UniSpyServer.Servers.WebServer.Module.Auth.Abstraction;
using UniSpyServer.Servers.WebServer.Module.Auth.Entity.Structure.Request;

namespace UniSpyServer.Servers.WebServer.Module.Auth.Entity.Structure.Response
{
    public class LoginUniqueNickWithGameIdResponse : LoginResponseBase
    {
        protected new LoginRemoteAuthRequest _request => (LoginRemoteAuthRequest)base._request;
        protected new LoginResultBase _result => (LoginResultBase)base._result;
        public LoginUniqueNickWithGameIdResponse(RequestBase request, ResultBase result) : base(request, result)
        {
        }
        public override void Build()
        {
            _soapBody.Add(new XElement(SoapXElement.AuthNamespace + "LoginUniqueNickWithGameIdResult"));
            BuildContext();
            base.Build();
        }
    }
}