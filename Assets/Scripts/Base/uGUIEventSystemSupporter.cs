using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class uGUIEventSystemSupporter : ObjectBaseBehavior,
IBeginDragHandler,
ICancelHandler,
IDeselectHandler,
IDragHandler,
IDropHandler,
IEndDragHandler,
IInitializePotentialDragHandler,
IMoveHandler,
IPointerClickHandler,
IPointerDownHandler,
IPointerEnterHandler,
IPointerExitHandler,
IPointerUpHandler,
IScrollHandler,
ISelectHandler,
ISubmitHandler,
IUpdateSelectedHandler
{

    //  CallBacks
    private Dictionary<System.Type, System.Action<uGUIEventSystemSupporter, BaseEventData>> CallBacks = new Dictionary<Type, Action<uGUIEventSystemSupporter, BaseEventData>>()
    {
        { typeof(IBeginDragHandler),    null },
        { typeof(ICancelHandler),    null },
        { typeof(IDeselectHandler),    null },
        { typeof(IDragHandler),    null },
        { typeof(IDropHandler),    null },
        { typeof(IEndDragHandler),    null },
        { typeof(IInitializePotentialDragHandler),    null },
        { typeof(IMoveHandler),    null },
        { typeof(IPointerClickHandler),    null },
        { typeof(IPointerDownHandler),    null },
        { typeof(IPointerEnterHandler),    null },
        { typeof(IPointerExitHandler),    null },
        { typeof(IPointerUpHandler),    null },
        { typeof(IScrollHandler),    null },
        { typeof(ISelectHandler),    null },
        { typeof(ISubmitHandler),    null },
        { typeof(IUpdateSelectedHandler),    null }
    };

    public void AddCallBack<T>(System.Action<uGUIEventSystemSupporter, BaseEventData> callback) where T : IEventSystemHandler
    {
        if (!CallBacks.ContainsKey(typeof(T)))
        {
            Debug.Log("[uGUIEventSystemSupporter] addCallBack failure. CallBacks not contain this type : "+typeof(T).Name);
            return;
        }

        CallBacks[typeof(T)] += callback;
    }

    public void RemoveCallBack<T>(System.Action<uGUIEventSystemSupporter, BaseEventData> callback) where T : IEventSystemHandler
    {
        if (!CallBacks.ContainsKey(typeof(T)))
        {
            Debug.Log("[uGUIEventSystemSupporter] removeCallBack failure. CallBacks not contain this type : " + typeof(T).Name);
            return;
        }
        CallBacks[typeof(T)] -= callback;
    }

    public void ClearCallBack<T>() where T : IEventSystemHandler
    {
        if (!CallBacks.ContainsKey(typeof(T)))
        {
            Debug.Log("[uGUIEventSystemSupporter] clearCallBack failure. CallBacks not contain this type : " + typeof(T).Name);
            return;
        }
        CallBacks[typeof(T)] = null;
    }

    public void Call<T>(BaseEventData eventData)
    {
        if (!CallBacks.ContainsKey(typeof(T)))
        {
            Debug.Log("[uGUIEventSystemSupporter] Call failure. CallBacks not contain this type : " + typeof(T).Name);
            return;
        }

        if (CallBacks[typeof(T)] == null) return;

        CallBacks[typeof(T)](this, eventData);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Call<IBeginDragHandler>(eventData);
    }

    public void OnCancel(BaseEventData eventData)
    {
        Call<ICancelHandler>(eventData);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Call<IDeselectHandler>(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Call<IDragHandler>(eventData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Call<IDropHandler>(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Call<IEndDragHandler>(eventData);
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Call<IInitializePotentialDragHandler>(eventData);
    }

    public void OnMove(AxisEventData eventData)
    {
        Call<IMoveHandler>(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Call<IPointerClickHandler>(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Call<IPointerDownHandler>(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Call<IPointerEnterHandler>(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Call<IPointerExitHandler>(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Call<IPointerUpHandler>(eventData);
    }

    public void OnScroll(PointerEventData eventData)
    {
        Call<IScrollHandler>(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Call<ISelectHandler>(eventData);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Call<ISubmitHandler>(eventData);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        Call<IUpdateSelectedHandler>(eventData);
    }
}
