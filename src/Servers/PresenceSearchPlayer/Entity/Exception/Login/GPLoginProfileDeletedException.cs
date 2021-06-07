using System;
using PresenceSearchPlayer.Abstraction.BaseClass;
using PresenceSearchPlayer.Entity.Enumerate;

namespace PresenceSearchPlayer.Entity.Exception.Login
{
    public class GPLoginProfileDeletedException : GPLoginException
    {
        public GPLoginProfileDeletedException() : base("User's profile has been deleted!", GPErrorCode.LoginProfileDeleted)
        {
        }

        public GPLoginProfileDeletedException(string message) : base(message, GPErrorCode.LoginProfileDeleted)
        {
        }

        public GPLoginProfileDeletedException(string message, System.Exception innerException) : base(message, GPErrorCode.LoginProfileDeleted, innerException)
        {
        }
    }
}