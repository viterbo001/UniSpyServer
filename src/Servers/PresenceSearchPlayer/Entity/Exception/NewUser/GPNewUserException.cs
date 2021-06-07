using System;
using PresenceSearchPlayer.Abstraction.BaseClass;
using PresenceSearchPlayer.Entity.Enumerate;
using PresenceSearchPlayer.Entity.Exception.General;

namespace PresenceSearchPlayer.Entity.Exception.NewUser
{
    public class GPNewUserException : GPException
    {

        public override string ErrorResponse => $@"\nur\{(uint)ErrorCode}\final\";
        public GPNewUserException() : this("There was an unknown error creating user account.", GPErrorCode.NewUser)
        {
        }
        public GPNewUserException(string message) : base(message, GPErrorCode.NewUser)
        {
        }
        public GPNewUserException(string message, System.Exception innerException) : base(message, GPErrorCode.NewUser, innerException)
        {
        }

        public GPNewUserException(string message, GPErrorCode errorCode) : base(message, errorCode)
        {
        }

        public GPNewUserException(string message, GPErrorCode errorCode, System.Exception innerException) : base(message, errorCode, innerException)
        {
        }
    }
}