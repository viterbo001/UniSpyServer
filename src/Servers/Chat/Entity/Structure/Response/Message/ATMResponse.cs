﻿using Chat.Abstraction.BaseClass;
using Chat.Entity.Structure.Misc;
using Chat.Entity.Structure.Request.Message;
using Chat.Entity.Structure.Result.Message;
using UniSpyLib.Abstraction.BaseClass;

namespace Chat.Entity.Structure.Response.Message
{
    internal sealed class ATMResponse : ResponseBase
    {
        private new ATMResult _result => (ATMResult)base._result;
        private new AboveTheTableMsgRequest _request => (AboveTheTableMsgRequest)base._request;
        public ATMResponse(UniSpyRequestBase request, UniSpyResultBase result) : base(request, result)
        {
        }

        public override void Build()
        {
            string cmdParams = $"{_result.TargetName} {_request.Message}";
            SendingBuffer = ChatIRCReplyBuilder.Build(_result.UserIRCPrefix, ChatReplyName.ATM, cmdParams);
        }
    }
}
