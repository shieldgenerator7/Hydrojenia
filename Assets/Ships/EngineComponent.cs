using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineComponent : ShipComponent {

    public float movementSpeed = 5;
    public float speedDecayRate = 1;//how much speed is lost per second after not moving

	// Use this for initialization
	protected override void Start () {
        base.Start();
        costType = CostType.PER_SECOND;
	}
	
	public void move(float horizontal, float vertical) { 
        //Move
        Vector2 movementVector = new Vector2(horizontal, vertical);
        float energy = resourceBar.useResource(movementVector.magnitude * movementSpeed / efficiency);
        energy *= efficiency;
        if (energy > 0)
        {
            rb2d.AddForce(movementVector * energy);
        }
        else if (rb2d.velocity.sqrMagnitude > 0)
        {
            rb2d.velocity += -rb2d.velocity * speedDecayRate * Time.deltaTime;
        }
        if (rb2d.velocity.sqrMagnitude > movementSpeed * movementSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * movementSpeed;
        }
    }
}
