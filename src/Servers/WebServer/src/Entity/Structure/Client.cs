using UniSpyServer.UniSpyLib.Abstraction.BaseClass;
using UniSpyServer.UniSpyLib.Abstraction.Interface;

namespace UniSpyServer.Servers.WebServer.Entity.Structure
{
    public class Client : ClientBase
    {
        public Client(ISession session) : base(session)
        {
            Info = new ClientInfo();
        }
    }
}