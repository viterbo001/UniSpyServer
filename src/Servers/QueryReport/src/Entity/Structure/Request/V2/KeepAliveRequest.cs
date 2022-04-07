using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Contract;
using UniSpyServer.Servers.QueryReport.Entity.Enumerate;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V2
{
    [RequestContract(RequestType.KeepAlive)]
    public class KeepAliveRequest : RequestBase
    {
        public KeepAliveRequest(object rawRequest) : base(rawRequest)
        {
        }
    }
}