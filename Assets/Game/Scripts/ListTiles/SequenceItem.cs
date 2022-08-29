using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SequenceItem : SingletonBehivour<SequenceItem>
{
    public Dictionary<float, Sequence> sequences = new Dictionary<float, Sequence>();
    public void Add(Item item, Vector3 pos, float time)
    {
        if (sequences[item.id] == null)
        {
            sequences[item.id] = DOTween.Sequence().Append(item.transform.DOMove(pos, time));
        }
        else
        {
            sequences[item.id].Join(item.transform.DOMove(pos, time));
        }
    }
}
