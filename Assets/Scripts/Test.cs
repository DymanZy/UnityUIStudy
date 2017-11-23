using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Common.LogUtil.Log("================  Type Test ================");
        Common.LogUtil.Log("with classType", this);
        Common.LogUtil.Log("with clasType and tag", this, "TAG");
        Common.LogUtil.Log("with classType, tag and level", this, "TAG", Common.LogUtil.LogLevel.Error);

        Common.LogUtil.Log("================  Level Test ================");
        Common.LogUtil.Log("Normal", Common.LogUtil.LogLevel.Normal);
        Common.LogUtil.Log("Warning", Common.LogUtil.LogLevel.Warning);
        Common.LogUtil.Log("Exception", Common.LogUtil.LogLevel.Exception);
        Common.LogUtil.Log("Error", Common.LogUtil.LogLevel.Error);

        Common.LogUtil.Log("================  Color Test ================");
        Common.LogUtil.Log("blue", Common.LogUtil.LogColor.blue);
        Common.LogUtil.Log("brown", Common.LogUtil.LogColor.brown);
        Common.LogUtil.Log("green", Common.LogUtil.LogColor.green);
        Common.LogUtil.Log("purple", Common.LogUtil.LogColor.purple);
        Common.LogUtil.Log("red", Common.LogUtil.LogColor.red);
        Common.LogUtil.Log("white", Common.LogUtil.LogColor.white);
        Common.LogUtil.Log("yellow", Common.LogUtil.LogColor.yellow);

    }
	
	// Update is called once per frame
	void Update () {
	}
}
