using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckScores : MonoBehaviour
{
    public TextMeshProUGUI input;
    //private LocalLeaderboard localLeaderboard;
    public void addScore()
    {
        string name = input.text;
        int score = 100;
        long time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        LocalLeaderboard.instance.AddHighscore(score, name, time);
        SceneManager.LoadScene("LeaderBoard");
    }
}
