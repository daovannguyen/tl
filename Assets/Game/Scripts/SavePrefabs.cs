using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class SavePrefabs : MonoBehaviour
{
    public const string folder_meshs = @"D:\tile_master_3d\Assets\Resources\Meshs";
    public const string folder_savePrefabs = "";

    private void Awake()
    {
        //string[] listpath = Directory.GetFiles(folder_meshs, "*.obj");
        //foreach(var i in listpath)
        //{
        //    string pathPrefab = i.Replace(@"D:\tile_master_3d\Assets\Resources\", "")
        //        .Replace(".obj", "");
        //    Debug.Log(pathPrefab);
        //    GameObject prefab = LoadPrefabsFromObjInScenes(pathPrefab);
        //    SaveGameObjectToPrefab(prefab);
        //}
    }
    //private GameObject LoadPrefabsFromObjInScenes(string path)
    //{
    //    var prefab = Resources.Load<GameObject>(path);
    //    GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
    //    return obj;
    //}
    //private void SaveGameObjectToPrefab(GameObject model)
    //{
    //    string localPath = "Assets/Prefabs/" + model.name.Replace("(Clone)", "") + ".prefab";

    //    // Make sure the file name is unique, in case an existing Prefab has the same name.
    //    localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
    //    PrefabUtility.SaveAsPrefabAsset(model, localPath);
    //}
}
