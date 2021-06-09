using PresenceSearchPlayer.Entity.Enumerate;
using UniSpyLib.Abstraction.BaseClass;

namespace PresenceSearchPlayer.Entity.Exception.General
{
    public class GPException : UniSpyExceptionBase
    {
        public GPErrorCode ErrorCode { get; private set; }
        public virtual string ErrorResponse => $@"\error\\err\{(uint)ErrorCode}\fatal\\errmsg\{this.Message}\final\";
        public GPException() : this("General Error!", GPErrorCode.General)
        {
        }

        public GPException(string message) : this(message, GPErrorCode.General)
        {
        }

        public GPException(string message, System.Exception innerException) : this(message, GPErrorCode.General, innerException)
        {
        }

        public GPException(string message, GPErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public GPException(string message, GPErrorCode errorCode, System.Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }


    }
}