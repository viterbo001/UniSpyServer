﻿using PresenceConnectionManager.Abstraction.BaseClass;
using PresenceConnectionManager.Entity.Contract;
using PresenceSearchPlayer.Entity.Exception.General;
using UniSpyLib.Abstraction.BaseClass;

namespace PresenceConnectionManager.Entity.Structure.Request.Profile
{
    [RequestContract("newprofile")]
    internal sealed class NewProfileRequest : RequestBase
    {
        //create a new profile with new nick 
        // @"  \newprofile\sesskey\<>\nick\<>\id\1\final\"
        //replace a existed nick with new nick
        //@"  \newprofile\sesskey\<>\nick\<>\replace\1\oldnick\<>\id\1\final\"

        public NewProfileRequest(string rawRequest) : base(rawRequest)
        {
        }

        public string OldNick { get; private set; }
        public string NewNick { get; private set; }
        public bool IsReplaceNickName { get; private set; }
        public override void Parse()
        {
            base.Parse();


            if (KeyValues.ContainsKey("replace"))
            {
                if (!KeyValues.ContainsKey("oldnick") && !KeyValues.ContainsKey("nick"))
                {
                    throw new GPParseException("oldnick or nick is missing.");
                }
                OldNick = KeyValues["oldnick"];
                NewNick = KeyValues["nick"];
                IsReplaceNickName = true;
            }
            else
            {
                if (!KeyValues.ContainsKey("nick"))
                {
                    throw new GPParseException("nick is missing.");
                }
                NewNick = KeyValues["nick"];
                IsReplaceNickName = false;
            }
        }
    }
}