using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoom : MonoBehaviour
{
    public GameObject Boom;
    public float L, R;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(L, R);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Boom, whereToSpawn, Quaternion.identity);
        }
    }
}
