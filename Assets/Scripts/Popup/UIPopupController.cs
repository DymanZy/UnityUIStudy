using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class UIPopupController : ObjectBaseBehavior
{
    private static readonly string selfPrefabResource = "Popup/PopRoot";

    private static readonly Color onColor = new Color(0f, 0f, 0f, 0.66f);
    private static readonly Color offColor = new Color(0f, 0f, 0f, 0f);

    // 背景遮挡层
    private Image BackGroundPlate = null;
    private Image TouchDefender = null;

    private Dictionary<System.Type, UIPopupBase> popInstances = new Dictionary<Type, UIPopupBase>();
    
    private static UIPopupController instance;
    public static UIPopupController Instance()
    {
        if (instance == null)
        {
            GameObject prefab = Resources.Load<GameObject>(selfPrefabResource);
            if (prefab == null)
            {
                Debug.Log("Error. PopRoot Prefab NotFound. Please create a Resources/Popup/PopRoot.");
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


    public T AddPop<T>() where T : UIPopupBase
    {
        return null;
    }

    public void RemovePop<T>()
    {

    }

    public T OpenPop<T>() where T : UIPopupBase
    {
        return null;
    }

    public void ClosePop<T>()
    {
    }

    public void OpenSingleTextPop(
        )
    {

    }
}

