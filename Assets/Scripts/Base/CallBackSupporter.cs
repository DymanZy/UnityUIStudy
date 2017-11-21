using System.Collections;
using UnityEngine;

public class CallBackSupporter
{
    private System.Action CallBack;
    public void add(System.Action callback) { CallBack += callback; }
    public void remove(System.Action callback) { CallBack -= callback; }
    public void clear(){ CallBack = null; }
    public void run() {
        if (CallBack != null)
            CallBack();
    }
}

public class CallBackSupporter<T1>
{
    private System.Action<T1> CallBack;
    public void add(System.Action<T1> callback) { CallBack += callback; }
    public void remove(System.Action<T1> callback) { CallBack -= callback; }
    public void clear() { CallBack = null; }
    public void run(T1 value1)
    {
        if (CallBack != null)
            CallBack(value1);
    }
}

public class CallBackSupporter<T1, T2>
{
    private System.Action<T1, T2> CallBack;
    public void add(System.Action<T1, T2> callback) { CallBack += callback; }
    public void remove(System.Action<T1, T2> callback) { CallBack -= callback; }
    public void clear() { CallBack = null; }
    public void run(T1 value1, T2 value2)
    {
        if (CallBack != null)
            CallBack(value1, value2);
    }
}

public class CallBackSupporter<T1, T2, T3>
{
    private System.Action<T1, T2, T3> CallBack;
    public void add(System.Action<T1, T2, T3> callback) { CallBack += callback; }
    public void remove(System.Action<T1, T2, T3> callback) { CallBack -= callback; }
    public void clear() { CallBack = null; }
    public void run(T1 value1, T2 value2, T3 value3)
    {
        if (CallBack != null)
            CallBack(value1, value2, value3);
    }
}
