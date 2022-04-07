using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Result.V2
{
    public sealed class ChallengeResult : ResultBase
    {
        public ChallengeResult()
        {
            PacketType = Enumerate.PacketType.Challenge;
        }
    }
}
