using System;
using UnityEditor;
using UnityEngine;

public class TestBuild {
	public static void BuildAndroid() {
		string[] levels = { "Assets/Scenes/Draggable Panel.unity" };
		string savePath = "./Output/GitHubTest_" + DateTime.Now.ToString("yyMMdd_HHmm") + ".apk";
		BuildPipeline.BuildPlayer(levels, savePath, BuildTarget.Android, BuildOptions.None);
	}
}
