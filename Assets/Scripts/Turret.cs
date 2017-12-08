using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    Vector3 vectorDirector;
    public int maxLife;

    private ParticleSystem particles;

    // Audio

    public AudioClip hurtSound;

    //public AudioClip shootSound;

    private AudioSource source;

    private float vol = 0.3f;

    bool range;

    IEnumerator Yielder() // Espera 2 segundos y destruye el objeto
    {
        yield return new WaitForSeconds(2);
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

    void Awake()
    {

        range = false;
        source = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();

    }

    void Update()
    {
        if (maxLife <= 0)
        {
            transform.Rotate(0, 0, 360 * Time.deltaTime);
        }
    }

}
