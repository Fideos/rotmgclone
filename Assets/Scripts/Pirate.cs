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
    int X, Y;
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
        X = Random.Range(-9, 10);
        Y = Random.Range(-9, 10);
    }

    void Movement()
    {
        RandomDirections();
        targetPosition = new Vector3(X, Y);
        vectorDirector = targetPosition - transform.position;
        rb.AddForce(vectorDirector.normalized * speed);
    }

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        origin = this.transform;

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

				GameObject Pocion = Instantiate(pocion, origin.position, origin.rotation) as GameObject;

			}

        }
    }

    void Awake () {

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();

    }

    void Update()
    {
        // Caminar hacia el jugador. (Debe asignarse el transform del player para que funcione)
        /*
        playerPos = player.position - transform.position;
        vectorDirector = new Vector3(playerPos.x, playerPos.y).normalized;
        playerPos = vectorDirector * speed;
        rb.MovePosition(transform.position + playerPos * Time.fixedDeltaTime);

        */

        timer = timer + 1 * Time.deltaTime;

        if (timer > intervalo)
        {
            Movement();
            timer = timer - intervalo;
        }
    }

}
