using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using UnityEngine;


public class CommonInfoUtil
{

	public static int GetTimeStamp()
	{
		return ConvertDateTimeInt(System.DateTime.Now);
	}

	private static int ConvertDateTimeInt(System.DateTime time)
	{
		System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
		return (int)(time - startTime).TotalSeconds;
	}

	private static string GetTimeFormat()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append("=====  TimeInfo  =====");
		sb.Append("\nNow : " + System.DateTime.Now);
		sb.Append("\nUtcNow : " + System.DateTime.UtcNow);
		sb.Append("\nYear : " + System.DateTime.Now.Year);
		sb.Append("\nMonth : " + System.DateTime.Now.Month);
		sb.Append("\nDay : " + System.DateTime.Now.Day);
		sb.Append("\nhour : " + System.DateTime.Now.Hour);
		sb.Append("\nMinute : " + System.DateTime.Now.Minute);
		sb.Append("\nweekNum : " + (System.DateTime.Now.DayOfYear / 7 + 1));

		return sb.ToString();
	}

	public static string GetTimeYMD()
	{
		return System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString();
	}

	public static string GetTimeYM()
	{
		return System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString();
	}

	private static string GetSystemInfo()
	{

		StringBuilder sb = new StringBuilder();
		sb.Append("\n\n=====  SystemInfo =====");
		sb.Append("\n设备型号 : " + SystemInfo.deviceModel);
		sb.Append("\n设备名称 : " + SystemInfo.deviceName);
		sb.Append("\n设备类型 : " + SystemInfo.deviceType);
		sb.Append("\n设备唯一标识符 : " + SystemInfo.deviceUniqueIdentifier);

		sb.Append("\nCPU名称 : " + SystemInfo.processorType);
		sb.Append("\nCPU核心数 : " + SystemInfo.processorCount);
		sb.Append("\nCPU频率 : " + SystemInfo.processorFrequency);

		sb.Append("\nGPU名称 : " + SystemInfo.graphicsDeviceName);

		sb.Append("\n操作系统 : " + SystemInfo.operatingSystemFamily);
		sb.Append("\n操作系统版本 : " + SystemInfo.operatingSystem);

		return sb.ToString();
	}

	private static string GetMacAddress()
	{
		string macAddress = "";
		NetworkInterface[] ni = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface adapter in ni)
		{
			if (adapter.Description == "en0")
			{
				macAddress = adapter.GetPhysicalAddress().ToString();
				break;
			}
			else
			{
				macAddress = adapter.GetPhysicalAddress().ToString();
				if (macAddress != "")
					break;
			}
		}
		return macAddress;
	}

	private static string GetNetworkType() {
		string type = "";
		switch (Application.internetReachability) {
			case NetworkReachability.ReachableViaCarrierDataNetwork:
				//	3g or 4g
				type = "3g/4g";
				break;

			case NetworkReachability.ReachableViaLocalAreaNetwork:
				//	wifi
				type = "WiFi";
				break;

			case NetworkReachability.NotReachable:
				//	failure
				type = "failure";
				break;
		}

		return type;
	}


}

