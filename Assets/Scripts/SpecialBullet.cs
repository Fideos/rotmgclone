using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour {

    public float lifeTime; //Determina tiempo de vida de la bullet
    public Rigidbody2D rb;

    IEnumerator Yielder() // Eliminar este destructor despues de implementar object pool.
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

    void Start()
    {
        StartCoroutine("Yielder");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Rotate(0, 0, 720 * Time.deltaTime);
    }
}

