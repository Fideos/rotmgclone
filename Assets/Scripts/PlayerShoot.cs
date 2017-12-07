using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    private float speed = 1200f;
    public GameObject bullet;
    GameObject bulletClone;
    public AudioClip shootSound;
    public Transform origin;
    Vector3 target;
    private AudioSource source;

    // Reproduce el audio en 2 distintos volumenes aleatoriamente.
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void ShootBullet()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(shootSound, vol);
        target = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(target) - transform.position;
        target.z = 0;
        bulletClone = Instantiate(bullet, origin.position, origin.rotation) as GameObject;
        Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
        rb.AddForce(target.normalized * speed);
        
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootBullet();
        }
    }

}
