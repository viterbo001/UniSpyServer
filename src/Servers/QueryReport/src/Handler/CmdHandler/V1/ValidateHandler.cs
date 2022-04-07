using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Contract;
using UniSpyServer.Servers.QueryReport.Entity.Enumerate;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V1;
using UniSpyServer.UniSpyLib.Abstraction.Interface;

namespace UniSpyServer.Servers.QueryReport.Handler.CmdHandler.V1
{
    //[HandlerContract(RequestType.Validate)]
    public sealed class ValidateHandler : CmdHandlerBase
    {
        private new ValidateRequest _request => (ValidateRequest)base._request;
        public ValidateHandler(IClient client, IRequest request) : base(client, request)
        {
        }
    }
}
