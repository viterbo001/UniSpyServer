﻿using System.Collections.Generic;
using System.Text;
using UniSpyServer.UniSpyLib.Abstraction.Interface;

namespace UniSpyServer.Servers.Chat.Entity.Structure.Misc.ChannelInfo
{
    public sealed class ChannelUser
    {
        public bool IsVoiceable { get; set; }
        public bool IsChannelCreator { get; set; }
        public bool IsChannelOperator { get; set; }
        public ClientInfo Info { get; private set; }
        public ISession Session { get; private set; }
        public Dictionary<string, string> UserKeyValue { get; private set; }
        public string BFlags => @"\" + Info.UserName + @"\" + UserKeyValue["b_flags"];
        public string Modes
        {
            get
            {
                var buffer = new StringBuilder();

                if (IsChannelOperator)
                {
                    buffer.Append("@");
                }

                if (IsVoiceable)
                {
                    buffer.Append("+");
                }

                return buffer.ToString();
            }
        }
        public ChannelUser(ClientInfo userInfo, ISession session)
        {
            Info = userInfo;
            Session = session;
            UserKeyValue = new Dictionary<string, string>();
        }

        public void SetDefaultProperties(bool isCreator = false, bool isOperator = false)
        {
            IsVoiceable = true;
            IsChannelCreator = isCreator;
            IsChannelOperator = isOperator;
            UserKeyValue.Add("username", Info.UserName);

            if (isCreator)
            {
                UserKeyValue.Add("b_flags", "sh");
            }
            else
            {
                UserKeyValue.Add("b_flags", "s");
            }
        }

        public void UpdateUserKeyValues(Dictionary<string, string> data)
        {
            // TODO check if all key is send through the request or
            // TODO only updated key send through the request
            foreach (var key in data.Keys)
            {
                if (UserKeyValue.ContainsKey(key))
                {
                    //we update the key value
                    UserKeyValue[key] = data[key];
                }
                else
                {
                    UserKeyValue.Add(key, data[key]);
                }
            }
        }

        public string GetUserValues(List<string> keys)
        {
            string values = "";
            foreach (var key in keys)
            {
                if (UserKeyValue.ContainsKey(key))
                {
                    values += @"\" + UserKeyValue[key];
                }
            }
            return values;
        }
    }
}
