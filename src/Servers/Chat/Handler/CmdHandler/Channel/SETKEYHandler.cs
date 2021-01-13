﻿using Chat.Abstraction.BaseClass;
using Chat.Entity.Structure.ChannelInfo;
using Chat.Entity.Structure.ChatCommand;
using UniSpyLib.Abstraction.Interface;

namespace Chat.Handler.CmdHandler.Channel
{
    /// <summary>
    /// set every channel key value on this user
    /// </summary>
    public class SETKEYHandler : ChatLogedInHandlerBase
    {
        new SETKEYRequest _request { get { return (SETKEYRequest)base._request; } }
        public SETKEYHandler(IUniSpySession session, IUniSpyRequest request) : base(session, request)
        {
        }

        protected override void DataOperation()
        {
            base.DataOperation();
            //string buffer = ChatReply.BuildGetKeyReply()
            foreach (var channel in _session.UserInfo.JoinedChannels)
            {
                ChatChannelUser user;
                if (channel.GetChannelUserBySession(_session, out user))
                {
                    user.UpdateUserKeyValue(_request.KeyValues);
                }
            }
        }
    }
}