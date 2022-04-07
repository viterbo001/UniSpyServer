using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Response.V2
{
    public sealed class KeepAliveResponse : ResponseBase
    {
        public KeepAliveResponse(RequestBase request, ResultBase result) : base(request, result)
        {
        }
    }
}
