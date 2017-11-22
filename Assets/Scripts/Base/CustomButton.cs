using UnityEngine;
using UnityEngine.UI;



public class CustomButton : Button
{

    public CallBackSupporter<uGUIEventSystemSupporter> ClickCallBack = new CallBackSupporter<uGUIEventSystemSupporter>();
    public CallBackSupporter<CustomButton> ClickCallBackOfButtonComponent = new CallBackSupporter<CustomButton>();

    public CallBackSupporter<uGUIEventSystemSupporter> LongPressCallBack = new CallBackSupporter<uGUIEventSystemSupporter>();
    public CallBackSupporter<CustomButton> LongPressCallBackOfButtonComponent = new CallBackSupporter<CustomButton>();


    private bool isInitialized = false;



    protected override void Awake() {
        if (isInitialized) return;

     
    }
}
