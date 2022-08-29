using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Magnet : MonoBehaviour
{
    public GameObject magnet;
    public List<GameObject> movementPoints;
    public GameObject suckPoint;


    private void OnEnable()
    {
        EventManager.TurnOnSkillMagnet += TurnOnSkillMagnetHandle;
    }
    private void OnDisable()
    {

        EventManager.TurnOnSkillMagnet -= TurnOnSkillMagnetHandle;
    }

    private void TurnOnSkillMagnetHandle(bool obj)
    {
        if (obj)
        {
            magnet.transform.position = movementPoints[0].transform.position;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(
                        magnet.transform.DOMove(movementPoints[1].transform.position, 1f)
                        .OnComplete(()=> {
                            SuckItems();
                        })
                 )
                .Append(magnet.transform.DOMove(movementPoints[1].transform.position, 1f))
                .Append(magnet.transform.DOMove(
                    movementPoints[0].transform.position, 1f)
                    .OnComplete(() => {
                        MyScript.DestroyAllChildOfModel(suckPoint);
                    })
                );
        }
    }

    private void SuckItems()
    {
        for (int i = 0; i < 3; i++)
        {
            List<Item> items1 = GameController.Instance.FindFirstThreeItem();
            if (items1 != null)
            {
                foreach(var j in items1)
                {
                    GameController.Instance.Items.Remove(j);
                    j.transform.parent = suckPoint.transform;
                    j.SetEnableCollider(false);
                    j.SetEnableRigibody(false);
                    j.transform.DOMove(suckPoint.transform.position, 0.8f);
                }
            }
        }
    }
}
