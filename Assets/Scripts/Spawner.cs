﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float respawntime;

    public GameObject spawner;

    bool triggered = false;

    void DesactivateSpawner()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && triggered == false)
        {
            triggered = true;
            Instantiate(spawner, spawner.transform.position, spawner.transform.rotation);
            DesactivateSpawner();
        }
    }

}