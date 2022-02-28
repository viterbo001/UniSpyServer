﻿using UniSpyServer.Servers.Chat.Abstraction.BaseClass;
using UniSpyServer.Servers.Chat.Entity.Contract;

namespace UniSpyServer.Servers.Chat.Entity.Structure.Request.General
{
    [RequestContract("CDKEY")]
    public sealed class CDKeyRequest : RequestBase
    {
        public CDKeyRequest(string rawRequest) : base(rawRequest)
        {
        }

        public string CDKey { get; private set; }

        public override void Parse()
        {
            base.Parse();

            if (_cmdParams.Count < 1)
            {
                throw new Exception.ChatException("The number of IRC cmdParams are incorrect.");
            }

            CDKey = _cmdParams[0];
        }
    }
}
