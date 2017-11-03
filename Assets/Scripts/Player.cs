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


    void Start () {

		rb = GetComponent<Rigidbody2D>();

    }
		
	void Update (){



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
