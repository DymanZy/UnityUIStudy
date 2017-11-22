using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Common
{
    public static class LogUtil
    {

        public enum LogLevel
        {
            Normal,
            Exception,
            Warning,
            Error
        }

        public enum LogColor
        {
            white,
            blue,
            green,
            red,
            yellow,
            purple,
            brown
        }

        private const string LogMessageFormat_NormalMessage = "{0}";
        private const string LogMessageFormat_TagMessage = "Tag:{1}\nMessage : {0}";
        private const string LogMessageFormat_ClassTagMessage = "[ {2} ] Tag : {1}\nMessage : {0}";
        private const string LogMessageFormat_ClassMessage = "[ {2} ]  Message : {0}";

        public static void Log(string msg, LogColor color)
        {
            switch (color)
            {
                case LogColor.white:
                    msg = "<color=white>" + msg + "</color>";
                    break;
                case LogColor.blue:
                    msg = "<color=blue>" + msg + "</color>";
                    break;
                case LogColor.green:
                    msg = "<color=green>" + msg + "</color>";
                    break;
                case LogColor.red:
                    msg = "<color=red>" + msg + "</color>";
                    break;
                case LogColor.yellow:
                    msg = "<color=yellow>" + msg + "</color>";
                    break;
                case LogColor.purple:
                    msg = "<color=purple>" + msg + "</color>";
                    break;
                case LogColor.brown:
                    msg = "<color=brown>" + msg + "</color>";
                    break;
            }
            Log(msg, LogLevel.Normal);
        }

        public static void Log(string msg, LogLevel level = LogLevel.Normal)
        {
            Log(msg, null, null, level);
        }

        public static void Log(string msg, object outputClass = null, string tag = null, LogLevel level = LogLevel.Normal)
        {
            string format = LogMessageFormat_NormalMessage;
            if (outputClass != null && !string.IsNullOrEmpty(tag))
                format = LogMessageFormat_ClassTagMessage;
            else if (outputClass == null && !string.IsNullOrEmpty(tag))
                format = LogMessageFormat_TagMessage;
            else if (outputClass != null && string.IsNullOrEmpty(tag))
                format = LogMessageFormat_ClassMessage;

            log(string.Format(format, msg, tag, outputClass.GetType().Name), level);
        }


        private static void log(string msg, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Normal:
                    Debug.Log(msg);
                    break;

                case LogLevel.Exception:
                    Debug.Log("===<<< [Exception] >>>===  "+msg);
                    break;

                case LogLevel.Warning:
                    Debug.LogWarning(msg);
                    break;

                case LogLevel.Error:
                    Debug.LogError(msg);
                    break;
            }
        }

    }
}
