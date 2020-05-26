using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreDisplay;
    public string scoreBaseText = "Smeeuws Destroyed: ";

    static Text _scoreDisplay;
    static string _scoreBaseText;
    static int _score = 0;


    private void Awake ()
    {
        _scoreDisplay = scoreDisplay;
        _scoreBaseText = scoreBaseText;

        scoreDisplay.text = _scoreBaseText + _score.ToString();
    }

    public static void IncrementScore ()
    {
        _score++;
        _scoreDisplay.text = _scoreBaseText + _score.ToString();
    }
}
