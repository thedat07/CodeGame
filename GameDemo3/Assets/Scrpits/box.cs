using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public Rigidbody2D r2;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }
   

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * 5 * h);
    }
}
