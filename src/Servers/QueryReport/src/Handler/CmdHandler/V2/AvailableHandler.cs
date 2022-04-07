using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Contract;
using UniSpyServer.Servers.QueryReport.Entity.Enumerate;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V2;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Response.V2;
using UniSpyServer.UniSpyLib.Abstraction.Interface;

namespace UniSpyServer.Servers.QueryReport.Handler.CmdHandler.V2
{
    [HandlerContract(RequestType.AvailableCheck)]
    public sealed class AvailableHandler : CmdHandlerBase
    {
        private new AvailableRequest _request => (AvailableRequest)base._request;
        public AvailableHandler(IClient client, IRequest request) : base(client, request)
        {
        }
        protected override void ResponseConstruct()
        {
            _response = new AvailableResponse(_request);
        }
    }
}
