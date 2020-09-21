using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableobject : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;
    float dirY;
    float torque;
    void Start()
    {
        dirX = Random.Range(-2, 2);
        dirY = Random.Range(2, 5);
        torque = Random.Range(2, 10);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);
    }
    private void Update()
    {
        Destroy(gameObject, 10f);
    }
}
