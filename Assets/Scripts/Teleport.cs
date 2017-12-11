using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Vector3 destination;

    private GameObject[] spawners;

    void destroyObjectsInScene()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");

        for (var i = 0; i < spawners.Length; i++)
        {
            Destroy(spawners[i]);
        }
    }

void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            player.transform.position = destination;
            destroyObjectsInScene();
        }
    }
}

