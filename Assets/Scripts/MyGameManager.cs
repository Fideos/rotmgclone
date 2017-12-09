using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
	public static MyGameManager instance;


	public float vida;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this.gameObject);
	}

	public void sumarVida()
	{
		if (vida < 5)
		{
			vida++;
			Debug.Log("Vida del personaje: " + vida);
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
