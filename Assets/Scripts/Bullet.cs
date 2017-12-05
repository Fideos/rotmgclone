using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    bool active = true;

    //Recogido de bullets se va a implementar mas tarde
    void OnCollisionEnter2D()
    {
        rb.velocity = Vector3.zero;
        active = false;
    }


    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        if (active)
        {
            transform.Rotate(0, 0, 360 * Time.deltaTime);
        }
        else
        {
            transform.Rotate(180 * Time.deltaTime, 0, 0);
        }
    }
}
