using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonBehivour<GameController>
{
    public List<Item> Items;
    private void OnEnable()
    {
        EventManager.BrokenItem += BrokenItemHandle;
    }
    private void OnDisable()
    {
        EventManager.BrokenItem += BrokenItemHandle;
    }

    private void BrokenItemHandle(Vector3 arg1, bool arg2)
    {
        if (Items.Count <= 0)
        {
            EventManager.EndGame?.Invoke(true);
        }
    }

    protected void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // trả về true khi ăn hết item
    public bool CheckEndGame()
    {
        return Items.Count == 0;
    }


    public List<Item> FindFirstThreeItem()
    {
        for(int i = 0; i < Items.Count; i++)
        {
            List<Item> items = new List<Item>();
            items.Add(Items[i]);
            for (int j = i + 1; j < Items.Count; j++)
            {
                if (Items[i].id == Items[j].id)
                {
                    items.Add(Items[j]);
                    if(items.Count == 3)
                    {
                        return items;
                    }
                }
            }
        }
        return null;
    }
    public bool CheckItemInPlayArea()
    {
        if (Items.Count <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
