using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DIALOG : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject button;
    public bool DIALOGSystem=true;
    public AudioSource audio;
    public int Levelload;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            button.SetActive(true);
        }
        if (Input.GetKeyDown("space"))
        {
            typingSpeed = 0.01f;
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        
        button.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            audio.Play();
            
        }
        else
        {
            textDisplay.text = "";
            SceneManager.LoadScene(Levelload);
        }
    }
}
