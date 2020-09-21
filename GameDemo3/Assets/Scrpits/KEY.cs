using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEY : MonoBehaviour
{
    private SpringJoint2D spring;

    // Start is called before the first frame update
    void Start()
    {
        spring = GetComponent<SpringJoint2D>();
        GameObject backpack = GameObject.FindWithTag("Backpack");
        spring.connectedBody = backpack.GetComponent<Rigidbody2D>();
        spring.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !spring.enabled)
        {
            spring.enabled = true;
        }
    }
}
