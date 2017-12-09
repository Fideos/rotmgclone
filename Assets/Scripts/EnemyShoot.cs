using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject bullet;
    public float fireRate; // Intervalo en segundos entre cada bullet.
    public Transform enemyPos;
    Transform target;
    float bulletSpeed = 1000f;
    GameObject bulletClone;
    Vector3 targetPos;
    GameObject playerPos;
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
        target = GameObject.FindGameObjectWithTag("Player").transform; //Busca a Player en escena y lo asigna.
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
