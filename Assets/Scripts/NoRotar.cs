using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotar : MonoBehaviour {

    GameObject player;
    private Vector3 distance;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distance = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position + distance;
    }

}
