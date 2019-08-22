﻿using GameSpyLib.Logging;
using GameSpyLib.Network;
using QueryReport.Structures;
using System;

namespace QueryReport.Handler
{
    public class ChallengeHandler
    {
        /// <summary>
        /// Our hardcoded Server Validation code
        /// </summary>
        private static readonly byte[] ServerValidateCode = {
                0x72, 0x62, 0x75, 0x67, 0x4a, 0x34, 0x34, 0x64, 0x34, 0x7a, 0x2b,
                0x66, 0x61, 0x78, 0x30, 0x2f, 0x74, 0x74, 0x56, 0x56, 0x46, 0x64,
                0x47, 0x62, 0x4d, 0x7a, 0x38, 0x41, 0x00
            };


        public static void ServerChallengeResponse(QRServer server, UdpPacket packet)
        {
           
            byte[] challenge = new byte[90];

            int blen = 0;
            byte[] sendingbuffer = new byte[7];
            sendingbuffer[0] = QR.QRMagic1;
            sendingbuffer[1] = QR.QRMagic2;
            sendingbuffer[2] = QRGameServerRequest.ClientRegistered;
            Array.Copy(packet.BytesRecieved, 1, sendingbuffer, 3, 4);
            server.SendAsync(packet, sendingbuffer);
            
            LogWriter.Log.Write("[QR] No impliment function for ServerChallengeResponse!", LogLevel.Debug);
        }
    }
}
