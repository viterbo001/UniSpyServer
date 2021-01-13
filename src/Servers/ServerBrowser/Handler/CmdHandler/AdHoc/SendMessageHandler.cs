﻿using UniSpyLib.Abstraction.Interface;
using ServerBrowser.Abstraction.BaseClass;
using ServerBrowser.Entity.Structure.Request;

namespace ServerBrowser.Handler.CmdHandler
{
    public class SendMessageHandler : SBCmdHandlerBase
    {
        protected new AdHocRequest _request { get { return (AdHocRequest)base._request; } }
        public SendMessageHandler(IUniSpySession session, IUniSpyRequest request) : base(session, request)
        {
        }

        protected override void DataOperation()
        {
            base.DataOperation();
            _session.ServerMessageList.Add(_request);
        }
    }
}