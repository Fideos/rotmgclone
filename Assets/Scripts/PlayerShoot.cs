using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    private float speed = 1200f;
    public float specialBonusSpeed;
    public GameObject bullet;
    public GameObject specialBullet;
    GameObject bulletClone;
    public AudioClip shootSound;
    public Transform origin;
    public float specialBulletCooldown;
    Vector3 target;
    private AudioSource source;
    bool specialBulletAvailable;

    // Reproduce el audio en 2 distintos volumenes aleatoriamente.
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    IEnumerator Yielder() // CoolDown de la bala especial
    {
        Debug.Log("Cargando bala especial...");
        yield return new WaitForSeconds(specialBulletCooldown);
        specialBulletAvailable = false;
        Debug.Log("¡Bala especial cargada!");
    }

    void ShootBullet(GameObject typeOfBullet, float bonusSpeed)
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(shootSound, vol);
        target = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(target) - transform.position;
        target.z = 0;
        bulletClone = Instantiate(typeOfBullet, origin.position, origin.rotation) as GameObject;
        Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
        rb.AddForce(target.normalized * bonusSpeed);
        
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootBullet(bullet, speed + 0);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!specialBulletAvailable)
            {
                ShootBullet(specialBullet, speed + specialBonusSpeed);
                specialBulletAvailable = true; // Si es seteado a true, impide que la bala sea disparada.
                StartCoroutine("Yielder");
            }
        }
    }

}
