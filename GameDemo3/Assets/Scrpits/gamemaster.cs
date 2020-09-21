using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class gamemaster : MonoBehaviour
{

    public int points = 0;
    public int highscore = 0;
    public int life = 0;
    public int check = 3;

    public TMP_Text pointtext;
    public TMP_Text Hightext;
    public TMP_Text Lifetext;
    // Use this for initialization
    void Start()
    {
        Hightext.text = ("HighScore: " + PlayerPrefs.GetInt("highscore"));
        highscore = PlayerPrefs.GetInt("highscore", 0);
        life = PlayerPrefs.GetInt("life", 3);
        check = PlayerPrefs.GetInt("check", life);
       
        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("points");
                points = 0;
            }
            else {
                points = PlayerPrefs.GetInt("points");
            }
                
        }
        if (PlayerPrefs.HasKey("life"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("life");
                life = 3;
            }
            else
            {
                life = PlayerPrefs.GetInt("life");
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Points: " + points);

        Lifetext.text = ("Life: " + life);
    }
}
