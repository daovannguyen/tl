using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Item : GetCompoment3D
{
    public int id;
    // dùng để phân biệt 2 object cùng loại
    //public int index;


    // dùng để cho phép chọn hay không
    public bool seleted = false;

    public override void Awake()
    {
        base.Awake();
        col = transform.GetChild(0).GetComponent<Collider>();
    }
    public virtual void MoveToPointDotween(Vector3 position, Vector3 rotation, Vector3 scale, float time)
    {
        rotation = rotation - transform.eulerAngles;
        transform.DOMove(position, time);
        transform.DORotate(rotation, time).SetRelative();
        transform.DOScale(scale, time);
    }
    public virtual void MoveToPointDotweenNotRotation(Vector3 position, Vector3 scale, float time)
    {
        //rotation = rotation - transform.eulerAngles;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(position, time))
            .Join(transform.DOScale(scale, time));
    }
    public void BeSelected()
    {
        if (!seleted)
        {
            SetEnableCollider(false);
            SetEnableRigibody(false);
            GameController.Instance.Items.Remove(this);
            seleted = true;
        }
    }
    public void UnSelected()
    {
        if (seleted)
        {
            seleted = false;
            GameController.Instance.Items.Add(this);
            //SetEnableCollider(true);
            //col.isTrigger = true;
            SetEnableRigibody(true);
            Vector3 camPos = new Vector3(0, 2, 0);
            Vector3 force = camPos - transform.position;
            StartCoroutine(TurnOnColliderAffterSecond(0.2f));
            rb.AddForce(2 * force, ForceMode.VelocityChange);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(Constrain.I_ScaleFromPlayZone, 1));
        }
    }

    //private void OnMouseOver()
    //{
    //    if (!seleted)
    //    {
    //        transform.DOScale(Constrain.I_ScaleFromMouseOver, 0.5f);
    //    }
    //}
    //private void OnMouseDown()
    //{
    //    if (seleted)
    //    {
    //        //RigidbodyEnable(true);
    //        //listTiles.AddItem(this);
    //    }
    //}
    //private void OnMouseExit()
    //{
    //    if (!seleted)
    //    {
    //        transform.DOScale(Constrain.I_ScaleFromPlayZone, 0.5f);
    //    }
    //}
    public void SetEnableRigibody(bool active)
    {
        rb.isKinematic = !active;
    }
    public void SetEnableCollider(bool active)
    {
        col.enabled = active;
    }
    public void DestroyItem(Vector3 pos)
    {
        Vector3 distance = transform.position - pos;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position + distance * 0.2f, Constrain.ID_timeDes * 0.3f))
            .Append(transform.DOMove(pos, Constrain.ID_timeDes))
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
    public void DestroyItem(Vector3 pos, ListItems items)
    {
        Vector3 distance = transform.position - pos;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position + distance * 0.2f, Constrain.ID_timeDes * 0.3f))
            .Append(transform.DOMove(pos, Constrain.ID_timeDes))
            .OnComplete(() =>
            {
                items.Remove(this);
                items.FillListTiles();
                Destroy(gameObject);
            });
    }
    public void TurnOnSkill()
    {
        Skill skill = GetComponent<Skill>();
        if (skill != null)
        {
            skill.TurnOnSkill();
        }
    }

    IEnumerator TurnOnColliderAffterSecond(float second)
    {
        col.enabled = false;
        yield return new WaitForSeconds(second);
        col.enabled = true;
    }
}