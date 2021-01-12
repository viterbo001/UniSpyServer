﻿using System;
using UniSpyLib.Abstraction.BaseClass;

namespace CDKey.Abstraction.BaseClass
{
    internal abstract class CDKeyResponseBase : UniSpyResponseBase
    {
        protected new CDKeyRequestBase _request => (CDKeyRequestBase)base._request;
        protected new CDKeyResultBase _result => (CDKeyResultBase)base._result;
        public CDKeyResponseBase(UniSpyRequestBase request, UniSpyResultBase result) : base(request, result)
        {
        }

        public override void Build()
        {
            throw new NotImplementedException();
        }

        protected override void BuildErrorResponse()
        {
            throw new NotImplementedException();
        }

        protected override void BuildNormalResponse()
        {
            throw new NotImplementedException();
        }
    }
}
