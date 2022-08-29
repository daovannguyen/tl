using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : SingletonBehivour<MyScript>
{
    public static List<GameObject> GetAllChildOfModel(GameObject model)
    {
        int count = model.transform.childCount;
        List<GameObject> childs = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            childs.Add(model.transform.GetChild(i).gameObject);
        }
        return childs;
    }
    public static void DestroyAllChildOfModel(GameObject model)
    {
        List<GameObject> childs = GetAllChildOfModel(model);
        for (int i = 0; i < childs.Count; i++)
        {
            childs[i].gameObject.SetActive(false);
        }
    }
    public void SetColliderEnableFasleDuringTime(Collider col, float time)
    {
        StartCoroutine(IESetColliderEnableFasleDuringTime(col, time));
    }
    private IEnumerator IESetColliderEnableFasleDuringTime(Collider col, float time)
    {
        col.enabled = false;
        yield return new WaitForSeconds(time);
        col.enabled = true;
    }
}
