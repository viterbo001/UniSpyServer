﻿using GameSpyLib.Abstraction.Interface;
using NatNegotiation.Entity.Enumerator;
using NatNegotiation.Entity.Structure.Packet;

namespace NatNegotiation.Handler.CommandHandler
{
    public class NatifyHandler : NatNegCommandHandlerBase
    {
        protected InitPacket _initPacket;
        public NatifyHandler(ISession session, byte[] recv) : base(session, recv)
        {
            _initPacket = new InitPacket();
        }

        protected override void CheckRequest()
        {
            _initPacket.Parse(_recv);
        }

        protected override void ConstructResponse()
        {
            _sendingBuffer =
                _initPacket.SetIPAndPortForResponse(_session.RemoteEndPoint)
                .SetPacketType(NatPacketType.ErtTest)
                .BuildResponse();
        }
    }
}
