using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract class ObjectBaseBehavior : MonoBehaviour
{
    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        OnUpdate();
    }

    private void OnEnable()
    {
        EnableEvent();
    }

    private void OnDisable()
    {
        DisableEvent();
    }

    private void OnDestroy()
    {
        DestroyEvent();
    }

    private void OnApplicationPause(bool pause)
    {
        ApplicationPauseEvent(pause);
    }

    protected virtual void OnValidate() { }
    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    protected virtual void EnableEvent() { }
    protected virtual void DisableEvent() { }
    protected virtual void DestroyEvent() { }
    protected virtual void ApplicationPauseEvent(bool pause) { }


}
