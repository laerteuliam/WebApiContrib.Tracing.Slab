﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Web.Http.Tracing;
using Microsoft.AspNet.SignalR;

namespace WebApiContrib.Tracing.Slab.DemoApp.WithSignalR
{
    [EventSource(Name = "WebApiTracing")]
    public class WebApiTracingWithSignalRExample : EventSource
    {
        private IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<DiagnosisEventSourceService>();

        private const int TraceLevelFatal = 401;
        private const int TraceLevelError = 402;
        private const int TraceLevelInformational = 403;
        private const int TraceLevelLogAlways = 404;
        private const int TraceLevelVerbose = 405;
        private const int TraceLevelWarning = 406;

        public static void RegisterLogger(Dictionary<TraceLevel, Action<string>> exectueLogDict)
        {
            exectueLogDict.Add(TraceLevel.Info, Log.Informational);
            exectueLogDict.Add(TraceLevel.Debug, Log.Verbose);
            exectueLogDict.Add(TraceLevel.Error, Log.Error);
            exectueLogDict.Add(TraceLevel.Fatal, Log.Critical);
            exectueLogDict.Add(TraceLevel.Warn, Log.Warning);
        }

        public static readonly WebApiTracingWithSignalRExample Log = new WebApiTracingWithSignalRExample();

        [Event(TraceLevelFatal, Message = "TraceLevel.Fatal{0}", Level = EventLevel.Critical)]
        public void Critical(string message)
        {
            if (IsEnabled())
            {
                WriteEvent(TraceLevelFatal, message);
                hubContext.Clients.All.addDiagnosisMessage(string.Format("TraceLevel.Fatal{0}", message));
            }          
        }

        [Event(TraceLevelError, Message = "TraceLevel.Error{0}", Level = EventLevel.Error)]
        public void Error(string message)
        {
            if (IsEnabled())
            {
                WriteEvent(TraceLevelError, message);
                hubContext.Clients.All.addDiagnosisMessage(string.Format("TraceLevel.Error{0}", message));
            }
        }

        [Event(TraceLevelInformational, Message = "TraceLevel.Info{0}", Level = EventLevel.Informational)]
        public void Informational(string message)
        {
            if (IsEnabled())
            {
                WriteEvent(TraceLevelInformational, message);
                hubContext.Clients.All.addDiagnosisMessage(string.Format("TraceLevel.Info{0}", message));
            }
        }

        [Event(TraceLevelLogAlways, Message = "WebApiTracing LogAlways{0}", Level = EventLevel.LogAlways)]
        public void LogAlways(string message)
        {
            if (IsEnabled())
            {
                WriteEvent(TraceLevelLogAlways, message);
                hubContext.Clients.All.addDiagnosisMessage(string.Format("TraceLevel.LogAlways{0}", message));
            }
        }

        [Event(TraceLevelVerbose, Message = "TraceLevel.Debug{0}", Level = EventLevel.Verbose)]
        public void Verbose(string message)
        {
            if (IsEnabled())
            {
                WriteEvent(TraceLevelVerbose, message);
                hubContext.Clients.All.addDiagnosisMessage(string.Format("TraceLevel.Debug{0}", message));
            }
        }

        [Event(TraceLevelWarning, Message = "TraceLevel.Warn{0}", Level = EventLevel.Warning)]
        public void Warning(string message)
        {
            if (IsEnabled())
            {
                WriteEvent(TraceLevelWarning, message);
                hubContext.Clients.All.addDiagnosisMessage(string.Format("TraceLevel.Warn{0}", message));
            }
        }

        
    }
}