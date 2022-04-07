using UniSpyServer.Servers.QueryReport.Abstraction.BaseClass;
using UniSpyServer.Servers.QueryReport.Entity.Structure.Redis.GameServer;

namespace UniSpyServer.Servers.QueryReport.Entity.Structure.Result.V2
{
    public sealed class EchoResult : ResultBase
    {
        public GameServerInfo Info { get; set; }
        public EchoResult()
        {
        }
    }
}
