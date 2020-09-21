using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableRB : MonoBehaviour
{
    [SerializeField]
    Vector2 forceDirection;
    [SerializeField]
    float torque;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(forceDirection);
        rb.AddTorque(torque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
