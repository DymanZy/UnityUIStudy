using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public static class LogUtil
{

	public static LogLevel CurrLevel = LogLevel.Everything;

    public enum LogLevel
    {
		Everything,
        Normal,
		Important,
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

    private const string LogMessageFormat_NormalMessage = "Message : {0}";
    private const string LogMessageFormat_TagMessage = "Tag:{1}\nMessage : {0}";
    private const string LogMessageFormat_ClassTagMessage = "[ {2} ] Tag : {1}\nMessage : {0}";
    private const string LogMessageFormat_ClassMessage = "[ {2} ]  \nMessage : {0}";


    public static void Log(string msg)
    {
        log(msg, LogLevel.Normal);
    }

    public static void LogWarning(string msg)
    {
        log(msg,LogLevel.Warning);
    }

    public static void LogImportant(string msg)
    {
        log(msg, LogLevel.Important);
    }

    public static void LogError(string msg)
    {
        log(msg, LogLevel.Error);
    }

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
        Log(msg, null, null, LogLevel.Normal);
    }

    public static void Log(string msg, object outputClass, string tag = null, LogLevel level = LogLevel.Normal)
    {
        string format = LogMessageFormat_NormalMessage;
        if (outputClass != null && !string.IsNullOrEmpty(tag))
        {
            format = LogMessageFormat_ClassTagMessage;
            log(string.Format(format, msg, tag, outputClass.GetType().Name), level);
        }
        else if (outputClass == null && !string.IsNullOrEmpty(tag))
        {
            format = LogMessageFormat_TagMessage;
            log(string.Format(format, msg, tag, ""), level);
        }
        else if (outputClass != null && string.IsNullOrEmpty(tag))
        {
            format = LogMessageFormat_ClassMessage;
            log(string.Format(format, msg, "", outputClass.GetType().Name), level);
        }
        else
        {
            log(string.Format(format, msg), level);
        }
        
    }

    private static void log(string msg, LogLevel level)
    {
		//	等级低的过滤掉
		if (level < CurrLevel) return;

        switch (level)
        {
            case LogLevel.Normal:
                Debug.Log(msg);
                break;

            case LogLevel.Important:
                Debug.LogError("===<<< [Important] >>>===  \n"+msg);
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
