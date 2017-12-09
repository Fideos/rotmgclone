using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion : MonoBehaviour {

    void DestroyThisObject()
    {
        Destroy(gameObject);
    }

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player")
		{
			MyGameManager.instance.sumarVida();
            DestroyThisObject();
		}
	}
}
