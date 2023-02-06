using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLeaderboard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntriesList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        /*entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = transform.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);*/

        highscoreEntriesList = new List<HighscoreEntry>()
        {
            new HighscoreEntry { score = 1000 , name = "A", timeString = 1675607313  },
            new HighscoreEntry { score = 900 , name = "b", timeString = 1675607313 },
            new HighscoreEntry { score = 800 , name = "c", timeString = 1675607313 },
            new HighscoreEntry { score = 700 , name = "d", timeString = 1675607313 },
            new HighscoreEntry { score = 600 , name = "e", timeString = 1675607313 },
            new HighscoreEntry { score = 500 , name = "f", timeString = 1675607313 },
            new HighscoreEntry { score = 400 , name = "g", timeString = 1675607313 },
        };

        //string timeString = DateTime.Now.ToString("hh:mm:ss");
        long timeString = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        Debug.Log(timeString + " Now ");

        //highscoreEntriesList.
        highscoreEntriesList.Sort((u1, u2) =>
        {
            int result = u1.score.CompareTo(u2.score);
            return result == 0 ? u1.timeString.CompareTo(u2.timeString) : result;
        });

    }





    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    
    
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
        public long timeString;
    }





    
}
