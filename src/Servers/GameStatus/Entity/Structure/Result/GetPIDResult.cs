﻿using GameStatus.Abstraction.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStatus.Entity.Structure.Result
{
    internal sealed class GetPIDResult : GSResultBase
    {
        public uint ProfileID { get; set; }
        public GetPIDResult()
        {
        }
    }
}
