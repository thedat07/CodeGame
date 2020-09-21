using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    public Animator anim;
    float fireRate;
    float nextFire;
    public bool movingRight = true;
    public GameObject boomL;
    public GameObject boomR;
    public Transform shotPoint;
    // Use this for initialization
    void Start()
    {
        fireRate = 5f;
        nextFire = Time.time;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            anim.SetTrigger("shoot");
            nextFire = Time.time + fireRate;
        }

    }
    void BulletFire()
    {
        if (movingRight == true) Instantiate(boomR, shotPoint.position, transform.rotation); 
        if (movingRight == false) Instantiate(boomL, shotPoint.position, transform.rotation); 

    }
}
