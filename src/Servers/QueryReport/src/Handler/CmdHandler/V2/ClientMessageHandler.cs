using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Contract;
using UniSpyServer.Servers.QueryReport.Entity.Enumerate;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Redis;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V2;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Response.V2;
using UniSpyServer.UniSpyLib.Abstraction.Interface;

namespace UniSpyServer.Servers.QueryReport.Handler.CmdHandler.V2
{
    [HandlerContract(RequestType.ClientMessage)]
    public sealed class ClientMessageHandler : CmdHandlerBase
    {
        private new ClientMessageRequest _request => (ClientMessageRequest)base._request;
        public static RedisChannel Channel;
        public ClientMessageHandler(IClient client, IRequest request) : base(client, request)
        {
        }
        protected override void RequestCheck()
        {
            // we do not need to execute request.Parse()
        }
        protected override void ResponseConstruct()
        {
            _response = new ClientMessageResponse(_request);
        }
    }
}
