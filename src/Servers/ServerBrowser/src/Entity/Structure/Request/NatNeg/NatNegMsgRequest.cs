﻿using UniSpyServer.Servers.ServerBrowser.Abstraction.BaseClass;
using UniSpyServer.Servers.ServerBrowser.Entity.Enumerate;
using System.Linq;
using UniSpyServer.UniSpyLib.Extensions;

namespace UniSpyServer.Servers.ServerBrowser.Entity.Structure.Request
{
    public sealed class NatNegMsgRequest : RequestBase
    {
        public uint Cookie { get; set; }
        public byte[] NatNegMessage => RawRequest;
        public NatNegMsgRequest(object rawRequest) : base(rawRequest)
        {
            CommandName = RequestType.NatNegRequest;
        }

        public override void Parse()
        {
            Cookie = ByteTools.ToUInt16(RawRequest.Skip(6).ToArray());
        }
    }
}
