using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    
    public float rechargeRate = 5;//how much fuel recharges each second
    
    public ResourceBar shieldResource;
    public ResourceBar weaponResource;
    public ResourceBar engineResource;
    private ResourceBar rechargeTarget;//the resource that will currently get recharged
    
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
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}    
}
