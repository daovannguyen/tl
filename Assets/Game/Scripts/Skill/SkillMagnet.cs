using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMagnet : Skill
{
    public override void InnerTurnOnSkill()
    {
        EventManager.TurnOnSkillMagnet?.Invoke(true);
    }

    //public override void TurnOnSkill()
    //{
    //}
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        TurnOnSkill();
    //    }
    //}
}
