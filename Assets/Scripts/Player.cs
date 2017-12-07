using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private float speed = 20f;
    private float inputX;
    private float inputY;
    Vector3 vectorDirector;
    Vector3 targetPosition;
    public Rigidbody2D rb;

    public int maxHealth;

    //Audio (Para reproducir el audio, el clip debe estar en el objeto como un AudioSource y en el Script como un AudioClip)

    public AudioClip hurtSound;

    private AudioSource source;

    private float vol = 0.5f;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet")
        {
            source.PlayOneShot(hurtSound, vol);
            maxHealth--;
            Debug.Log("Vida del personaje: " + maxHealth);
        }
    }

    void Start () {

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

    }

	void FixedUpdate () 
	{
		
        inputX = Input.GetAxis("Side");
        inputY = Input.GetAxis("UpDown");
        vectorDirector = new Vector3(inputX, inputY).normalized;
        targetPosition =  vectorDirector * speed;
		rb.MovePosition(transform.position + targetPosition * Time.fixedDeltaTime);
    }
}
