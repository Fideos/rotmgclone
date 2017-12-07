using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float lifeTime; //Determina tiempo de vida de la bullet
    public Rigidbody2D rb;
    bool active = true;


    IEnumerator Yielder() // Eliminar este destructor despues de implementar object pool.
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

    //Recogido de bullets se va a implementar mas tarde
    void OnCollisionEnter2D()
    {
        rb.velocity = Vector3.zero;
        StartCoroutine("Yielder");
        active = false;
    }


    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update () {
        if (active)
        {
            transform.Rotate(0, 0, 720 * Time.deltaTime);
        }
        else
        {
            transform.Rotate(180 * Time.deltaTime, 0, 0);
        }
    }
}
