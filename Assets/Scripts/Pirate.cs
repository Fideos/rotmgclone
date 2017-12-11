using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pirate : MonoBehaviour {


    public Rigidbody2D rb;
    public float intervalo;
    Vector3 vectorDirector;
    Vector3 targetPosition;
    private float speed = 750f, timer;
    public int maxLife;
    float X, Y;
	public GameObject pocion;
    public Transform origin;

    private ParticleSystem particles;

    // Audio

    public AudioClip hurtSound;

    //public AudioClip shootSound;

    private AudioSource source;

    private float vol = 0.3f;

    void RandomDirections()
    {
        X = Random.Range(origin.position.x-10, origin.position.x+10);
        Y = Random.Range(origin.position.y-10, origin.position.y+10);
    }

    void Movement()
    {
        RandomDirections();
        targetPosition = new Vector3(X, Y);
        vectorDirector = targetPosition - transform.position;
        rb.AddForce(vectorDirector.normalized * speed);
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

			int probabilidad = Random.Range (1, 11);


			if (probabilidad >= 5)
			{

				Instantiate(pocion, origin.position, origin.rotation);

			}

        }
    }

    void Awake () {

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        origin = this.transform;
        particles = GetComponent<ParticleSystem>();

    }

    void Update()
    {
        timer = timer + 1 * Time.deltaTime;

        if (timer > intervalo)
        {
            Movement();
            timer = timer - intervalo;
        }
    }

}
