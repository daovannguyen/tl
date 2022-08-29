using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimeCountDown))]
public class RotateItem : MonoBehaviour
{
    private TimeCountDown timeCountDown;
    ListTiles listTiles;
    private void Awake()
    {
        listTiles = ListTiles.Instance;
        timeCountDown = GetComponent<TimeCountDown>();
        timeCountDown.eTimeUpHandle.AddListener(TimeUpHandle);
        timeCountDown.SetAgainTimeCount();
    }

    private void TimeUpHandle()
    {
        timeCountDown.SetAgainTimeCount();
    }
    private void Update()
    {
        foreach (var i in listTiles.tiles.FindAll(x => x.item != null))
        {
            i.item.transform.eulerAngles = new Vector3(0, timeCountDown.remainingTime / timeCountDown.timeDown * 360, 0);
        }
    }
}
