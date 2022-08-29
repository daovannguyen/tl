using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ListTiles : SingletonBehivour<ListTiles>
{
    // mảng item trong tile sắp xếp tăng dần theo id item
    public List<Tile> tiles;
    public List<Item> itemsView = new List<Item>(7);
    public GameObject tilesObj;
    public Transform tranLastTileHidden;
    private Tile lastTileHidden;

    public ListItems LogicItems;
    public ListItems ViewItems;


    //public Transform tiles_Object;
    private Queue<Item> outTiles = new Queue<Item>();
    public void Awake()
    {
        // get all tiles
        tiles = new List<Tile>();

        // có 7 tile
        List<GameObject> tilesObjs = MyScript.GetAllChildOfModel(tilesObj);
        foreach (var i in tilesObjs)
        {
            tiles.Add(new Tile(i));
        }
        lastTileHidden = new Tile(tranLastTileHidden.gameObject);
        LogicItems.InitListItem(7);
        ViewItems.InitListItem(7);
    }

    //public int FindIndexTileFirstEmpty()
    //{
    //    for (int i = 0; i < tiles.Count; i++)
    //    {
    //        if (tiles[i].id == -1)
    //        {
    //            return i;
    //        }
    //    }
    //    return -1;
    //}
    //public Tile FindTileFirstEmpty()
    //{
    //    int index = FindIndexTileFirstEmpty();
    //    if (index != -1)
    //    {
    //        return tiles[FindIndexTileFirstEmpty()];
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}
    public Tile FindLastTileContainItem()
    {
        int index = 0;
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].item == null)
            {
                index = i;
                break;
            }
        }
        if (index == 0)
        {
            return null;
        }
        else
        {
            return tiles[index - 1];
        }
    }
    private bool CanAddItem()
    {
        return !(LogicItems.CheckFullList() && LogicItems.FindThreeItemSimilarExited() == -1);
    }
    private bool IsFullTiles()
    {
        return tiles[tiles.Count - 1].item != null;
    }
    private int FindIndexTileForItem(Item item)
    {
        bool hasExsitsItem = false;
        for (int i = 0; i < tiles.Count; i++)
        {
            // tile có item nhỏ hơn hoặc tile trống
            if (tiles[i].item == null)
            {
                return i;
            }
            if (item.id == tiles[i].item.id)
            {
                //return i;
                hasExsitsItem = true;
            }
            if (item.id != tiles[i].item.id && hasExsitsItem)
            {
                return i;
            }
        }
        return -1;
    }

    //private void AddItemToTile(Item item, int indexTile)
    //{
    //    tiles[indexTile].LogicAddItem(item);
    //    item.MoveToPointDotween(
    //        tiles[indexTile].GetPositionForItem(),
    //        Constrain.I_RotateMoveToTile,
    //        Constrain.I_ScaleMoveToTile,
    //        Constrain.LT_timeVer
    //    );
    //}
    public bool CheckMinxiumOneItemOnTiles()
    {
        if (tiles[0].item == null)
        {
            return false;
        }
        else return true;
    }
    public void AddItem(Item item)
    {
        if (CanAddItem())
        {
            int index = LogicItems.FindIndexTileForItem(item);
            for (int i = LogicItems.Items.Count - 1; i > index; i--)
            {
                LogicItems.Items[i] = LogicItems.Items[i - 1];
            }
            LogicItems.Add(item, index);



            index = ViewItems.FindIndexTileForItem(item);
            //if (ViewItems.Items[ViewItems.Items.Count - 1] != null)
            //{
            //    outTiles.Enqueue(ViewItems.Items[ViewItems.Items.Count - 1]);
            //}
            //if (tiles[tiles.Count - 1] != null) tiles[tiles.Count - 1].MoveItemToOtherTile(lastTileHidden);
            // gán item vào tile
            for (int i = ViewItems.Items.Count - 1; i > index; i--)
            {
                ViewItems.Items[i] = ViewItems.Items[i - 1];
                tiles[i - 1].MoveItemToOtherTile(tiles[i]);
            }
            tiles[index].AddItemFromPlayZone(item);
            ViewItems.Add(item, index);
            StartCoroutine(CheckThreeItemSimilar());
        }
        //else if (IsFullTiles() && FindThreeItemSimilarExited() != -1 && CheckForAddOutTilesQueue())
        //{
        //    item.transform.parent = tilesObj.transform;
        //    outTiles.Enqueue(item);
        //    lastTileHidden.AddItemFromPlayZone(item);
        //    StartCoroutine(CheckThreeItemSimilar());
        //}
        else
        {
            EventManager.EndGame?.Invoke(false);
        }
    }
    private bool CheckForAddOutTilesQueue()
    {
        if (outTiles.Count < 3)
            return true;
        return false;
    }

    private int FindThreeItemSimilarExited()
    {
        for (int i = 0; i < tiles.Count - 2; i++)
        {
            if (tiles[i].IsEmpty() || tiles[i + 1].IsEmpty() || tiles[i + 2].IsEmpty())
            {
                continue;
            }
            if (tiles[i].item.id == tiles[i + 1].item.id && tiles[i].item.id == tiles[i + 2].item.id && tiles[i].item != null)
            {
                return i;
            }
        }
        return -1;
    }

    // hàm này có thể truyền index của cái thêm vào là được, thì không cần duyệt for
    private IEnumerator CheckThreeItemSimilar()
    {
        // 3 cái liền trùng nhau và khác rỗng
        int i = LogicItems.FindThreeItemSimilarExited();
        if (i == -1) yield break;

        Item item1 = LogicItems.Items[i];
        Item item2 = LogicItems.Items[i + 1];
        Item item3 = LogicItems.Items[i + 2];
        LogicItems.Remove(item1);
        LogicItems.Remove(item2);
        LogicItems.Remove(item3);
        LogicItems.FillListItems();




        //DOVirtual.DelayedCall(2 * Constrain.ID_time, FillListTiles);

        yield return new WaitForSeconds(Constrain.LT_timeVer);
        //// bật skill item 2
        item2.TurnOnSkill();
        item1.DestroyItem(tiles[i + 1].transform.position, ViewItems);
        item2.DestroyItem(tiles[i + 1].transform.position, ViewItems);
        item3.DestroyItem(tiles[i + 1].transform.position, ViewItems);

        //// đã xóa xong
        //yield return new WaitForSeconds(Constrain.ID_timeDes);
        //StartCoroutine(FillListTiles());
        //EventManager.BrokenItem?.Invoke(tiles[i + 1].transform.position, true);

        //if (GameController.Instance.CheckEndGame())
        //{
        //    EventManager.EndGame?.Invoke(true);
        //}
    }

    private IEnumerator FillListTiles()
    {
        // index chứa thứ tự ô đã được xếp
        //int index = 0;
        //List<Item> items = new List<Item>();
        //List<int> indexs = new List<int>();
        //// đoạn này chỉ thay logic
        //for (int i = 0; i < tiles.Count; i++)
        //{
        //    if (tiles[i].id != -1 && index != i)
        //    {
        //        items.Add(tiles[i].item);
        //        indexs.Add(index);
        //        tiles[index].LogicAddItem(tiles[i].item);
        //        tiles[i].LogicSetEmpty();
        //        index++;
        //    }
        //    else //if (tiles[i].id != -1)
        //    {
        //        continue;
        //        //index++;
        //    }
        //}

        int index = 0;
        List<Item> items = new List<Item>();
        List<int> indexs = new List<int>();
        // đoạn này chỉ thay logic
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].item != null)
            {
                // đây là trường hợp mấy ô đầu có item, còn lại thì index < i
                if (index == i)
                {
                    index++;
                }
                else
                {
                    items.Add(tiles[i].item);
                    indexs.Add(index);
                    tiles[index].LogicAddItem(tiles[i].item);
                    tiles[i].LogicSetEmpty();
                    index++;
                }
            }
            //if (tiles[i].id != -1 && index != i)
            //{
            //}
            //else if (tiles[i].id != -1)
            //{
            //    index++;
            //}
        }


        //trường hợp fill từ queue
        int indexEmpty = FindIndexFirstEmptyTile();

        if (indexEmpty != -1)
        {
            for (int i = indexEmpty; i < tiles.Count; i++)
            {
                if (outTiles.Count > 0)
                {
                    Item item = outTiles.Dequeue();
                    tiles[i].LogicAddItem(item);
                    items.Add(item);
                    indexs.Add(i);
                }
            }
        }



        //if (fillByThree)
        //{
        //    yield return new WaitForSeconds(Constrain.LT_timeVer + 2 * Constrain.ID_timeDes);
        //}
        //else
        //{
        //    yield return new WaitForSeconds(Constrain.LT_timeVer);// + Constrain.ID_timeDes);
        //}
        yield return null;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].MoveToPointDotweenNotRotation(
                tiles[indexs[i]].GetPositionForItem(),
                //Constrain.I_RotateMoveToOtherTile,
                Constrain.I_ScaleMoveToTile,
                Constrain.LT_timeHor
            );
        }
        //khi chuyển từ Queue vào check lần nữa
        //StartCoroutine(CheckThreeItemSimilar());
    }

    private int FindIndexFirstEmptyTile()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].item == null)
            {
                return i;
            }
        }
        return -1;
    }
    //private void SortListTile()
    //{
    //    for (int i = 0; i < tiles.Count; i++)
    //    {
    //        for (int j = i + 1; j < tiles.Count; j++)
    //        {
    //            if (tiles[i].id > tiles[j].id)
    //            {
    //                Tile tg = tiles[i];
    //                tiles[i] = tiles[j];
    //                tiles[j] = tg;
    //            }
    //        }
    //    }
    //}
    //public void MoveItemToTile(Item item, int indexTile, Vector3 rotation, Vector3 scale, float time)
    //{
    //    var pos = Vector3.Lerp(Camera.main.transform.position, tiles[indexTile].transform.position, 0.9f);
    //    //var pos = tiles[indexTile].transform.position + new Vector3(0, item.col.bounds.size.y/2, 0.4f);
    //    item.MoveToPointDotween(pos, rotation, scale, time);
    //}

    private void Update()
    {
        if (!CanAddItem())
        {
            EventManager.EndGame?.Invoke(false);
        }
    }
}