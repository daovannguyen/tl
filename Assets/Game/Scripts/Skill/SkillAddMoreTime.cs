using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAddMoreTime : Skill
{
    public float timeAddMore = 0.5f;

    public override void InnerTurnOnSkill()
    {
        EventManager.TurnOnSkillAddMoreTime?.Invoke(timeAddMore);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TurnOnSkill();
        }
    }
}
