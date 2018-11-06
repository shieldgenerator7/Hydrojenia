using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerAI : ShipController {

    public float distanceThreshold = 2;

    GameObject player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    protected override bool checkSwitchRechargeTarget()
    {
        return !rechargeTarget.CompareTag("EngineComponent");
    }

    protected override void checkMovement()
    {
        float horizontal = 0;
        float vertical = -1;
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > distanceThreshold)
        {
            horizontal = Mathf.Sign(player.transform.position.x - transform.position.x);
        }
        movementComponent.move(horizontal, vertical);
    }

    protected override bool checkAbility(ShipComponent component, string buttonName)
    {
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ability1.activate();
    }

}
