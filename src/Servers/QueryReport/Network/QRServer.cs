﻿using QueryReport.Entity.Structure.Redis;
using QueryReport.Handler.CmdSwitcher;
using System;
using System.Net;
using UniSpyLib.Network;

namespace QueryReport.Network
{
    public class QRServer : UniSpyUDPServerBase
    {
        public QRServer(Guid serverID, IPEndPoint endpoint) : base(serverID, endpoint)
        {
            SessionManager = new QRSessionManager();
        }

        public override bool Start()
        {
            PeerGroupInfoRedisOperator.LoadAllGameGroupsToRedis();
            return base.Start();
        }

        protected override UniSpyUDPSessionBase CreateSession(EndPoint endPoint)
            => new QRSession(this, endPoint);

        protected override void OnReceived(UniSpyUDPSessionBase session, byte[] message)
            => new QRCmdSwitcher(session, message).Switch();

    }
}
