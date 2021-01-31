﻿using Chat.Abstraction.BaseClass;
using Chat.Entity.Structure.Misc;
using Chat.Entity.Structure.Request;
using Chat.Entity.Structure.Response.General;
using Chat.Entity.Structure.Result.Channel;
using UniSpyLib.Abstraction.BaseClass;

namespace Chat.Entity.Structure.Response.Channel
{
    internal sealed class SETCKEYResponse : ChatResponseBase
    {
        private new SETCKEYRequest _request => (SETCKEYRequest)base._request;
        private new SETCKEYResult _result => (SETCKEYResult)base._result;
        public SETCKEYResponse(UniSpyRequestBase request, UniSpyResultBase result) : base(request, result)
        {
        }
        protected override void BuildNormalResponse()
        {
            //we only broadcast the b_flags
            string flags = "";
            if (_request.KeyValues.ContainsKey("b_flags"))
            {
                flags += @"\" + "b_flags" + @"\" + _request.KeyValues["b_flags"];
            }

            //todo check the paramemter
            if (_result.IsSetOthersKeyValue)
            {
                SendingBuffer =
                    GETCKEYResponse.BuildGetCKeyReply(
                        _result.NickName,
                        _result.ChannelName,
                        "BCAST", flags);
            }
            else
            {
                SendingBuffer =
                    GETCKEYResponse.BuildGetCKeyReply(
                        _result.NickName,
                        _result.ChannelName,
                        "BCAST", flags); ;
            }
        }
    }
}