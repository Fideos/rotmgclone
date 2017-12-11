using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
	public static MyGameManager instance;


    public float vida;

    public AudioClip healPotion;

    private AudioSource source;

    private float vol = 0.3f;

    void Awake()
	{
		if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        source = GetComponent<AudioSource>();
    }

	public void sumarVida()
	{
		if (vida < 5)
		{
			vida++;
            Debug.Log("Vida del personaje: " + vida);
            source.PlayOneShot(healPotion, vol);
        }
	}
	public void restarVida()
	{
		if (vida > 0)
		{
			vida--;
			Debug.Log("Vida del personaje: " + vida);
		}
	}
}
