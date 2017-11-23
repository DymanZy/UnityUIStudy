using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(uGUIEventSystemSupporter)),
 RequireComponent(typeof(Image))]
public class CustomButton : Button
{

    private enum ButtonState {
        Normal, Press, Disable
    }

    [SerializeField]
    private uGUIEventSystemSupporter EventSupporter;


    private bool callDelegateFlag = true;
    public void setDelegateFlag(bool flag) {
        callDelegateFlag = flag;
    }

    public CallBackSupporter<uGUIEventSystemSupporter> ClickCallBack = new CallBackSupporter<uGUIEventSystemSupporter>();
    public CallBackSupporter<CustomButton> ClickCallBackOfButtonComponent = new CallBackSupporter<CustomButton>();


    private bool isInitialized = false;

    protected override void Awake() {
        if (isInitialized) return;

        EventSupporter = transform.gameObject.GetComponent<uGUIEventSystemSupporter>();

        EventSupporter.AddCallBack<IPointerClickHandler>(ClickEvent);

        // another wait to do

        isInitialized = true;
    }

    private void ClickEvent(uGUIEventSystemSupporter s, BaseEventData data) {

        if (callDelegateFlag) {
            ClickCallBack.run(s);
            ClickCallBackOfButtonComponent.run(this);
        }
    }

}
