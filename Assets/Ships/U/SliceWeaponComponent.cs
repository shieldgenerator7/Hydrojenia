using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceWeaponComponent : WeaponComponent
{
    private GameObject currentFire;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    public override void activate()
    {
        //deal damage to opposing object
        Debug.Log(gameObject.transform.parent.name + " dealt " + bulletDamage);
        if (currentFire == null)
        {
            currentFire = fire();
            currentFire.transform.parent = transform;
        }
    }
}
