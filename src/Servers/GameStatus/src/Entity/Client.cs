using UniSpyServer.UniSpyLib.Abstraction.BaseClass;
using UniSpyServer.UniSpyLib.Abstraction.Interface;

namespace UniSpyServer.Servers.GameStatus.Entity
{
    public class Client : ClientBase
    {
        public Client(ISession session) : base(session)
        {
        }
    }
}