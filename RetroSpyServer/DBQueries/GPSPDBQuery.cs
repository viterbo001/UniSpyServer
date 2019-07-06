﻿using GameSpyLib.Database;
using System.Collections.Generic;

namespace RetroSpyServer.DBQueries
{
    public class GPSPDBQuery : DBQueryBase
    {

        public GPSPDBQuery(DatabaseDriver dbdriver) : base(dbdriver)
        {
        }

        public bool IsEmailValid(string Email)
        {
            return Query("SELECT userid FROM users WHERE `email`=@P0", Email).Count > 0;
        }

        public List<Dictionary<string, object>> RetriveNicknames(string email, string password)
        {
            return Query("SELECT profiles.nick, profiles.uniquenick FROM profiles INNER JOIN users ON profiles.userid=users.userid WHERE LOWER(users.email)=@P0 AND LOWER(users.password)=@P1", email.ToLowerInvariant(), password.ToLowerInvariant());
        }
    }
}