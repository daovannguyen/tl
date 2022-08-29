using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillFreezeTime : Skill
{
    public float timeFreeze;
    //public Image fillImg;
    //float timecount = 0;
    //private bool timeUp = false;
    //private void Awake()
    //{
    //    fillImg.fillAmount = 0;
    //}
    IEnumerator IETurnOffFreezeTime()
    {
        yield return new WaitForSeconds(timeFreeze);
        EventManager.TurnOnSkillFreezeTime?.Invoke(false);
        //timeUp = false;
    }
    //private void Update()
    //{
    //    if (!count)
    //    {
    //        fillImg.fillAmount = 0;
    //    }
    //    if (timeCount < timeFreeze && count)
    //    {
    //        timeCount += Time.deltaTime;
    //        fillImg.fillAmount = timeCount / timeFreeze;
    //    }
    //}


    public override void InnerTurnOnSkill()
    {
        //timeCount = 0;
        //timeUp = true;
        EventManager.TurnOnSkillFreezeTime?.Invoke(true);
        StartCoroutine(IETurnOffFreezeTime());
    }
}
