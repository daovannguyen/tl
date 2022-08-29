using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class PlayerScore : MonoBehaviour
{
    private int score;
    private TMP_Text txtScore;

    private void Awake()
    {
        score = 0;
        txtScore = GetComponent<TMP_Text>();
        UpdateTxtScore();
    }
    private void OnEnable()
    {
        EventManager.GetScore += GetScoreHandle;
    }
    private void OnDisable()
    {
        EventManager.GetScore -= GetScoreHandle;
    }

    private void GetScoreHandle(int obj)
    {
        score += obj;
        UpdateTxtScore();
    }

    private void UpdateTxtScore()
    {
        txtScore.text = $"{score}";
    }
}
