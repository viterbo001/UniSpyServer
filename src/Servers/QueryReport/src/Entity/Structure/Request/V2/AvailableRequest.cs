using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Contract;
using UniSpyServer.Servers.QueryReport.Entity.Enumerate;
using UniSpyServer.Servers.QueryReport.Entity.Exception;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V2
{
    [RequestContract(RequestType.AvailableCheck)]
    public sealed class AvailableRequest : RequestBase
    {
        public static readonly byte[] Prefix = { 0x09, 0x00, 0x00, 0x00, 0x00 };
        public static readonly byte Postfix = 0x00;
        public AvailableRequest(object rawRequest) : base(rawRequest)
        {
        }

        public override void Parse()
        {
            base.Parse();
            //prefix check
            for (int i = 0; i < AvailableRequest.Prefix.Length; i++)
            {
                if (RawRequest[i] != AvailableRequest.Prefix[i])
                {
                    throw new QRException("Available request prefix is invalid.");
                }
            }

            //postfix check
            if (RawRequest[RawRequest.Length - 1] != AvailableRequest.Postfix)
            {
                throw new QRException("Available request postfix is invalid.");
            }
        }
    }
}
