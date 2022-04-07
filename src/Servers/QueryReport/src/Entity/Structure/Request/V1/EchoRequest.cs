using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Contract;
using UniSpyServer.Servers.QueryReport.Entity.Enumerate;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V1
{
    //[RequestContract(RequestType.Echo)]
    public class EchoRequest : RequestBase
    {
        public EchoRequest(object rawRequest) : base(rawRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}