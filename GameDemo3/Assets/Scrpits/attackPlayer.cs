using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayer : MonoBehaviour
{
    public int dmg = 10;
    Player2 player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy") || col.CompareTag("Enemy2") || col.CompareTag("Enemy3") || col.CompareTag("Enemy4") || col.CompareTag("Boss1"))
        {
            col.SendMessageUpwards("Damage", dmg);
            player.JumpAttack();
        }
    }
}
