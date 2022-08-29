using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[System.Serializable]
public class Pool
{
    public GameObject go;
    public int count;
    List<GameObject> actives = new List<GameObject>();
    Queue<GameObject> deactives = new Queue<GameObject>();

    public void InitaPool(Transform container, Dictionary<int, int> dicClones)
    {
        for (int i = 0; i < count; i++)
        {
            spawnAClone(container, dicClones);
        }
    }

    void spawnAClone(Transform container, Dictionary<int, int> dicClones)
    {
        var clone = Object.Instantiate(go, container);
        clone.SetActive(false);
        clone.transform.localScale = Vector3.one;
        deactives.Enqueue(clone);
        dicClones.Add(clone.GetHashCode(), GetHashCode());
    }

    public GameObject Get(Transform container, Dictionary<int, int> dicClones)
    {
        if (deactives.Count == 0)
            spawnAClone(container, dicClones);
        var clone = deactives.Dequeue();
        actives.Add(clone);
        Debug.Log(clone.name);
        return clone;
    }

    public void Return(GameObject go)
    {
        go.SetActive(false);
        actives.Remove(go);
        deactives.Enqueue(go);
    }
}

public class ObjectPool : SingletonBehivour<ObjectPool>
{
    public Pool coinUp;
    public Pool scaleItem;
    public Pool starItem;
    public Pool bulletItem;
    public Pool playerBullet1;
    public Pool breakBrickEf;
    public Pool eggYoshi;
    public Pool bulletYoshi;
    public Dictionary<int, int> dicClones = new Dictionary<int, int>();

    private void Start()
    {
        coinUp.InitaPool(transform, dicClones);
        scaleItem.InitaPool(transform,dicClones);
        starItem.InitaPool(transform,dicClones);
        bulletItem.InitaPool(transform,dicClones);
        playerBullet1.InitaPool(transform,dicClones);
        breakBrickEf.InitaPool(transform, dicClones);
        eggYoshi.InitaPool(transform, dicClones);
        bulletYoshi.InitaPool(transform, dicClones);
    }

    public GameObject Get(Pool p)
    {
        return p.Get(transform, dicClones);
    }

    public void Return(GameObject clone)
    {
        var hash = clone.GetHashCode();
        if (dicClones.ContainsKey(hash))
        {
            var p = getPool(dicClones[hash]);
            p.Return(clone);
        }
    }

    Pool getPool(int hash)
    {
        if (coinUp.GetHashCode() == hash)
            return coinUp;
        else if (breakBrickEf.GetHashCode() == hash)
            return breakBrickEf;
        else if (eggYoshi.GetHashCode() == hash)
            return eggYoshi;
        else if (bulletYoshi.GetHashCode() == hash)
            return bulletYoshi;
        else if (starItem.GetHashCode() == hash)
            return starItem;
        else if (playerBullet1.GetHashCode() == hash)
            return playerBullet1;
        else if (bulletItem.GetHashCode() == hash)
            return bulletItem;
        else return scaleItem;
    }
}