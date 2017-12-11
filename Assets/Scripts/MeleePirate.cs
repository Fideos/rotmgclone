using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePirate : MonoBehaviour {

    public Rigidbody2D rb;
    Vector3 vectorDirector;
    Vector3 playerPos;
    public float speed;
    public int maxLife;
    Transform player;
    public GameObject pocion;
    public Transform origin;

    private ParticleSystem particles;

    // Audio

    public AudioClip hurtSound;

    //public AudioClip shootSound;

    private AudioSource source;

    private float vol = 0.3f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet" && maxLife > 0)
        {
            maxLife--;
            particles.Play();
            source.PlayOneShot(hurtSound, vol);
        }
        //Checkea si esta muerto.
        if (maxLife <= 0)
        {
            Destroy(this.gameObject);

            int probabilidad = Random.Range(1, 11);


            if (probabilidad >= 5)
            {

                Instantiate(pocion, origin.position, origin.rotation);

            }
        }
    }

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        origin = this.transform;

    }

    void Update()
    {
        playerPos = player.position - transform.position;
        vectorDirector = new Vector3(playerPos.x, playerPos.y).normalized;
        playerPos = vectorDirector * speed;
        rb.MovePosition(transform.position + playerPos * Time.fixedDeltaTime);
    }
}
