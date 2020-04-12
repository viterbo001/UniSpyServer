﻿using System.Timers;
using GameSpyLib.Logging;

namespace GameSpyLib.Common.BaseClass
{
    public abstract class ExpireManagerBase
    { 
        protected static Timer _checkTimer;

        public ExpireManagerBase()
        {
            //default settings
            _checkTimer = new Timer
            {
                Enabled = true, Interval = 10000, AutoReset = true
            };//10000
        }

        public void Start()
        {
            _checkTimer.Start();
            _checkTimer.Elapsed += (s, e) => CheckExpire();
        }

        protected virtual void CheckExpire()
        {
            //log which expire manager excuted
            LogWriter.ToLog(Serilog.Events.LogEventLevel.Verbose,$"=>[{GetType().Name}]");
        }


    }
}