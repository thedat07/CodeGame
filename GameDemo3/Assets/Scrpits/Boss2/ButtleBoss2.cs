using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtleBoss2 : MonoBehaviour
{

    public GameObject clown1, clown2;
    public int dmg = 1;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", dmg);
            Instantiate(clown1, transform.position, Quaternion.identity);
            Instantiate(clown2, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (col.CompareTag("Ground") || col.CompareTag("vien"))
        {
            Instantiate(clown1, transform.position, Quaternion.identity);
            Instantiate(clown2, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
