using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private float speed = 10f;
    private float inputX;
    private float inputY;
    Vector3 vectorDirector;
    Vector3 targetPosition;


    void Start () {

        

    }
	
	void Update () {

        //El personaje no tiene animaciones de caminar de costado pero si de atacar de costado. 

        inputX = Input.GetAxis("Side");
        inputY = Input.GetAxis("UpDown");
        vectorDirector = new Vector3(inputX, inputY).normalized;
        targetPosition = transform.position + vectorDirector * speed;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);




    }
}
