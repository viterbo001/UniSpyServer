﻿using UniSpyServer.Servers.PresenceConnectionManager.Abstraction.BaseClass;
using UniSpyServer.Servers.PresenceConnectionManager.Entity.Contract;
using UniSpyServer.Servers.PresenceSearchPlayer.Entity.Exception.General;
using UniSpyServer.UniSpyLib.MiscMethod;

namespace UniSpyServer.Servers.PresenceConnectionManager.Entity.Structure.Request.General
{
    [RequestContract("newuser")]
    public sealed class NewUserRequest : RequestBase
    {
        public int ProductID { get; private set; }
        public int GamePort { get; private set; }
        public string CDKeyEnc { get; private set; }
        public bool HasGameNameFlag { get; private set; }
        public bool HasProductIDFlag { get; private set; }
        public bool HasCDKeyEncFlag { get; private set; }
        public bool HasPartnerIDFlag { get; private set; }
        public bool HasGamePortFlag { get; private set; }
        public string Nick { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Uniquenick { get; private set; }
        public int PartnerID { get; private set; }
        public string GameName { get; private set; }
        public int NamespaceID { get; private set; }
        public NewUserRequest(string rawRequest) : base(rawRequest)
        {
        }
        public override void Parse()
        {
            base.Parse();
            string md5Password;
            if (!PasswordEncoder.ProcessPassword(RequestKeyValues, out md5Password))
            {
                throw new GPParseException("password provided is invalid.");
            }
            Password = md5Password;

            if (!RequestKeyValues.ContainsKey("nick"))
            {
                throw new GPParseException("nickname is missing.");
            }
            Nick = RequestKeyValues["nick"];

            if (!RequestKeyValues.ContainsKey("email"))
            {
                throw new GPParseException("email is missing.");
            }
            if (!GameSpyUtils.IsEmailFormatCorrect(RequestKeyValues["email"]))
            {
                throw new GPParseException("email format is incorrect.");
            }
            Email = RequestKeyValues["email"];

            if (RequestKeyValues.ContainsKey("uniquenick") && RequestKeyValues.ContainsKey("namespaceid"))
            {
                if (RequestKeyValues.ContainsKey("namespaceid"))
                {
                    int namespaceID;
                    if (!int.TryParse(RequestKeyValues["namespaceid"], out namespaceID))
                    {
                        throw new GPParseException("namespaceid is incorrect.");
                    }
                    NamespaceID = namespaceID;
                }
                Uniquenick = RequestKeyValues["uniquenick"];
            }
            ParseOtherInfo();
        }

        private void ParseOtherInfo()
        {
            //parse other info
            if (RequestKeyValues.ContainsKey("partnerid"))
            {
                int partnerid;
                if (!int.TryParse(RequestKeyValues["partnerid"], out partnerid))
                {
                    throw new GPParseException("partnerid is incorrect.");
                }
                HasPartnerIDFlag = true;
                PartnerID = partnerid;
            }

            if (RequestKeyValues.ContainsKey("productid"))
            {
                int productid;
                if (!int.TryParse(RequestKeyValues["productid"], out productid))
                {
                    throw new GPParseException("productid is incorrect.");
                }
                HasProductIDFlag = true;
                ProductID = productid;
            }

            if (RequestKeyValues.ContainsKey("gamename"))
            {
                HasGameNameFlag = true;
                GameName = RequestKeyValues["gamename"];
            }

            if (RequestKeyValues.ContainsKey("port"))
            {
                int port;
                if (!int.TryParse(RequestKeyValues["port"], out port))
                {
                    throw new GPParseException("port is incorrect.");
                }
                HasGamePortFlag = true;
                GamePort = port;
            }

            if (RequestKeyValues.ContainsKey("cdkeyenc"))
            {
                HasCDKeyEncFlag = true;
                CDKeyEnc = RequestKeyValues["cdkeyenc"];
            }
        }
    }
}
