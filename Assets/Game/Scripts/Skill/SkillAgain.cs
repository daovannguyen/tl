using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillAgain : Skill
{
    public override bool CheckForUse()
    {
        // kiểm tra này là đủ không cần kiểm tra 
        if (ListTiles.Instance.CheckMinxiumOneItemOnTiles())
        {
            return true;
        }
        else return false;
    }

    public override void InnerTurnOnSkill()
    {
        //// trường hợp không có item
        //if (GameController.Instance.Items.Count == 0)
        //{
        //    return;
        //}
        //// trường hợp có item ở tiles
        //Tile tile = ListTiles.Instance.FindLastTileContainItem();
        //if (tile == null)
        //{
        //    return;
        //}
        

        // Đã check là có
        Tile tile = ListTiles.Instance.FindLastTileContainItem();
        Item lastItem = tile.item;
        //xóa item tile
        tile.LogicSetEmpty();
        //Thêm lại cái vật lý của item
        lastItem.UnSelected();
    }
}
