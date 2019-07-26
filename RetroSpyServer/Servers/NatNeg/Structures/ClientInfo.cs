﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RetroSpyServer.Servers.NatNeg
{
    public class ClientInfo
    {
        public DateTime ConnectTime;
        public DateTime LastPacketTime;
        public GameInfo game;
        public byte Version=0;
        public int Cookie=0;
        public int ClientID=0;
        public byte ClientIndex=0;
        public bool Connected = false;
        public bool GotPreInit = false;
        public bool GotInit = false;
        public bool GotConnectAck = false;

        //These two viraibles is only for server to determine the clientinfo
        public int SocketStatus;//socket status is representing a socket availability,in C# it is not need.
        
        public int ClientInstance;//represent a instance of clientinfo in natneg server
        //public ClientInfo(int sd, int instance)
        //{
        //    SocketStatus = sd;
        //    SocketInstance = instance;
        //}
        public ClientInfo()
        {

        }
        public ClientInfo(int clientInstance)
        {
            ClientInstance = clientInstance;
        }

        public ClientInfo(byte version, int cookie, byte clientIndex, bool gotinit, int clientInstance)
        {
            Version = version;
            Cookie = cookie;
            ClientIndex = clientIndex;
            ClientInstance = clientInstance;
            GotInit = gotinit;
        }
    }
}
