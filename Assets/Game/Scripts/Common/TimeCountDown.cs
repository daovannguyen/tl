using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class TimeCountDown : MonoBehaviour
{
    public float timeDown;
    //[HideInInspector]
    public float remainingTime;
    //[HideInInspector]
    public bool isCounting;
    [HideInInspector]
    public UnityEvent eTimeUpHandle;
    [HideInInspector]
    public UnityEvent eUpdateWhenTimeCount;

    public void SetAgainTimeCount()
    {
        enabled = true;
        isCounting = true;
        remainingTime = timeDown;
    }
    private void Update()
    {
        if (isCounting)
        {
            remainingTime -= Time.deltaTime;
            eUpdateWhenTimeCount.Invoke();
        }
        if (remainingTime < 0 && isCounting)
        {
            enabled = false;
            isCounting = false;
            eTimeUpHandle.Invoke();
        }
    }
    public void FreezeCount()
    {
        isCounting = false;
    }
    public void UnfreezeCount()
    {
        isCounting = true;
    }
    public void AddMoreTimeCount(float moreTime)
    {
        remainingTime += moreTime;
    }
}