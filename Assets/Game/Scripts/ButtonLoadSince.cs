using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonLoadSince : MonoBehaviour
{
    public Button btn;
    public enum SceneName
    {
        Game,
        Level,
        MainMenu
    }
    public List<SceneName> sceneNames;

    private void Awake()
    {
        //btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        LoadScenes(1);
    }
    private void LoadScenes(int indexLevel = -1)
    {
        for(int i = 0; i < sceneNames.Count; i++)
        {
            if (i == 0)
            {
                SceneManager.LoadScene(sceneNames[i].ToString());
                continue;
            }
            if (sceneNames[i] == SceneName.Level)
            {
                SceneManager.LoadScene(sceneNames[i].ToString() + indexLevel.ToString(), LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(sceneNames[i].ToString(), LoadSceneMode.Additive);
            }
        }
    }
}
