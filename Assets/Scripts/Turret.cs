using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public int maxLife;


    private ParticleSystem particles;

    // Audio

    public AudioClip hurtSound;

    //public AudioClip shootSound;

    private AudioSource source;

    private float vol = 0.3f;

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
        }
    }

    void Awake()
    {

        source = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();

    }

    void Update()
    {
    }

}
