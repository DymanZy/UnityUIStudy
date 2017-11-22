using System;
using System.Collections;
using UnityEngine;


public class CoroutineRunner : DontDestorySingletonBehaviour<CoroutineRunner>
{

    public void Run(IEnumerator coroutine, System.Action finish = null)
    {
        if (coroutine == null)
        {
            if (finish != null)
                finish();
            return;
        }

        StartCoroutine(coroutine);
    }

    public IEnumerator run(IEnumerator coroutine, System.Action finish)
    {
        yield return StartCoroutine(coroutine);
        if (finish != null)
            finish();
    }

}

