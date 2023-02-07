using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }

}
