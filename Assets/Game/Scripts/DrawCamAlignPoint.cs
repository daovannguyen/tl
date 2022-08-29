using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCamAlignPoint : MonoBehaviour
{
    public List<GameObject> targets;
    public void Awake()
    {
        foreach (var i in targets)
        {
            Debug.DrawLine(i.transform.position, Camera.main.transform.position, Color.green, 100);
        }
    }
}
