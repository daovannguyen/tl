using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputPlayer : MonoBehaviour
{
    private ListTiles listTiles;
    private Item itemSelected;

    // phần lấy thêm 4 raycast nữa, để tăng độ
    public Vector3 inputMouseDistance = new Vector3(10, 10, 0);

    private void Awake()
    {
        listTiles = ListTiles.Instance;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (listTiles == null)
        {
            listTiles = ListTiles.Instance;
            return;
        }

        List<Item> dsitems = GetItemsByRaycast();
        Item newItemSelected = GetOneItemSelect(dsitems);
        if (newItemSelected == null)
        {
            if (itemSelected != null)
            {
                OnMouseExitItem(itemSelected);
            }
            itemSelected = null;
        }
        else
        {
            // khác loại
            if (!newItemSelected.Equals(itemSelected))
            {
                OnMouseExitItem(itemSelected);
            }
            itemSelected = newItemSelected;
        }
        OnMouseOverItem(itemSelected);
        if (Input.GetMouseButtonDown(0))
        {
            if (itemSelected != null)
            {
                listTiles.AddItem(itemSelected);
            }

        }
    }

    private void ChangScaleItem(Item item, Vector3 scale)
    {
        if (item != null)
        {
            item.transform.DOScale( scale, Constrain.I_TimeOverMouse);
        }
    }
    private List<Item> GetItemsByRaycast()
    {
        List<Item> items = new List<Item>();
        Vector3 inputMouse = Input.mousePosition;
        AddItemByRaycastToList(inputMouse, items);

        // lấy bên trái
        inputMouse = new Vector3(
            Input.mousePosition.x - inputMouseDistance.x,
            Input.mousePosition.y,
            Input.mousePosition.z
        );
        AddItemByRaycastToList(inputMouse, items);

        // lấy bên phải
        inputMouse = new Vector3(
            Input.mousePosition.x + inputMouseDistance.x,
            Input.mousePosition.y,
            Input.mousePosition.z
        );
        AddItemByRaycastToList(inputMouse, items);

        // lấy bên trên
        inputMouse = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y + inputMouseDistance.y,
            Input.mousePosition.z
        );
        AddItemByRaycastToList(inputMouse, items);

        // lấy bên dưới
        inputMouse = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y - inputMouseDistance.y,
            Input.mousePosition.z
        );
        AddItemByRaycastToList(inputMouse, items);
        return items;
    }

    private void OnMouseOverItem(Item item)
    {
        if (item == null) return;
        Outline outline = item.gameObject.transform.GetChild(0).gameObject.GetComponent<Outline>();
        outline.enabled = true;
        ChangScaleItem(item, Constrain.I_ScaleFromMouseOver);
    }
    private void OnMouseExitItem(Item item)
    {
        if (item == null) return;
        item.transform.GetChild(0).GetComponent<Outline>().enabled = false;
        ChangScaleItem(item, Constrain.I_ScaleFromPlayZone);
    }
    private void AddItemByRaycastToList(Vector3 mousePos, List<Item> items)
    {

        //Debug.DrawLine(
        //    Camera.main.transform.position,
        //    Camera.main.ScreenPointToRay(mousePos).GetPoint(100),
        //    Color.green,
        //    100
        //);
        Item itemSelected = GetItemFromInputMouse(mousePos);
        if (itemSelected != null)
        {
            items.Add(itemSelected);
        }
    }

    private Item GetItemFromInputMouse(Vector3 position2D)
    {
        Ray ray = Camera.main.ScreenPointToRay(position2D);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.transform.CompareTag(Constrain.TAG_ITEM))
            {
                return hit.transform.GetComponent<Item>();
            }
        }
        return null;
    }

    // mảng hit này chỉ toàn hit chứa item
    private Item GetOneItemSelect(List<Item> items)
    {
        if (items.Count == 0)
        {
            return null;
        }
        // trường hợp trong 5 item có 1 item cùng với item đã chọn ở tiles
        foreach (var item in items)
        {
            foreach (var tile in listTiles.tiles)
            {
                if (tile.item == null) continue;
                if (tile.item.id == item.id)
                {
                    return item;
                }
            }
        }
        // trường hợp không
        return items[0];
    }


}
