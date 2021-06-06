﻿using PresenceConnectionManager.Abstraction.BaseClass;
using PresenceConnectionManager.Entity.Structure.Request;
using PresenceSearchPlayer.Abstraction.BaseClass;
using PresenceSearchPlayer.Entity.Enumerate;
using System.Linq;
using UniSpyLib.Abstraction.Interface;
using UniSpyLib.Database.DatabaseModel.MySql;

namespace PresenceConnectionManager.Handler.CmdHandler
{
    /// <summary>
    /// handles dell buddy request,remove friends from friends list
    /// </summary>
    internal class DelBuddyHandler : PCMCmdHandlerBase
    {
        protected new DelBuddyRequest _request => (DelBuddyRequest)base._request;
        //delete friend in database then send bm_revoke message to friend
        public DelBuddyHandler(IUniSpySession session, IUniSpyRequest request) : base(session, request)
        {
        }

        protected override void DataOperation()
        {
            using (var db = new unispyContext())
            {
                var result = from friend in db.Friends
                             where friend.Profileid == _request.DeleteProfileID
                                   && friend.Namespaceid == _session.UserInfo.BasicInfo.NamespaceID
                             select friend;
                if (result.Count() == 0)
                {
                    throw new GPGeneralException("No buddy found in database.", GPErrorCode.DatabaseError);
                }
                else if (result.Count() > 1)
                {
                    throw new GPGeneralException("More than one buddy found in database, please check database.", GPErrorCode.DatabaseError);
                }

                db.Friends.Remove(result.FirstOrDefault());
            }
        }
    }
}
