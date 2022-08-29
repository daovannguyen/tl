using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    private Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickPauseButton);
    }

    private void OnClickPauseButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
