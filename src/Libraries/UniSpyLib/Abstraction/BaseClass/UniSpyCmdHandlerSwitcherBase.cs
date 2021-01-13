﻿using System;
using System.Collections.Generic;
using Serilog.Events;
using UniSpyLib.Abstraction.Interface;
using UniSpyLib.Logging;

namespace UniSpyLib.Abstraction.BaseClass
{
    public abstract class UniSpyCmdSwitcherBase
    {
        protected IUniSpySession _session;
        protected object _rawRequest;
        protected List<IUniSpyRequest> _requests;
        protected List<IUniSpyHandler> _handlers;
        public UniSpyCmdSwitcherBase(IUniSpySession session, object rawRequest)
        {
            _session = session;
            _rawRequest = rawRequest;
            _requests = new List<IUniSpyRequest>();
            _handlers = new List<IUniSpyHandler>();
            LogWriter.LogCurrentClass(this);
        }

        public virtual void Switch()
        {
            try
            {
                SerializeRequests();
                if (_requests.Count == 0)
                {
                    return;
                }
                SerializeCommandHandlers();
                if (_handlers.Count == 0)
                {
                    return;
                }

                foreach (var handler in _handlers)
                {
                    handler.Handle();
                }
            }
            catch (Exception e)
            {
                LogWriter.ToLog(LogEventLevel.Error, e.ToString());
            }
           
        }

        protected abstract void SerializeRequests();
        protected abstract void SerializeCommandHandlers();
    }
}