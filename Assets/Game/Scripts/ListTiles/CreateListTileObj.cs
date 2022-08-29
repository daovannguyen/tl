using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateListTileObj : MonoBehaviour
{
    public int countTile;
    public GameObject tilesParent;
    public GameObject tilePrefab;
    private void Awake()
    {
        for (int i = 0; i< countTile; i++)
        {
            GameObject tile = Instantiate(tilePrefab, tilesParent.transform.position, tilesParent.transform.rotation);
            tile.transform.parent = tilesParent.transform;
            tile.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
