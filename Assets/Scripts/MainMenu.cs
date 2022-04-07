using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public int highScore;

    public void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public void Update()
    {
        highScoreText.text = highScore.ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }


    public void Quit()
    {
        Application.Quit();
    }

}
