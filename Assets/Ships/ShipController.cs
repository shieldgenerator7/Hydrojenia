using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    
    public float rechargeRate = 5;//how much fuel recharges each second

    public float fireCost = 2.0f;//how much each bullet costs
    public float bulletSpeed = 3.0f;//how fast the bullets travel
    public float fireDelay = 0.1f;//time between each shot
    private float lastFireTime = 0;

    public ResourceBar shieldResource;
    public ResourceBar weaponResource;
    public ResourceBar engineResource;
    private ResourceBar rechargeTarget;//the resource that will currently get recharged

    public GameObject bulletPrefab;

    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rechargeTarget = engineResource;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Switch recharge target
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (rechargeTarget == engineResource)
            {
                rechargeTarget = weaponResource;
            }
            else
            {
                rechargeTarget = engineResource;
            }
        }
        //Recharge
        rechargeTarget.recharge(rechargeRate * Time.deltaTime);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
