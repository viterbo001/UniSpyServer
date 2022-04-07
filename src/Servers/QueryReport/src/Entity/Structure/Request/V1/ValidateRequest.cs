using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Contract;
using UniSpyServer.Servers.QueryReport.Entity.Enumerate;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V1
{
    //[RequestContract(RequestType.Validate)]
    public class ValidateRequest : RequestBase
    {
        public ValidateRequest(object rawRequest) : base(rawRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}