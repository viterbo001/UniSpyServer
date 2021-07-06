﻿using NatNegotiation.Entity.Structure.Response;
using NatNegotiation.Entity.Structure.Result;
using NatNegotiation.Network;
using UniSpyLib.Abstraction.BaseClass;
using UniSpyLib.Abstraction.Interface;

namespace NatNegotiation.Abstraction.BaseClass
{
    /// <summary>
    /// because we are using self defined error code so we do not need
    /// to send it to client, when we detect errorCode != noerror we just log it
    /// </summary>
    internal abstract class NNCmdHandlerBase : UniSpyCmdHandler
    {
        protected new NNSession _session => (NNSession)base._session;
        protected new NNRequestBase _request => (NNRequestBase)base._request;
        protected new NNResultBase _result
        {
            get => (NNResultBase)base._result;
            set => base._result = value;
        }
        public NNCmdHandlerBase(IUniSpySession session, IUniSpyRequest request) : base(session, request)
        {
            _result = new NNDefaultResult();
        }

        public override void Handle()
        {
            RequestCheck();
            DataOperation();
            ResponseConstruct();
            Response();
        }
        protected override void RequestCheck() { }
        protected override void DataOperation() { }
        protected override void ResponseConstruct()
        {
            _response = new NNDefaultResponse(_request, _result);
        }
    }
}