using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopSingleText : UIPopupBase
{
    public enum Layout { SingleButton, OkAndCancelButton };
    //  common
    [SerializeField] private Image frame;
    [SerializeField] private Text lable_title;
    [SerializeField] private Text lable_description;
    [SerializeField] private Button button_close;
    //  OkAndCancel
    [SerializeField] private Button button_cancel;
    [SerializeField] private Text button_lable_cancel;
    [SerializeField] private Button button_decide;
    [SerializeField] private Text button_lable_decide;
    //  Single
    [SerializeField] private Button button_decide_center;
    [SerializeField] private Text button_lable_decide_center;

    // TODO: add cancel and decide callback
    public CallBackSupporter CancelCallBack = new CallBackSupporter();
    public CallBackSupporter DecisionCallBack = new CallBackSupporter();

    protected override void initialize()
    {
        button_cancel.
    }

    protected override IEnumerator close(params object[] param)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerator open(params object[] param)
    {
        throw new NotImplementedException();
    }
}
