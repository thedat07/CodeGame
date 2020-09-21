using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class KeyMenu : MonoBehaviour
{
    public Player2 player;
    public int key = 0;

    public TMP_Text keyMenu;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
    }

    // Update is called once per frame
    void Update()
    {
        key = player.key;
        keyMenu.text = ("Key: " + key + "/1");
    }
}
