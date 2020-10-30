﻿using Chat.Entity.Structure;
using Chat.Entity.Structure.ChatCommand;
using Chat.Entity.Structure.ChatResponse.ChatGeneralResponse;
using GameSpyLib.Abstraction.Interface;

namespace Chat.Handler.CommandHandler.ChatGeneralCommandHandler
{
    public class PINGHandler : ChatCommandHandlerBase
    {
        new PINGRequest _request;
        public PINGHandler(ISession session, ChatRequestBase request) : base(session, request)
        {
            _request = (PINGRequest)request;
        }

        protected override void BuildNormalResponse()
        {
            base.BuildNormalResponse();
            _sendingBuffer = PINGReply.BuildPingReply(_session.UserInfo);
        }
    }
}
