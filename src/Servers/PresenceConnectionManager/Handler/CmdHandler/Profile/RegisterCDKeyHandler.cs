﻿using UniSpyLib.Abstraction.Interface;
using UniSpyLib.Database.DatabaseModel.MySql;
using  PresenceConnectionManager.Entity.Structure.Request;
using PresenceSearchPlayer.Entity.Enumerate;
using System.Collections.Generic;
using System.Linq;
using PresenceConnectionManager.Abstraction.BaseClass;

namespace PresenceConnectionManager.Handler.CmdHandler
{
    internal class RegisterCDKeyHandler : PCMCmdHandlerBase
    {
        protected new RegisterCDKeyRequest _request
        {
            get { return (RegisterCDKeyRequest)base._request; }
        }
        public RegisterCDKeyHandler(IUniSpySession session, IUniSpyRequest request) : base(session, request)
        {
        }

        protected override void DataOperation()
        {
            using (var db = new retrospyContext())
            {
                var result = db.Subprofiles.Where(s => s.Profileid == _session.UserInfo.ProfileID
                && s.Namespaceid == _session.UserInfo.NamespaceID);
                //&& s.Productid == _session.UserInfo.ProductID);

                if (result.Count() == 0 || result.Count() > 1)
                {
                    _result.ErrorCode = GPErrorCode.DatabaseError;
                }

                db.Subprofiles.Where(s => s.Subprofileid == _session.UserInfo.SubProfileID)
                    .FirstOrDefault().Cdkeyenc = _request.CDKeyEnc;

                db.SaveChanges();
            }
        }
    }
}