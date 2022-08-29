using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackgroundFreeze : MonoBehaviour
{
    public Image freezeImg;
    private void Awake()
    {
        freezeImg.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.TurnOnSkillFreezeTime += TurnOnSkillFreezeTimeHandel;
    }
    private void OnDisable()
    {
        EventManager.TurnOnSkillFreezeTime -= TurnOnSkillFreezeTimeHandel;
    }

    private void TurnOnSkillFreezeTimeHandel(bool obj)
    {
        if (obj)
        {
            freezeImg.gameObject.SetActive(true);
        }
        else
        {
            freezeImg.gameObject.SetActive(false);
        }
    }
}
