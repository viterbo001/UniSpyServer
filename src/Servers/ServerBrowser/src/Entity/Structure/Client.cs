using UniSpyServer.UniSpyLib.Abstraction.BaseClass;
using UniSpyServer.UniSpyLib.Abstraction.Interface;

namespace UniSpyServer.Servers.ServerBrowser.Entity.Structure
{
    public class Client : ClientBase
    {
        public new ClientInfo Info { get => (ClientInfo)base.Info; set => base.Info = value; }
        public Client(ISession session) : base(session)
        {
            Info = new ClientInfo(session.RemoteIPEndPoint);
            // Crypto is init in ServerListHandler
        }
    }
}