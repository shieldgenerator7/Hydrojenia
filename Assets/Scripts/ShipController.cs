using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float movementSpeed = 5;
    public float speedPerFuel = 10;//how much each speed increase costs in fuel

    public float rechargeRate = 5;//how much fuel recharges each second

    public float fireCost = 2.0f;//how much each bullet costs
    public float bulletSpeed = 3.0f;//how fast the bullets travel
    public float fireDelay = 0.1f;//time between each shot
    private float lastFireTime = 0;

    public ResourceBar shieldResource;
    public ResourceBar weaponResource;
    public ResourceBar engineResource;

    public GameObject bulletPrefab;

    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Recharge
        engineResource.recharge(rechargeRate * Time.deltaTime);
        //Move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movementVector = new Vector2(horizontal, vertical);
        float energy = engineResource.useResource(movementVector.magnitude * movementSpeed / speedPerFuel);
        energy *= speedPerFuel;
        if (energy > 0)
        {
            rb2d.AddForce(movementVector * energy);
        }
        //Fire
        if (Input.GetMouseButton(0))
        {
            if (Time.time > lastFireTime + fireDelay)
            {
                if (weaponResource.ResourceAmount > fireCost)
                {
                    weaponResource.useResource(fireCost);
                    fire();
                }
            }
        }
	}

    private void fire()
    {
        lastFireTime = Time.time;
        GameObject go = GameObject.Instantiate(bulletPrefab);
        go.transform.position = transform.position;
        go.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
    }
}
