using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboSlider : MonoBehaviour
{
    public Image fillImage;
    public TMP_Text txtIndexCombo;
    public GameObject parent;

    // vì trong UpdateTextCombo() đã tăng indexCombo lên 1, nên khởi tạo = -1
    // trường hợp = 0 
    private int indexCombo = -1;

    private TimeCountDown timeCountDown;


    private void OnEnable()
    {
        EventManager.BrokenItem += BrokenItemHandle;
    }
    private void OnDisable()
    {
        EventManager.BrokenItem -= BrokenItemHandle;
    }
    private void BrokenItemHandle(Vector3 pos, bool obj)
    {
        int score = 0;
        if (indexCombo < 1)
        {
            score = 1;
        }
        else if (indexCombo < 3)
        {
            score = 3;
        }
        else
        {
            score = indexCombo + 1;
        }
        indexCombo++;
        EventManager.EffectGetCoin?.Invoke(pos, score);
        timeCountDown.SetAgainTimeCount();
        UpdateTextCombo();
    }

    public void Awake()
    {
        //slider.direction = Slider.Direction.LeftToRight;
        fillImage.fillOrigin = 0;
        fillImage.fillAmount = 0;

        timeCountDown = GetComponent<TimeCountDown>();
    }

    private void SetDisplayCombo()
    {
        if (indexCombo <= 0)
        {
            fillImage.gameObject.SetActive(false);
            txtIndexCombo.gameObject.SetActive(false);
        }
        else
        {
            fillImage.gameObject.SetActive(true);
            txtIndexCombo.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (timeCountDown.isCounting)
        {
            fillImage.fillAmount = timeCountDown.remainingTime / timeCountDown.timeDown;
        }
        else
        {
            indexCombo = -1;
        }
        SetDisplayCombo();
    }

    private void UpdateTextCombo()
    {
        txtIndexCombo.text = $"Combo x {indexCombo}";
    }

    //public override void UpdateWhenTimeCount()
    //{
    //    //slider.value = remainingTime;
    //}

    //public override void TimeUpHandle()
    //{
    //    indexCombo = 0;
    //    CheckAndActiveParent();
    //}

    //private void CheckAndActiveParent()
    //{
    //    if (indexCombo == 0)
    //    {
    //        txtIndexCombo.gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        txtIndexCombo.gameObject.SetActive(true);
    //    }
    //}

    //public override void SetAgainTimeCount()
    //{
    //    base.SetAgainTimeCount();
    //    if (Time.time - originTime <= timeDown)
    //    {
    //        indexCombo++;
    //    }
    //    else
    //    {
    //        indexCombo = 0;
    //    }
    //    CheckAndActiveParent();
    //    originTime = Time.time;
    //    UpdateTextCombo();
    //}
}
