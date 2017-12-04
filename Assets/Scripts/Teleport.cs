using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Vector3 destination;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            player.transform.position = destination;
        }
    }
}
