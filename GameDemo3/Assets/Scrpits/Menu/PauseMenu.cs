using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PauseMenu : MonoBehaviour
{
    public float startingTime = 300;
    public Player2 player;
    public bool pause = false;
    public Animator transitionAnim;
    public gamemaster gm;
    public GameObject pauseUI;
    public GameObject DeadUI;
    public GameObject EndUI;
    public TMP_Text timeText;
    public AudioSource audiosrc;
    public AudioClip click_audio;
    // Use this for initialization
    void Start()
    {
        audiosrc = gameObject.GetComponent<AudioSource>();
        pauseUI.SetActive(false);
        DeadUI.SetActive(false);
        EndUI.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.ourHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause = !pause;

            }
            if (pause)
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0;
            }

            if (pause == false)
            {
                pauseUI.SetActive(false);
                Time.timeScale = 1;
            }
            startingTime -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(startingTime);
            if (startingTime <= 0)
            {
                player.ourHealth = 0;
                startingTime = 0;
            }
        }
        else {

            if (gm.check <= 0)
            {
                EndUI.SetActive(true);
            }
            else if (gm.check > 0) {
                DeadUI.SetActive(true);
            }
        }



    }
    public void FixedUpdate()
    {

    }
    public void resume()
    {
        pause = false;
        audiosrc.PlayOneShot(click_audio, 0.8f);
    }

    public void restart()
    {
        
        audiosrc.PlayOneShot(click_audio, 0.8f);
        if (PlayerPrefs.GetInt("highscore") < gm.points) { PlayerPrefs.SetInt("highscore", gm.points); }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        savescore();
    }

    public void quit()
    {
        SceneManager.LoadScene(0);
        pause = false;
        audiosrc.PlayOneShot(click_audio, 0.8f);
        PlayerPrefs.DeleteKey("points");
        PlayerPrefs.DeleteKey("highscore");
        PlayerPrefs.DeleteKey("life");
        SaveManager.instance.Save();
    }
    void savescore()
    {
        gm.life -= 1;
        PlayerPrefs.SetInt("life", gm.life);
    }
}
