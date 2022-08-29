using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public PopupBase popupGameOver;
    public PopupBase popupGameComplete;
    private void OnEnable()
    {
        EventManager.EndGame += EndGameHanlde;
    }
    private void OnDisable()
    {
        EventManager.EndGame -= EndGameHanlde;
    }
    private void EndGameHanlde(bool obj)
    {
        if (obj)
        {
            popupGameComplete.Show();
        }
        else
        {
            popupGameOver.Show();
        }
    }
}
