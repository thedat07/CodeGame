using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveDoor : MonoBehaviour
{
    Material material;
    public Player2 player;
    bool isDissolving = false;
    public float fade = 1f;
    public float start = 0f;
    public bool startPlayer;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        start += Time.deltaTime ;
        if (start >= 1f)
        {
            start = 1f;
        }
        material.SetFloat("_Fade", start);
    }
}
