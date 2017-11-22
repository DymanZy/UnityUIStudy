using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPopupBase : ObjectBaseBehavior
{
    protected UIPopupController UIController = null;

    private bool openFlag = false;
    public bool isOpen { get { return openFlag; } }

    private System.Action CloseCallBack = null;

    public void Initialize(UIPopupController uiController)
    {
        this.UIController = uiController;
        initialize();
        this.gameObject.SetActive(false);
        openFlag = false;
    }

    public bool Open(System.Action closeCallBack, params object[] param)
    {
        if (isOpen)
        {
            Debug.Log("Error: The pop-up already open : "+ this.GetType().Name);
            return false;
        }

        this.gameObject.SetActive(true);
        openFlag = true;
        CloseCallBack = closeCallBack;
        StartCoroutine(openCoroutine(param));
        return true;
    }

    private IEnumerator openCoroutine(params object[] param)
    {
        CoroutineRunner.Instance.Run(open(param));
        yield break;
    }

    public void Close(params object[] param)
    {
        if (!isOpen)
        {
            Debug.Log("Error: The pop-up already close : " + this.GetType().Name);
        }

        this.gameObject.SetActive(false);
        openFlag = false;

        if (CloseCallBack != null)
            CloseCallBack();

        StartCoroutine(closeCoroutine(param));
    }

    private IEnumerator closeCoroutine(params object[] param)
    {
        yield return StartCoroutine(close(param));
    }

    protected virtual void initialize() {}
    protected abstract IEnumerator open(params object[] param);
    protected abstract IEnumerator close(params object[] param);
}

