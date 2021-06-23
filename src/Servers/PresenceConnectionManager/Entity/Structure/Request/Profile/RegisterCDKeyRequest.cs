﻿using PresenceConnectionManager.Abstraction.BaseClass;
using PresenceSearchPlayer.Entity.Exception.General;
using UniSpyLib.Abstraction.BaseClass;

namespace PresenceConnectionManager.Entity.Structure.Request
{
    /// <summary>
    /// \registercdkey\sesskey\<sesskey>\cdkeyenc\<cdkeyenc>\id\<id>\final\
    /// </summary>
    [Command("registercdkey")]
    internal sealed class RegisterCDKeyRequest : PCMRequestBase
    {
        public string CDKeyEnc { get; private set; }
        public RegisterCDKeyRequest(string rawRequest) : base(rawRequest)
        {
        }

        public override void Parse()
        {
            base.Parse();


            if (!KeyValues.ContainsKey("cdkeyenc"))
            {
                throw new GPParseException("cdkeyenc is missing.");
            }

            CDKeyEnc = KeyValues["cdkeyenc"];
        }
    }
}
