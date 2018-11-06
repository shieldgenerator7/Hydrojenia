using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    
    public float rechargeRate = 5;//how much fuel recharges each second

    public List<ResourceBar> resourceBars;
    private ResourceBar rechargeTarget;//the resource that will currently get recharged
    private int rechargeTargetIndex = 0;//the index of the rechargeTarget in the resourceBars array
    
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rechargeTarget = resourceBars[rechargeTargetIndex];
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Switch recharge target
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rechargeTargetIndex++;
            rechargeTargetIndex = rechargeTargetIndex % resourceBars.Count;
            rechargeTarget = resourceBars[rechargeTargetIndex];
        }
        //Recharge
        rechargeTarget.recharge(rechargeRate * Time.deltaTime);
        
        //Close program
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}    
}
