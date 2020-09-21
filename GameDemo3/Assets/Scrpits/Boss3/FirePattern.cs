using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern : MonoBehaviour
{
    
    public GameObject bullet;
    public float fireRate;
    private float randomDirectionModifier, randomSpeed;
    float nextFire;
    public AudioSource audiosrc;
    public AudioClip attack_audio;
    private void Start()
    {
        nextFire = Time.time;
        audiosrc = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
       if (Time.time > nextFire) {
            Fire();
            audiosrc.PlayOneShot(attack_audio, 0.2f);
            nextFire = Time.time + fireRate;
        }
    }
    public void Fire()
    {
        for(int i = 0; i <= 3; i++)
        {
            var Bullet = Instantiate(bullet, transform.position, transform.rotation);
            randomDirectionModifier = Random.Range(-0.5f, 0.5f);
            randomSpeed= Random.Range(350f, 400f);
            Bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f + randomDirectionModifier, -1f) * randomSpeed);
        }
    }


}
