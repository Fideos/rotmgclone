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

    private Animator anim;

    //Audio (Para reproducir el audio, el clip debe estar en el objeto como un AudioSource y en el Script como un AudioClip)

    public AudioClip hurtSound;

    private AudioSource source;

    private float vol = 0.5f;

    bool rotadoDerecha = true;
    public SpriteRenderer spritePlayer;

    private void Awake()
    {
        spritePlayer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet")
        {
            source.PlayOneShot(hurtSound, vol);
            MyGameManager.instance.restarVida();
        }
    }

    void Start () {

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

	void FixedUpdate () 
	{
		
        inputX = Input.GetAxis("Side");
        inputY = Input.GetAxis("UpDown");
        vectorDirector = new Vector3(inputX, inputY).normalized;
        targetPosition =  vectorDirector * speed;
		rb.MovePosition(transform.position + targetPosition * Time.fixedDeltaTime);

        
    }

    void Update()
    {

        
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("Lado", 1);
            if (!rotadoDerecha)
            {
                transform.Rotate(Vector3.up, 180);
                rotadoDerecha = true;
            }
            anim.SetBool("Camina", true);

            
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("Lado", 1);
            anim.SetBool("Camina", false);
        }


        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Lado", 0);
            anim.SetBool("Camina", true);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("Lado", 0);
            anim.SetBool("Camina", false);
        }




        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("Lado", 2);
            anim.SetBool("Camina", true);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("Lado", 2);
            anim.SetBool("Camina", false);
        }




        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("Lado", 1);

            if (rotadoDerecha)
            {
                transform.Rotate(Vector3.up, 180);
                rotadoDerecha = false;
            }
            
            anim.SetBool("Camina", true);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("Lado", 1);
            anim.SetBool("Camina", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("Ataca", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("Ataca", false);
        }
    }
}
