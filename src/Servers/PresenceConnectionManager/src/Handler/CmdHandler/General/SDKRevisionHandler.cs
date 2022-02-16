﻿using UniSpyServer.UniSpyLib.Abstraction.Interface;
using UniSpyServer.Servers.PresenceConnectionManager.Abstraction.BaseClass;
using UniSpyServer.Servers.PresenceConnectionManager.Entity.Contract;
using UniSpyServer.Servers.PresenceConnectionManager.Entity.Structure.Request;

namespace UniSpyServer.Servers.PresenceConnectionManager.Handler.CmdHandler
{
    [HandlerContract("sdk")]
    public sealed class SdkRevisionHandler : CmdHandlerBase
    {
        private new LoginRequest _request => (LoginRequest)base._request;
        public SdkRevisionHandler(IClient client, IRequest request) : base(client, request)
        {
        }
        protected override void RequestCheck() { }
        protected override void DataOperation()
        {
            if (_session.UserInfo.SDKRevision.IsSupportGPINewListRetrevalOnLogin)
            {
                //send buddy list and block list
                new BuddyListHandler(_session, null).Handle();
                new BlockListHandler(_session, null).Handle();
            }
        }
    }
}
