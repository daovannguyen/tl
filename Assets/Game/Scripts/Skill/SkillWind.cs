using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWind : Skill
{
    public override void InnerTurnOnSkill()
    {
        EventManager.TurnOnSkillWind?.Invoke(true);
    }
}
