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

    private ParticleSystem particles;

    // Audio

    public AudioClip hurtSound;

    //public AudioClip shootSound;

    private AudioSource source;

    private float vol = 0.3f;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

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
        }
    }

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();

    }

    void Update()
    {
        playerPos = player.position - transform.position;
        vectorDirector = new Vector3(playerPos.x, playerPos.y).normalized;
        playerPos = vectorDirector * speed;
        rb.MovePosition(transform.position + playerPos * Time.fixedDeltaTime);
    }
}
