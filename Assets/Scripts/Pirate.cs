using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour {


    public Rigidbody2D rb;
    public Transform player;
    Vector3 playerPos;
    Vector3 vectorDirector;
    private float speed = 15f;
    public int maxLife;

    private ParticleSystem particles;

    // Audio
    public AudioClip deathSound;

    public AudioClip hurtSound;

    //public AudioClip shootSound;

    private AudioSource source;

    private float vol = 0.3f;

    bool range;

    IEnumerator Yielder() // Espera 2 segundos y destruye el objeto
    {
        yield return new WaitForSeconds(1);
        source.PlayOneShot(deathSound, vol);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            maxLife--;
            particles.Play();
            source.PlayOneShot(hurtSound, vol);
        }
        //Checkea si esta muerto.
        if (maxLife <= 0)
        {
            StartCoroutine("Yielder");
        }
    }

    void Awake () {

        range = false;
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();

    }

    void Update()
    {
        if (maxLife <= 0)
        {
            transform.Rotate(0, 0, 360 * Time.deltaTime);
        }

        // Caminar hacia el jugador. (Debe asignarse el transform del player para que funcione)
        /*
        playerPos = player.position - transform.position;
        vectorDirector = new Vector3(playerPos.x, playerPos.y).normalized;
        playerPos = vectorDirector * speed;
        rb.MovePosition(transform.position + playerPos * Time.fixedDeltaTime);
        */
    }

}
