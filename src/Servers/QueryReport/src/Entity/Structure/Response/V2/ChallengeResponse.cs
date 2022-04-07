using System.Collections.Generic;
using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Request.V2;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Result.V2;
using UniSpyServer.UniSpyLib.Encryption;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Response.V2
{
    public sealed class ChallengeResponse : ResponseBase
    {
        private static string Message = "RetroSpy echo!";

        public ChallengeResponse(ChallengeRequest request, ChallengeResult result) : base(request, result)
        {
        }

        public override void Build()
        {
            base.Build();
            List<byte> data = new List<byte>();

            data.AddRange(SendingBuffer);
            data.AddRange(UniSpyEncoding.GetBytes(Message));

            SendingBuffer = data.ToArray();
        }
    }
}
