using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAround : MonoBehaviour
{

    public GameObject underBox;
    public GameObject rightBox;
    public GameObject leftBox;
    public GameObject fontBox;
    public GameObject behindBox;

    public GameObject alignLeftTop;
    //public GameObject alignRightTop;
    //public GameObject alignLeftBot;
    public GameObject alignRightBot;

    public float anglePlus = 0;

    private void Start()
    {
        underBox.transform.position = Vector3.zero;

        // left
        SetTransformObject(
            leftBox,
            new Vector3(alignLeftTop.transform.position.x, leftBox.transform.position.y, leftBox.transform.position.z),
            new Vector3(0, 0, 0)
        );

        // right
        SetTransformObject(
            rightBox,
            new Vector3(alignRightBot.transform.position.x, rightBox.transform.position.y, rightBox.transform.position.z),
            new Vector3(0, 0, 0)
        );

        // font
        SetTransformObject(
            fontBox,
            new Vector3(fontBox.transform.position.x, fontBox.transform.position.y, alignLeftTop.transform.position.z),
            new Vector3(0, 0, 0)
        );

        // behind
        SetTransformObject(
            behindBox,
            new Vector3(behindBox.transform.position.x, behindBox.transform.position.y, alignRightBot.transform.position.z),
            new Vector3(0, 0, 0)
        );
        //// right
        //SetTransformObject(
        //    rightBox,
        //    new Vector3(alignRightBot.transform.position.x, rightBox.transform.position.y, rightBox.transform.position.z),
        //    new Vector3(0, 0, 90 - GetRotate(alignRightBot, alignRightTop) - anglePlus)
        //);
        ////// font
        //SetTransformObject(
        //    fontBox,
        //    new Vector3(fontBox.transform.position.x, fontBox.transform.position.y, alignLeftTop.transform.position.z),
        //    new Vector3(-90 + GetRotate(alignLeftTop, alignRightTop) + anglePlus, 0, 0)
        //);
        ////// bot
        //SetTransformObject(
        //    behindBox,
        //    new Vector3(behindBox.transform.position.x, behindBox.transform.position.y, alignLeftBot.transform.position.z),
        //    new Vector3(90 - GetRotate(alignLeftBot, alignRightBot) - anglePlus, 0, 0)
        //);
    }
    public void SetTransformObject(GameObject model, Vector3 pos, Vector3 ros)
    {
        model.transform.position = pos;
        model.transform.Rotate(ros);
    }
    public float GetCorner(GameObject point1, GameObject point2, Vector3 x1)
    {
        Vector3 midpoint = Vector3.Lerp(
            point1.transform.position,
            point2.transform.position,
            0.5f
        );
        Vector3 x2 = Camera.main.transform.position - midpoint;
        //float canhHuyen = Vector3.Distance(Camera.main.transform.position, trungDiem);
        //float chieuCao = Camera.main.transform.position.y - 1;
        float numerator = x1.x * x2.x + x1.y * x2.y + x1.z * x2.z;
        float denominator = Vector3.Distance(Vector3.zero, x1) * Vector3.Distance(Vector3.zero, x2);
        return Mathf.Acos(numerator / denominator) * Mathf.Rad2Deg; ;
    }
}
