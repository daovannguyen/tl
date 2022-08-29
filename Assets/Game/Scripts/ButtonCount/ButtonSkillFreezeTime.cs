using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSkillFreezeTime : ButtonSkill
{
    public Image fillImg;
    float timeCount = 0;
    private bool timeUp = false;
    public override void Awake()
    {
        base.Awake();
        fillImg.fillAmount = 0;
    }

    public override void InnerOnClickButton()
    {
        base.InnerOnClickButton();

        timeCount = 0;
        timeUp = true;
    }

    public override bool CheckForClick()
    {
        if (base.CheckForClick() && !timeUp)
        {
            return true;
        }
        else return false;
    }

    private void Update()
    {
        if (!timeUp)
        {
            fillImg.fillAmount = 0;
        }
        if (timeCount < ((SkillFreezeTime)skill).timeFreeze && timeUp)
        {
            timeCount += Time.deltaTime;
            fillImg.fillAmount = timeCount / ((SkillFreezeTime)skill).timeFreeze;
        }
        // trường hợp timecount lớn hơn
        else
        {
            timeUp = false;
        }
    }
}
