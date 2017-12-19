using System;
using UnityEditor;
using UnityEngine;

public class CommandBuild {
	public static void BuildAndroid() {
		string[] levels = { "Assets/Scenes/Drag And Drop.unity" };
		string savePath = "./Output/AndroidTest_" + DateTime.Now.ToString("yyMMdd_HHmm") + ".apk";
		BuildPipeline.BuildPlayer(levels, savePath, BuildTarget.Android, BuildOptions.None);
	}
}
