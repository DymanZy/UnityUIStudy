using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class UIPopupController : ObjectBaseBehavior
{
    private static readonly string selfResource = "Popup/PopRoot";
    private static readonly string resourceRoot = "Popup/";

    private static readonly Color onColor = new Color(0f, 0f, 0f, 0.66f);
    private static readonly Color offColor = new Color(0f, 0f, 0f, 0f);

    // 背景遮挡层
    private Image BackGroundPlate = null;
    //private Image TouchDefender = null;

    private Dictionary<System.Type, UIPopupBase> popInstances = new Dictionary<Type, UIPopupBase>();
    private List<UIPopupBase> openStack = new List<UIPopupBase>();
    
    private static UIPopupController instance;
    public static UIPopupController Instance()
    {
        if (instance == null)
        {
            GameObject prefab = Resources.Load<GameObject>(selfResource);
            if (prefab == null)
            {
                LogUtil.Log("Error. PopRoot Prefab NotFound. Please create a Resources/Popup/PopRoot.");
                return null;
            }

            instance = GameObject.Instantiate(prefab).GetComponent<UIPopupController>();
            instance.name = "DontDestroy_UIPopupController";

            instance.BackGroundPlate = instance.transform.GetChild(0).GetComponent<Image>();
            instance.BackGroundPlate.color = offColor;
            instance.BackGroundPlate.gameObject.SetActive( false );

            GameObject.DontDestroyOnLoad(instance.gameObject);
        }
        return instance;
    }


    public static void ClearInstance()
    {
        if (instance == null) return;
        GameObject.Destroy(instance.gameObject);
        instance = null;
    }

    public T OpenPop<T>(System.Action closeCallBack, params object[] param) where T : UIPopupBase
    {
        if (!popInstances.ContainsKey(typeof(T)))
        {
            GameObject prefab = Resources.Load<GameObject>(resourceRoot + typeof(T).Name);
            if (prefab == null)
            {
                Debug.Log("[UIPopupController] OpenPop failure. prefab is null.");
                return null;
            }

            T Component = GameObject.Instantiate(prefab).GetComponent<T>();
            if (Component == null)
            {
                return null;
            }

            Component.transform.SetParent(this.transform, false);
            Component.Initialize(this);
            popInstances.Add(typeof(T), Component);
        }

        if (!popInstances[typeof(T)].Open(closeCallBack, param))
            return null;//  打开该窗口失败

        BackGroundPlate.color = onColor;
        instance.BackGroundPlate.gameObject.SetActive(true);

        openStack.Add(popInstances[typeof(T)]);
        BackGroundPlate.transform.SetSiblingIndex(openStack.Count);
        popInstances[typeof(T)].transform.SetSiblingIndex(openStack.Count + 1);

        return popInstances[typeof(T)] as T;
    }

    public T ClosePop<T>(params object[] param) where T : UIPopupBase
    {
        if (!popInstances.ContainsKey(typeof(T)))
        {
            Debug.Log("[UIPopupController] ClosePop failure : " + typeof(T).Name + " Dont Insert Dictionary");
            return null;
        }

        if (!popInstances[typeof(T)].isOpen)
        {
            Debug.Log("[UIPopupController] ClosePop failure : " + typeof(T).Name + " already close");
        }

        openStack.Remove(popInstances[typeof(T)]);
        popInstances[typeof(T)].Close(param);

        //  所有窗口已关闭，隐藏遮挡层
        if (openStack.Count <= 0)
        {
            BackGroundPlate.color = offColor;
            instance.BackGroundPlate.gameObject.SetActive(false);
            return popInstances[typeof(T)] as T;
        }

        //  仍有窗口未关闭，重新调整遮挡层的层级
        List<GameObject> tmp = new List<GameObject>(openStack.Where(v => true).Select(v => v.gameObject).ToArray());
        tmp.Insert(tmp.Count - 1, BackGroundPlate.gameObject);
        int sibling = 0;
        foreach (var g in tmp)
        {
            g.transform.SetSiblingIndex(sibling++);
        }

        return popInstances[typeof(T)] as T;
    }

    public void CloseForegroundPopup()
    {
        //  关闭顶部的窗口
        if (openStack.Count > 0)
        {
            UIPopupBase p =  openStack[openStack.Count - 1];
            openStack.Remove(p);
            p.Close();
        }

        //  所有窗口已关闭，隐藏遮挡层
        if (openStack.Count <= 0)
        {
            BackGroundPlate.color = offColor;
            instance.BackGroundPlate.gameObject.SetActive(false);
            return;
        }

        //  仍有窗口未关闭，重新调整遮挡层的层级
        List<GameObject> tmp = new List<GameObject>(openStack.Where(v => true).Select(v => v.gameObject).ToArray());
        tmp.Insert(tmp.Count - 1, BackGroundPlate.gameObject);
        int sibling = 0;
        foreach (var g in tmp)
        {
            g.transform.SetSiblingIndex(sibling++);
        }
    }

    public bool isCurrentlyOpen()
    {
        return openStack.Count > 0;
    }

    /// <summary>
    ///     打开纯文本窗口
    /// </summary>
    public void OpenSingleTextPop(
        PopSingleText.Layout layout,
        string description,
        string title = null,
        string button_decision_text = null,
        string button_cancel_text = null,
        System.Action callback_decision = null,
        System.Action callback_cancel = null)
    {
        var param = new List<object>();
        param.Add(layout);
        param.Add(description);
        param.Add(title);
        param.Add(button_decision_text);
        param.Add(button_cancel_text);

        var pop = OpenPop<PopSingleText>(null, param.ToArray());

        if (callback_decision != null)
            pop.DecisionCallBack.add(callback_decision);

        if (callback_cancel != null)
            pop.CancelCallBack.add(callback_cancel);
    }
}
