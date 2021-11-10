using System.IO;
using Newtonsoft.Json;
using UniSpyServer.UniSpyLib.Abstraction.Interface;
using UniSpyServer.Servers.WebServer.Abstraction;
using UniSpyServer.Servers.WebServer.Entity.Structure.Request.SakeRequest;
using UniSpyServer.Servers.WebServer.Entity.Structure;

namespace UniSpyServer.Servers.WebServer.Handler.CmdHandler
{
    public class CreateRecordHandler : SakeHandlerBase
    {
        protected new CreateRecordRequest _request => (CreateRecordRequest)base._request;
        public CreateRecordHandler(IUniSpySession session, IUniSpyRequest request) : base(session, request)
        {
        }
        protected override void DataOperation()
        {
            base.DataOperation();
            var jsonStr = JsonConvert.SerializeObject(_request.Values);
            File.WriteAllText(_sakeFilePath, jsonStr);
        }
    }
}