using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion : MonoBehaviour {

    bool triggered = false;

    void DestroyThisObject()
    {
        Destroy(gameObject);
    }

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player" && triggered == false)
		{
			MyGameManager.instance.sumarVida();
            DestroyThisObject();
		}
	}
}
