using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

        LogTest();
    }
	
	// Update is called once per frame
	void Update () {
	}


    void LogTest() {
        
        LogUtil.Log("================  Log Format Test ================");
        LogUtil.Log("With ClassType", this);
        LogUtil.Log("With ClasType And Tag", this, "MyTag");
        LogUtil.Log("With ClassType, Tag And Level", this, "MyTag", LogUtil.LogLevel.Warning);

        LogUtil.Log("================  Level Test ================");
        LogUtil.Log("Normal Log");
        LogUtil.LogImportant("Important Log");
        LogUtil.LogWarning("Warning Log");
        LogUtil.LogError("Error Log");


        LogUtil.Log("================  Color Test ================");
        LogUtil.Log("blue", LogUtil.LogColor.blue);
        LogUtil.Log("brown", LogUtil.LogColor.brown);
        LogUtil.Log("green", LogUtil.LogColor.green);
        LogUtil.Log("purple", LogUtil.LogColor.purple);
        LogUtil.Log("red", LogUtil.LogColor.red);
        LogUtil.Log("white", LogUtil.LogColor.white);
        LogUtil.Log("yellow", LogUtil.LogColor.yellow);
    }
}
