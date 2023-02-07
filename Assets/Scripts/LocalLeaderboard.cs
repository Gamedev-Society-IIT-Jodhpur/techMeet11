using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalLeaderboard : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    public List<HighscoreEntry> highscoreEntriesList;

    public static LocalLeaderboard instance;


    public static LocalLeaderboard GetInstance()
    {
        return instance;
    }


    private void Awake()
    {
        instance = this;
        entryContainer = transform;
        entryTemplate = transform.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        // PlayerPrefs.DeleteAll();
        print(PlayerPrefs.GetString("highscoreTable"));
        CreateLeaderboard();
    }

    public void AddHighscore(int score, string name, long time)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name, timeString = time };
        string jsonhighscores = PlayerPrefs.GetString("highscoreTable", "");
        if (jsonhighscores != "")
        {
            Highscores _highscores = JsonUtility.FromJson<Highscores>(jsonhighscores);
            highscoreEntriesList = _highscores.highscoreEntryList;
        }
        highscoreEntriesList.Add(highscoreEntry);
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntriesList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        CreateLeaderboard();
    }


    private void CreateLeaderboard()
    {
        string jsonhighscores = PlayerPrefs.GetString("highscoreTable", "");
        //print("jsonhighscores: " + jsonhighscores);
        if (jsonhighscores != "")
        {
            Highscores _highscores = JsonUtility.FromJson<Highscores>(jsonhighscores);
            highscoreEntriesList = _highscores.highscoreEntryList;
        }
        highscoreEntriesList.Sort((u1, u2) =>
        {

            int result = u1.timeString.CompareTo(u2.timeString);
            return result == 0 ? u1.score.CompareTo(u2.score) : result;
        });
        int rank = 1;
        foreach (var item in highscoreEntriesList)
        {
            Transform entryTransform = Instantiate(entryTemplate, transform);
            entryTransform.gameObject.SetActive(true);
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "th"; break;
                case 1:
                    rankString = "1st"; break;
                case 2:
                    rankString = "2nd"; break;
                case 3:
                    rankString = "3rd"; break;
            }
            entryTransform.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = rankString;
            entryTransform.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = item.name;
            entryTransform.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = item.score.ToString();

            rank += 1;
        }
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntriesList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }





    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    
    
    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;
        public long timeString;
    }





    
}
