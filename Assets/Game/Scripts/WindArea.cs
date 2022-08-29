using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : GetCompoment3D
{

    public float strength;
    public Vector3 direction;
    public Transform centerPoint;
    public override void Awake()
    {
        base.Awake();
        col.enabled = false;
    }
    private void OnEnable()
    {
        EventManager.TurnOnSkillWind += TurnOnSkillWindHandle;
    }
    private void OnDisable()
    {
        EventManager.TurnOnSkillWind += TurnOnSkillWindHandle;
    }

    private void TurnOnSkillWindHandle(bool obj)
    {
        if (obj == true)
        {
            foreach(var tile in GameController.Instance.Items)
            {
                tile.GetComponentInParent<Rigidbody>().AddForce(strength * new Vector3(0, 1 + UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)));
            }
            //StartCoroutine(SetActiveWindArea());
        }
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.transform.parent.CompareTag(Constrain.TAG_ITEM))
    //    {
    //        other.GetComponentInParent<Rigidbody>().AddForce(strength * new Vector3(0, 1 + UnityEngine.Random.Range(-0.5f, 0.5f), 1 + UnityEngine.Random.Range(-0.5f, 0.5f)));
    //    }
    //}

    private IEnumerator SetActiveWindArea()
    {
        col.enabled = true;
        yield return new WaitForSeconds(1);
        col.enabled = false;
    }
}
