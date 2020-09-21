using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayer : MonoBehaviour
{
    private Vector3 v3;
    private bool moving;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger == false)
        {
            moving = true;
            collision.transform.SetParent(transform);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger == false)
        {
            moving = false;
            collision.transform.SetParent(null);
        }

    }
    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (v3 * Time.deltaTime);
        }
    }
}
