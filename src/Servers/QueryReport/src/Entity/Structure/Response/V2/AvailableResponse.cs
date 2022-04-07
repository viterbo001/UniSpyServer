using System.Collections.Generic;
using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Enumerate;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V2;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Response.V2
{
    public sealed class AvailableResponse : ResponseBase
    {
        public static readonly byte[] ResponsePrefix = { 0xfe, 0xfd, 0x09, 0x00, 0x00, 0x00 };

        public AvailableResponse(AvailableRequest request) : base(request, null)
        {
        }

        public override void Build()
        {
            List<byte> data = new List<byte>();

            data.AddRange(ResponsePrefix);
            data.Add((byte)ServerAvailability.Available);
            // NOTE: Change this if you want to make the server not available.
            SendingBuffer = data.ToArray();
        }
    }
}
