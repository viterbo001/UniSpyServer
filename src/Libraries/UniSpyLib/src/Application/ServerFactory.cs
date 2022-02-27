﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using UniSpyServer.UniSpyLib.Abstraction.Interface;
using UniSpyServer.UniSpyLib.Application.Network.Http.Server;
using UniSpyServer.UniSpyLib.Application.Network.Tcp.Server;
using UniSpyServer.UniSpyLib.Application.Network.Udp.Server;
using UniSpyServer.UniSpyLib.Config;
using UniSpyServer.UniSpyLib.Database.DatabaseModel;

namespace UniSpyServer.UniSpyLib.Abstraction.BaseClass.Factory
{
    public class ServerFactory
    {
        /// <summary>
        /// UniSpy server version
        /// </summary>
        public static readonly string Version = "0.7.0";
        /// <summary>
        /// UniSpy server name
        /// </summary>
        /// <returns></returns>
        public static string ServerName { get; protected set; }
        public static Dictionary<string, IServer> Servers { get; protected set; }
        public static IServer Server;
        static ServerFactory()
        {
            Servers = new Dictionary<string, IServer>();
        }
        public ServerFactory(string serverNames)
        {
            ServerName = serverNames;
        }

        public virtual void Start()
        {
            Console.Title = $"UniSpyServer  {Version} - {ServerName}";
            ShowUniSpyLogo();
            ConnectMySql();
            ConnectRedis();
            LoadServerConfig();
        }
        protected void LoadServerConfig()
        {
            var cfg = ConfigManager.Config.Servers.Where(s => s.ServerName == ServerName).First();
            var serverParams = new object[] { cfg.ServerID, cfg.ServerName, cfg.ListeningEndPoint };
            switch (cfg.SocketType)
            {
                case "Udp":
                    Server = (IServer)Activator.CreateInstance(typeof(UdpServer), serverParams);
                    break;
                case "Tcp":
                    Server = (IServer)Activator.CreateInstance(typeof(TcpServer), serverParams);
                    break;
                case "Http":
                    Server = (IServer)Activator.CreateInstance(typeof(HttpServer), serverParams);
                    break;
                default:
                    throw new Exception($"Unsupported socket type:{cfg.SocketType} please check config file");
            }
            if (Server == null)
            {
                throw new Exception("Server created failed");
            }
            // asp.net web server does not implement a Server interface, therefore this code should not be called
            Server.Start();
            var table = new ConsoleTable("Server Name", "Listening Address", "Listening Port");
            table.AddRow(ServerName, Server.Endpoint.Address, Server.Endpoint.Port);
            table.Write(ConsoleTables.Format.Alternative);
            Servers.Add(cfg.ServerName, Server);
            Console.WriteLine("Server successfully started!");
        }

        protected void ConnectRedis()
        {
            var redisConfig = ConfigManager.Config.Redis;
            try
            {
                StackExchange.Redis.ConnectionMultiplexer.Connect(redisConfig.ConnectionString);
            }
            catch (Exception e)
            {
                throw new Exception("Can not connect to Redis", e);
            }
            Console.WriteLine($"Successfully connected to Redis at {redisConfig.Server}:{redisConfig.Port}");
        }
        protected void ConnectMySql()
        {
            //Determine which database is used and establish the database connection.
            var dbConfig = ConfigManager.Config.Database;
            try
            {
                new UniSpyContext().Database.CanConnect();
            }
            catch (Exception e)
            {
                throw new Exception($"Can not connect to {dbConfig.Type}!", e);
            }

            Console.WriteLine($"Successfully connected to {dbConfig.Type} at {dbConfig.Server}:{dbConfig.Port}");
        }
        protected static void ShowUniSpyLogo()
        {
            // the ascii art font name is "small"
            Console.WriteLine(@" _   _      _ ___           ___ ");
            Console.WriteLine(@"| | | |_ _ (_) __|_ __ _  _/ __| ___ _ ___ _____ _ _ ");
            Console.WriteLine(@"| |_| | ' \| \__ \ '_ \ || \__ \/ -_) '_\ V / -_) '_|");
            Console.WriteLine(@" \___/|_||_|_|___/ .__/\_, |___/\___|_|  \_/\___|_|");
            Console.WriteLine(@"                 |_|   |__/ ");
            Console.WriteLine(@"Version: " + Version);
        }
    }
}
