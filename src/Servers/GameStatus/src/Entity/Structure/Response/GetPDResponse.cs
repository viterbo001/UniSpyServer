﻿using UniSpyServer.Servers.GameStatus.Abstraction.BaseClass;
using UniSpyServer.Servers.GameStatus.Entity.Structure.Request;
using UniSpyServer.Servers.GameStatus.Entity.Structure.Result;
using UniSpyServer.UniSpyLib.Abstraction.BaseClass;

namespace UniSpyServer.Servers.GameStatus.Entity.Structure.Response
{
    public sealed class GetPDResponse : ResponseBase
    {
        private new GetPDResult _result => (GetPDResult)base._result;
        private new GetPlayerDataRequest _request => (GetPlayerDataRequest)base._request;
        public GetPDResponse(UniSpyRequestBase request, UniSpyResultBase result) : base(request, result)
        {
        }

        public override void Build()
        {
            SendingBuffer = $@"\getpdr\1\pid\{_request.ProfileID}\lid\{_request.OperationID}\mod\1234\length\5\data\mydata\final\";
        }
    }
}
