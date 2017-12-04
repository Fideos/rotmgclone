using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    private float speed = 100f;
    public GameObject bullet;
    GameObject bulletClone;

    public Transform origin;
    Vector3 target;

    void ShootBullet()
    {
        target = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(target) - transform.position;
        target.z = 0;
        bulletClone = Instantiate(bullet, origin.position, origin.rotation) as GameObject;
        Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
        rb.AddForce(target * speed);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootBullet();
        }
    }

}
