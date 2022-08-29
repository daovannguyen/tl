using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public void TurnOnSkill()
    {
        if (CheckForUse())
        {
            InnerTurnOnSkill();
        }
    }
    public abstract void InnerTurnOnSkill();
    public virtual bool CheckForUse()
    {
        if (GameController.Instance.CheckItemInPlayArea())
        {
            return true;
        }
        else return false;
    }
}
