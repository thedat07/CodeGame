using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTD : MonoBehaviour
{
    public Player2 player;
    public float speed = 0.05f, changeDirection = -1;
    Vector2 Move;
    public bool a = false;
    public PauseMenu pausep;

    // Use this for initialization
    void Start()
    {
        Move = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        pausep = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
    }
    private void Update()
    {

        if (pausep.pause)
        {
            this.transform.position = this.transform.position;

        }
        if (pausep.pause == false)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground") || col.collider.CompareTag("vien"))
        {
            speed *= changeDirection;
            a = true;
        }
    }
}
