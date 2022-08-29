using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ListItems
{
    public List<Item> Items;
    public void InitListItem(int count)
    {
        Items = new List<Item>(count);
        for (int i = 0; i < count; i++)
        {
            Items.Add(null);
        }
    }
    public int FindIndexTileForItem(Item item)
    {
        bool hasExsitsItem = false;
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] == null) return i;
            if (item.id == Items[i].id)
            {
                hasExsitsItem = true;
            }
            if (item.id != Items[i].id && hasExsitsItem)
            {
                return i;
            }
        }
        return -1;
    }
    public void Add(Item item, int index)
    {
        Items[index] = item;
    }
    public void Remove(Item item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (item.Equals(Items[i]))
            {
                Items[i] = null;
                break;
            }
        }
    }
    public int FindIndexItemInList(Item item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (item.Equals(Items[i]))
            {
                return i;
            }
        }
        return -1;
    }
    public bool IsEmpty(int index)
    {
        return Items[index] == null;
    }
    public int FindThreeItemSimilarExited()
    {
        for (int i = 0; i < Items.Count - 2; i++)
        {
            if (IsEmpty(i) || IsEmpty(i + 1) || IsEmpty(i + 2))
            {
                continue;
            }
            if (Items[i].id == Items[i + 1].id && Items[i].id == Items[i + 2].id)
            {
                return i;
            }
        }
        return -1;
    }
    public void FillListItems()
    {
        int index = 0;
        for (int i = 0; i < Items.Count; i++)
        {
            if (!IsEmpty(i))
            {
                if (index == i)
                {
                    index++;
                }
                else
                {
                    Items[index] = Items[i];
                    Items[i] = null;
                    index++;
                }
            }
        }
    }
    public void FillListTiles()
    {
        int index = 0;
        List<Item> items = new List<Item>();
        List<int> indexs = new List<int>();
        for (int i = 0; i < Items.Count; i++)
        {
            if (IsEmpty(i)) continue;
            // đây là trường hợp mấy ô đầu có item, còn lại thì index < i
            if (index == i)
            {
                index++;
                continue;
            }

            Items[index] = Items[i];
            Items[i] = null;
            items.Add(Items[index]);
            indexs.Add(index);
            ListTiles.Instance.tiles[index].LogicAddItem(ListTiles.Instance.tiles[i].item);
            ListTiles.Instance.tiles[i].LogicSetEmpty();
            index++;
        }

        for (int i = 0; i < items.Count; i++)
        {
            items[i].MoveToPointDotweenNotRotation(
                ListTiles.Instance.tiles[indexs[i]].GetPositionForItem(),
                //Constrain.I_RotateMoveToOtherTile,
                Constrain.I_ScaleMoveToTile,
                Constrain.LT_timeHor
            );
        }
    }
    public bool CheckFullList()
    {
        foreach (var i in Items)
        {
            if (i == null) return false;
        }
        return true;
    }
}