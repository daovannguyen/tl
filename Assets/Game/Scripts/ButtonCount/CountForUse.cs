using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountForUse : MonoBehaviour
{
    public int numberOfUses = 3;

    public void UseOneTimes()
    {
        if (numberOfUses > 0)
        {
            numberOfUses -= 1;
        } 
    }
    public bool CheckForUse()
    {
        return numberOfUses > 0;
    }
}
