using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : ShipComponent
{
    public float bulletDamage = 1.0f;//how much damage a bullet does on contact
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

    public override void activate()
    {
        //Fire
        if (Time.time > lastFireTime + fireDelay)
        {
            if (resourceBar.ResourceAmount > cost)
            {
                resourceBar.useResource(cost);
                fire();
            }
        }
    }

    protected GameObject fire()
    {
        lastFireTime = Time.time;
        GameObject go = GameObject.Instantiate(bulletPrefab);
        go.transform.position = transform.position;
        go.transform.up = transform.up;
        go.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        return go;
    }
}
