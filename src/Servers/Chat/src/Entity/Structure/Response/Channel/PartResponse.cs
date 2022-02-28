﻿using UniSpyServer.Servers.Chat.Abstraction.BaseClass;
using UniSpyServer.Servers.Chat.Entity.Structure.Misc;
using UniSpyServer.Servers.Chat.Entity.Structure.Result.Channel;

namespace UniSpyServer.Servers.Chat.Entity.Structure.Response.Channel
{
    public sealed class PartResponse : ResponseBase
    {
        private new PartResult _result => (PartResult)base._result;
        public PartResponse(UniSpyLib.Abstraction.BaseClass.RequestBase request, UniSpyLib.Abstraction.BaseClass.ResultBase result) : base(request, result)
        {
        }

        public override void Build()
        {
            SendingBuffer = BuildPartReply(
                _result.LeaverIRCPrefix,
                _result.ChannelName,
                _result.Message);
        }

        public static string BuildPartReply(string userIRCPrefix, string channelName, string message)
        {
            return IRCReplyBuilder.Build(
                userIRCPrefix,
                ResponseName.Part,
                channelName,
                message);
        }
    }
}
