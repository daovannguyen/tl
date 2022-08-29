using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(CountForUse))]
public class ButtonSkill : MonoBehaviour
{
    public Button btn;
    public TMP_Text txtNumber;
    public float timeWaitForNextClick = 1;
    public bool allowClick;

    [HideInInspector]
    public Skill skill;
    private CountForUse countForUse;
    private TimeCountDown timeCountDown;
    public virtual void Awake()
    {
        allowClick = true;
        skill = GetComponent<Skill>();
        countForUse = GetComponent<CountForUse>();
        timeCountDown = GetComponent<TimeCountDown>();
        timeCountDown.timeDown = timeWaitForNextClick;
        timeCountDown.eTimeUpHandle.AddListener(TimeUpHandle);
        btn.onClick.AddListener(OnClickButton);
        UpdateTextNumber();
    }

    private void TimeUpHandle()
    {
        allowClick = true;
    }

    private void UpdateTextNumber()
    {
        txtNumber.text = countForUse.numberOfUses.ToString();
    }
    public virtual bool CheckForClick()
    {
        // còn lượt
        if (!countForUse.CheckForUse())
        {
            return false;
        }
        // kiểm tra skill
        if (!skill.CheckForUse())
        {
            return false;
        }
        return true;
    }

    public void OnClickButton()
    {
        if (CheckForClick() && allowClick)
        {
            InnerOnClickButton();
            timeCountDown.SetAgainTimeCount();
            allowClick = false;
        }
    }
    public virtual void InnerOnClickButton()
    {
        countForUse.UseOneTimes();
        UpdateTextNumber();
        skill.TurnOnSkill();
    }
}
