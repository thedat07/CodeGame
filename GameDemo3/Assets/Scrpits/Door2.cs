using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour
{
    private Animator animator;
    public Animator transitionAnim;
    private Player2 player;
    public bool open = false;
    public int Levelload = 1;
    public gamemaster gm;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("open");
            open = true;
        }
        if (open == true)
        {
            savescore();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("open");
            open = true;
        }
        if (open == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                savescore();
                StartCoroutine(LoadScence());
            }
        }
    }
    IEnumerator LoadScence()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void savescore()
    {
        PlayerPrefs.SetInt("points", gm.points);
        PlayerPrefs.SetInt("life", gm.life);
    }
}
