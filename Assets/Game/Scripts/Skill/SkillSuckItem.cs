using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSuckItem : Skill
{
    ListTiles listTiles;
    private void Awake()
    {
        listTiles = ListTiles.Instance;
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        TurnOnSkill();
    //    }
    //}

    public override void InnerTurnOnSkill()
    {
        Item item = listTiles.tiles[0].item;

        // trường hợp tile không có sẵn item
        if (item == null && GameController.Instance.Items.Count > 0)
        {
            item = GameController.Instance.Items[0];

        }
        if (item == null)
        {
            return;
        }

        // trường hợp này không tìm list trước mà dùng vòng for để xóa, thì sẽ bị nhảy index giống gặp ở python
        List<Item> items = GameController.Instance.Items.FindAll(x => x.id == item.id);
        foreach (var i in items)
        {
            listTiles.AddItem(i);
        }
    }
}
