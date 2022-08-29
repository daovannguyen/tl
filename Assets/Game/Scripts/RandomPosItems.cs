using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosItems : MonoBehaviour
{
    public GameObject itemsParent;
    public List<GameObject> childPrefabs;
    public int cout = 3;
    public float minX;
    public float minY;
    public float minZ;
    public float maxX;
    public float maxY;
    public float maxZ;

    private int indexColor = -1;
    private List<Color> colors = new List<Color>() {
        //Color.black,
        //Color.gray, 
        Color.green,
        Color.red,
        Color.yellow,
        Color.blue,
        Color.cyan,
        //Color.clear, 
        Color.grey,
        Color.magenta,
        Color.white,
    };
    private void Awake()
    {
        WallAround wallAround = FindObjectOfType<WallAround>();
        minX = wallAround.alignLeftTop.transform.position.x + 1;
        minX = wallAround.alignRightBot.transform.position.x - 1;
        minZ = wallAround.alignRightBot.transform.position.z + 1;
        maxZ = wallAround.alignLeftTop.transform.position.z - 1;
        minY = 1;
        maxY = Camera.main.transform.position.y - 1;
        for (int i = 0; i < childPrefabs.Count; i++)
        {
            Color color = GetRandomColor();
            for (int j = 0; j < cout; j++)
            {
                GameObject a = Instantiate(childPrefabs[i], itemsParent.transform);
                a.transform.position = GetPosRandom();
                //a.AddComponent<Rigidbody>();
                //        a.GetComponent<Rigidbody>().AddForce(0, 100, 0);
                a.AddComponent<Item>();
                a.transform.GetChild(0).gameObject.AddComponent<Outline>();
                Outline outline = a.transform.GetChild(0).gameObject.GetComponent<Outline>();
                outline.OutlineColor = Color.green;
                outline.OutlineWidth = 2;
                outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
                outline.enabled = false;

                a.GetComponent<Item>().id = i + 1;
                a.transform.localScale = Constrain.I_ScaleFromPlayZone;
                a.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
                a.transform.tag = Constrain.TAG_ITEM;
                //        //IEnumerator b = AddForceObject(a);
                //        //StartCoroutine(b);
                a.name = $"{i}_{j}";
                //        //float radTime= Random.Range(0, 0.5f);
                //        //MyScript.Instance.SetColliderEnableFasleDuringTime(a.transform.GetChild(0).gameObject.GetComponent<Collider>(), radTime);

                GameController.Instance.Items.Add(a.GetComponent<Item>());

            }
        }
    }

    private IEnumerator AddForceObject(GameObject model)
    {
        yield return new WaitForSeconds(0.1f);
        model.GetComponent<Rigidbody>().AddForce(0, -1000, 0);
    }
    private Vector3 GetPosRandom()
    {
        return new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            Random.Range(minZ, maxZ)
        );
    }
    private Color GetRandomColor()
    {
        //int rand = Random.Range(0, colors.Count);
        //return colors[rand];
        if (indexColor == colors.Count - 1)
            indexColor = 0;
        else
        {
            indexColor++;
        }
        return colors[indexColor];
    }
}
