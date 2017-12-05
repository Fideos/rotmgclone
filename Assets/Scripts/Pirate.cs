using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour {


    public Rigidbody2D rb;
    public Transform player;
    Vector3 playerPos;
    Vector3 vectorDirector;
    private float speed = 15f;

    bool range;

    void Start () {

        range = false;
        rb = GetComponent<Rigidbody2D>();

    }
	
	void Update () {
        if (range == false)
        {
            playerPos = player.position - transform.position;
            vectorDirector = new Vector3(playerPos.x, playerPos.y).normalized;
            playerPos = vectorDirector * speed;
            rb.MovePosition(transform.position + playerPos * Time.fixedDeltaTime);
        }
    }
}
