using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Test : MonoBehaviour
{
    public Item item;
    public Transform point1;
    public Transform point2;
    public float timer;
    Sequence sequence;
    private void Awake()
    {
        sequence = DOTween.Sequence();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            sequence.Append(item.transform.DOMove(point1.position, timer));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            sequence.Append(item.transform.DOMove(point2.position, timer));
        }
    }
}
