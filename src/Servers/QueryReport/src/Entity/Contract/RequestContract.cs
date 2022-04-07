using UniSpyServer.Servers.QueryReport.Entity.Enumerate;
using UniSpyServer.UniSpyLib.Abstraction.Contract;

namespace UniSpyServer.Servers.QueryReport.Entity.Contract
{
    public class RequestContract : RequestContractBase
    {
        public new RequestType Name => (RequestType)base.Name;

        public RequestContract(RequestType name) : base(name)
        {
        }
    }
}