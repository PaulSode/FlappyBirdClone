using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    public static ScoreManagerScript Instance;

    [SerializeField] private TMP_Text currentText;
    [SerializeField] private TMP_Text bestText;

    private int _score;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentText.text = _score.ToString();
        bestText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", _score);
            bestText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        currentText.text = _score.ToString();
        UpdateHighScore();
    }
}
