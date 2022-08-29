using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PopupBase : MonoBehaviour
{
    //public Transform main;
    public Button btnClose;
    Animator anim;

    public virtual void Show()
    {
        gameObject.SetActive(true);
        //anim.Play("Popup_Hide");
    }

    public virtual void Hide()
    {
        //anim.Play("Popup_Hide");
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (btnClose)
            btnClose.onClick.AddListener(Hide);
        Hide();
    }
}
