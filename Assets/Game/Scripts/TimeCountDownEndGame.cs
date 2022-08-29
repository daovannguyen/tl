using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
[RequireComponent(typeof(TimeCountDown))]
public class TimeCountDownEndGame : MonoBehaviour
{
    private TMP_Text txtTime;
    TimeCountDown timeCountDown;

    private void OnEnable()
    {
        EventManager.TurnOnSkillFreezeTime += TurnOnSkillFreezeTimeHandle;
        EventManager.TurnOnSkillAddMoreTime += TurnOnSkillAddMoreTimeHandel;
    }
    private void OnDisable()
    {
        EventManager.TurnOnSkillFreezeTime -= TurnOnSkillFreezeTimeHandle;
        EventManager.TurnOnSkillAddMoreTime -= TurnOnSkillAddMoreTimeHandel;
    }

    private void TurnOnSkillAddMoreTimeHandel(float obj)
    {
        timeCountDown.AddMoreTimeCount(obj);
    }
    private void TurnOnSkillFreezeTimeHandle(bool obj)
    {
        if (obj)
        {
            timeCountDown.FreezeCount();
        }
        else
        {
            timeCountDown.UnfreezeCount();
        }
    }
    public void Awake()
    {
        txtTime = GetComponent<TMP_Text>();
        timeCountDown = GetComponent<TimeCountDown>();
        timeCountDown.SetAgainTimeCount();
        timeCountDown.eTimeUpHandle.AddListener(TimeUpHandle);
        timeCountDown.eUpdateWhenTimeCount.AddListener(UpdateWhenTimeCount);
    }

    private void UpdateTime()
    {
        txtTime.text = UserDefineStringTime();
    }
    public virtual string UserDefineStringTime()
    {
        return GetFormatStringTime();
    }
    protected string GetFormatStringTime()
    {
        int minutes = (int)timeCountDown.remainingTime / 60;
        int seconds = (int)timeCountDown.remainingTime - minutes * 60;
        return minutes.ToString() + ":" + seconds.ToString("00");
    }
    public void TimeUpHandle()
    {
        EventManager.EndGame?.Invoke(false);
    }

    public void UpdateWhenTimeCount()
    {
        UpdateTime();
    }
}