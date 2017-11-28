using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggablePanel : MonoBehaviour {

    [SerializeField]
    private CustomButton button;
    [SerializeField]
    private CustomButton testButton;

    // Use this for initialization
    void Start () {

        button.ClickCallBack.add(ButtonEvent_Test);
        testButton.ClickCallBackOfButtonComponent.add(ButtonEvent_CustomTest);
        button.setDelegateFlag(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ButtonEvent_Test(uGUIEventSystemSupporter s) {
        LogUtil.Log("Click Button Test");
    }

    private void ButtonEvent_CustomTest(CustomButton b) {
        LogUtil.Log("Click Button Custom Test");
    }

}
