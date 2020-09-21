using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public bool pause = false;
    public Animator transitionAnim;
    public gamemaster gm;
    public GameObject MenuUI;
    public GameObject TutorialUI;
    public AudioSource audiosrc;
    public AudioClip click_audio;
    public float timer;
    // Use this for initialization
    void Start()
    {
        audiosrc = gameObject.GetComponent<AudioSource>();
        MenuUI.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
    }

    // Update is called once per frame
    void Update()
    {

            if (timer <= 0)
            {
                MenuUI.SetActive(true);
            }
            else
            {
                timer -= Time.deltaTime;

            }
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
    public void quit()
    {
        Application.Quit();
    }
    

}
