using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float movementSpeed = 5;

    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movementVector = new Vector2(horizontal, vertical).normalized;
        //Debug.Log("movementVector: " + movementVector * movementSpeed);
        rb2d.AddForce(movementVector * movementSpeed);
        Debug.Log("rb2d velcoity: " + rb2d.velocity);
	}
}
