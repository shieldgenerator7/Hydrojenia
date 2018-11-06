using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineComponent : ShipComponent {

    public float movementSpeed = 5;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        costType = CostType.PER_SECOND;
	}
	
	// Update is called once per frame
	void Update () {
        //Move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movementVector = new Vector2(horizontal, vertical);
        float energy = resourceBar.useResource(movementVector.magnitude * movementSpeed / efficiency);
        energy *= efficiency;
        if (energy > 0)
        {
            rb2d.AddForce(movementVector * energy);
        }
    }
}
