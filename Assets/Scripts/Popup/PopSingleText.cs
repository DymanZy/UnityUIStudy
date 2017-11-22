using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TODO : 还需要在 /Resources/Popup/ 目录下创建PopSingleText的Prefab
/// </summary>
public class PopSingleText : UIPopupBase
{
    public enum Layout { SingleButton, OkAndCancelButton };
    //  common
    [SerializeField] private Image frame;
    [SerializeField] private Text lable_title;
    [SerializeField] private Text lable_description;
    [SerializeField] private CustomButton button_close;
    //  OkAndCancel
    [SerializeField] private CustomButton button_cancel;
    [SerializeField] private Text button_lable_cancel;
    [SerializeField] private CustomButton button_decide;
    [SerializeField] private Text button_lable_decide;
    //  Single
    [SerializeField] private CustomButton button_decide_center;
    [SerializeField] private Text button_lable_decide_center;

    // add cancel and decide callback
    public CallBackSupporter CancelCallBack = new CallBackSupporter();
    public CallBackSupporter DecisionCallBack = new CallBackSupporter();

    protected override void initialize()
    {
        button_decide_center.ClickCallBackOfButtonComponent.add(button_event_decision);
        button_decide.ClickCallBackOfButtonComponent.add(button_event_decision);
        button_cancel.ClickCallBackOfButtonComponent.add(button_event_cancel);
        button_close.ClickCallBackOfButtonComponent.add(button_event_close);
    }

    // 0 : layout type (must)
    // 1 : description (must)
    // 2 : title (must)
    // 3 : decide text (must)
    // 4 : cancel text (maybe is null)
    protected override IEnumerator open(params object[] param)
    {
        // 解析param，初始化UI
        Layout layoutType = (Layout) param[0];
        string description = (string) param[1];

        lable_description.text = description;
        lable_title.text = param.Length < 3 || param[2] == null ? "确认" : (string) param[2];
        
        button_cancel.gameObject.SetActive(layoutType == Layout.OkAndCancelButton);
        button_decide.gameObject.SetActive(layoutType == Layout.OkAndCancelButton);
        button_decide_center.gameObject.SetActive(layoutType == Layout.SingleButton);

        if (layoutType == Layout.OkAndCancelButton)
        {
            button_lable_decide.text = param.Length < 4 || param[3] == null ? "确定" : (string) param[3];
            button_lable_cancel.text = param.Length < 5 || param[4] == null ? "取消" : (string) param[4];
        }
        else if (layoutType == Layout.SingleButton)
        {
            button_lable_decide.text = param.Length < 4 || param[3] == null ? "确定" : (string)param[3];
        }

        yield break;
    }

    protected override IEnumerator close(params object[] param)
    {
        CancelCallBack.clear();
        DecisionCallBack.clear();
        yield break;
    }

    private void button_event_cancel(CustomButton b)
    {
        CancelCallBack.run();
    }

    private void button_event_decision(CustomButton b)
    {
        DecisionCallBack.run();
    }

    private void button_event_close(CustomButton b)
    {
        CancelCallBack.run();
    }

}
