﻿using System;
using GameStatus.Abstraction.BaseClass;
using UniSpyLib.Abstraction.BaseClass;

namespace GameStatus.Entity.Structure.Response
{
    internal sealed class GSDefaultResponse : GSResponseBase
    {
        public GSDefaultResponse(UniSpyRequestBase request, UniSpyResultBase result) : base(request, result)
        {
        }

        public override void Build()
        {
        }
    }
}
