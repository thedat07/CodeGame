using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRun : MonoBehaviour
{
    public AudioSource audiosrc;
    public AudioClip feet;

    void Start()
    {
        audiosrc = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void run()
    {
        audiosrc.PlayOneShot(feet, 0.4f);
    }
}
