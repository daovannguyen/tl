using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// id = -1 là không chứa item nào
public class Tile
{
    [HideInInspector]
    public Transform transform;
    public Item item;

    public Tile(GameObject tile)
    {
        transform = tile.transform;
        item = null;
    }
    public void LogicSetEmpty()
    {
        item = null;
    }
    public void LogicAddItem(Item item)
    {
        this.item = item;
    }
    public Vector3 GetPositionForItem()
    {
        //return Vector3.Lerp(Camera.main.transform.position, transform.position, 0.9f);
        return transform.position + new Vector3(0, 0.2f, 0);
    }
    public bool IsEmpty()
    {
        return item == null;
    }
    public void AddItemFromPlayZone(Item item)
    {
        LogicAddItem(item);
        item.MoveToPointDotween(
            GetPositionForItem(),
            Constrain.I_RotateMoveToTile,
            Constrain.I_ScaleMoveToTile,
            Constrain.LT_timeVer
        );
        item.BeSelected();
    }
    // trường hợp này other tile luôn luôn trống
    public void MoveItemToOtherTile(Tile otherTile)
    {
        if (item != null)
        {
            otherTile.LogicAddItem(item);

            item.MoveToPointDotweenNotRotation(
                otherTile.GetPositionForItem(),
                //Constrain.I_RotateMoveToOtherTile,
                Constrain.I_ScaleMoveToTile,
                Constrain.LT_timeHor
            );

            LogicSetEmpty();
        }
        else
        {
            otherTile.LogicSetEmpty();
        }

    }
}
