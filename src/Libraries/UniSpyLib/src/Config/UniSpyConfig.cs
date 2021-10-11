﻿using System;
using System.Collections.Generic;
using System.Net;
using Serilog.Events;
using UniSpyLib.Database;

namespace UniSpyLib.Config
{
    public class UniSpyConfig
    {
        public UniSpyDatabaseConfig Database;
        public UniSpyRedisConfig Redis;
        public List<UniSpyServerConfig> Servers;
        public LogEventLevel MinimumLogLevel;
    }
    public class UniSpyDatabaseConfig
    {
        public DatabaseType Type;
        public string RemoteAddress;
        public int RemotePort;
        public string UserName;
        public string Password;
        public string DatabaseName;
        public string SslMode;
        public string SslCert;
        public string SslKey;
        public string SslCa;
    }
    public class UniSpyRedisConfig
    {
        public string RemoteAddress;
        public int RemotePort;
    }
    public class UniSpyServerConfig
    {
        public Guid ServerID;
        public string ServerName;
        public IPEndPoint ListeningEndPoint => new IPEndPoint(IPAddress.Parse(ListeningAddress), ListeningPort);
        public string ListeningAddress;
        public int ListeningPort;
        public string RemoteAddress;
        public int RemotePort;
    }
}