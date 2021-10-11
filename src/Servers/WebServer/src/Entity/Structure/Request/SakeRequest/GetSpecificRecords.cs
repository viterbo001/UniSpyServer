using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WebServer.Abstraction;
using WebServer.Entity.Contract;

namespace WebServer.Entity.Structure.Request.SakeRequest
{
    [RequestContract("GetSpecificRecords")]
    public class GetSpecificRecordsRequest : RequestBase
    {
        public uint GameId { get; set; }
        public string SecretKey { get; set; }
        public string LoginTicket { get; set; }
        public string TableId { get; set; }
        public List<FieldsObject> RecordIds { get; set; }
        public List<FieldsObject> Fields { get; set; }
        public GetSpecificRecordsRequest(string rawRequest) : base(rawRequest)
        {
            RecordIds = new List<FieldsObject>();
            Fields = new List<FieldsObject>();
        }

        public override void Parse()
        {
            var gameId = _contentElement.Descendants().Where(p => p.Name.LocalName == "gameid").First().Value;
            GameId = uint.Parse(gameId);
            var secretKey = _contentElement.Descendants().Where(p => p.Name.LocalName == "secretKey").First().Value;
            SecretKey = secretKey;
            var loginTicket = _contentElement.Descendants().Where(p => p.Name.LocalName == "loginTicket").First().Value;
            LoginTicket = loginTicket;
            var tableid = _contentElement.Descendants().Where(p => p.Name.LocalName == "tableid").First().Value;
            TableId = tableid;
            var recordidsNode = _contentElement.Descendants().Where(p => p.Name.LocalName == "recordids").First();
            foreach (XElement element in recordidsNode.Nodes())
            {
                RecordIds.Add(new FieldsObject(element.Value, element.Name.LocalName));
            }
            var fieldsNode = _contentElement.Descendants().Where(p => p.Name.LocalName == "fields").First();
            foreach (XElement element in fieldsNode.Nodes())
            {
                Fields.Add(new FieldsObject(element.Value, element.Name.LocalName));
            }
        }
    }
}