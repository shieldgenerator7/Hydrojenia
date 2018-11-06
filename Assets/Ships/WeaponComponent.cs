using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : ShipComponent
{

    public float bulletSpeed = 3.0f;//how fast the bullets travel
    public float fireDelay = 0.1f;//time between each shot
    private float lastFireTime = 0;

    public GameObject bulletPrefab;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        costType = CostType.PER_UNIT;
    }

    // Update is called once per frame
    void Update()
    {
        //Fire
        if (Input.GetMouseButton(0))
        {
            if (Time.time > lastFireTime + fireDelay)
            {
                if (resourceBar.ResourceAmount > cost)
                {
                    resourceBar.useResource(cost);
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
        go.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
