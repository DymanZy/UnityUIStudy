using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPopupBase : ObjectBaseBehavior
{
    protected UIPopupBase UIController = null;



    protected virtual void initialize() { }

    protected abstract IEnumerator open(params object[] param);
    protected abstract IEnumerator close(params object[] param);
}

