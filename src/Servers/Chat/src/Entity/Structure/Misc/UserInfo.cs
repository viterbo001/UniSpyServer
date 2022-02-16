﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using UniSpyServer.Servers.Chat.Entity.Structure.Misc.ChannelInfo;
using UniSpyServer.UniSpyLib.Abstraction.BaseClass;

namespace UniSpyServer.Servers.Chat.Entity.Structure.Misc
{
    public sealed class UserInfo : UserInfoBase
    {
        //indicates which channel this user is in
        public IDictionary<string, Channel> JoinedChannels { get; private set; }
        public Session Session { get; private set; }
        // secure connection
        public PeerChatCTX ClientCTX { get; set; }
        public PeerChatCTX ServerCTX { get; private set; }
        public string GameName { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string ServerIP { get; set; }
        public int NameSpaceID { get; set; }
        public string UniqueNickName { get; set; }
        public string GameSecretKey { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsUsingEncryption { get; set; }
        public bool IsQuietMode { get; set; }
        public string PublicIPAddress => Session.RemoteIPEndPoint.Address.ToString();
        public string IRCPrefix => $"{NickName}!{UserName}@{ChatConstants.ServerDomain}";

        public UserInfo(Session session)
        {
            Session = session;
            ClientCTX = new PeerChatCTX();
            ServerCTX = new PeerChatCTX();
            JoinedChannels = new ConcurrentDictionary<string, Channel>();
            NameSpaceID = 0;
            IsUsingEncryption = false;
            IsQuietMode = false;
            IsLoggedIn = false;
        }

        public bool IsJoinedChannel(string channelName) => JoinedChannels.ContainsKey(channelName);

        public Channel GetJoinedChannel(string channelName)
        {
            if (JoinedChannels.ContainsKey(channelName))
            {
                return JoinedChannels[channelName];
            }
            else
            {
                return null;
            }
        }
    }
}