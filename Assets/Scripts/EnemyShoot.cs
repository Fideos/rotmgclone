using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject bullet;
    public float fireRate; // Intervalo en segundos entre cada bullet.
    public Transform target; // Debe setearse con el Player que se encuentra en escena.
    public Transform enemyPos;

    float bulletSpeed = 1000f;
    GameObject bulletClone;
    Vector3 targetPos;
    float timer;
    bool fire;
    //bool range;

    void Shoot()
    {
        targetPos = target.position - transform.position;
        bulletClone = Instantiate(bullet, enemyPos.position, enemyPos.rotation) as GameObject;
        Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
        rb.AddForce(targetPos.normalized * bulletSpeed);
    }

    void Awake () {
	}
	

	void Update () {
        timer = timer + 1 * Time.deltaTime;

        if (timer > fireRate)
        {
            Shoot();
            timer = timer - fireRate;
        }
	}
}
