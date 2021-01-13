﻿using System;
using System.Collections.Generic;
using System.Linq;
using CDKey.Entity.Structure;
using UniSpyLib.Abstraction.BaseClass;
using UniSpyLib.Abstraction.Interface;
using UniSpyLib.Logging;
using UniSpyLib.MiscMethod;

namespace CDKey.Handler.CmdSwitcher
{
    internal class CDKeyRequestSerializer : UniSpyRequestSerializerBase
    {
        protected new string _rawRequest;
        public CDKeyRequestSerializer(object rawRequest) : base(rawRequest)
        {
            _rawRequest = (string)rawRequest;
        }

        public override IUniSpyRequest Serialize()
        {
            var kv = GameSpyUtils.ConvertToKeyValue(_rawRequest);

            switch (kv.Keys.First())
            {
                //keep client alive request, we skip this
                case RequestName.KA:
                    return null;
                case RequestName.Auth:
                    return null;
                case RequestName.Resp:
                    return null;
                case RequestName.SKey:
                    return null;
                case RequestName.Disc://disconnect from server
                    return null;
                case RequestName.UON:
                    return null;
                default:
                    LogWriter.UnknownDataRecieved(_rawRequest);
                    return null;
            }
        }
    }
}