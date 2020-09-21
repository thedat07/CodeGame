using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public float timer;

    public GameObject MenuUI;
    public GameObject OptionUI;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintfAfter(timer));

        OptionUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void Option()
    {
        OptionUI.SetActive(true);
        MenuUI.SetActive(false);

    }
    public void Back()
    {
        OptionUI.SetActive(false);
        MenuUI.SetActive(true);

    }
    IEnumerator PrintfAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        MenuUI.SetActive(true);
    }
    public void Continue()
    {
    }
}
