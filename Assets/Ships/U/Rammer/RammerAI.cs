using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerAI : ShipController
{

    public float distanceThreshold = 2;

    public GameObject morePrefab;

    GameObject player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<HealthPool>().onDeath += spawnMore;
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

    void spawnMore()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject go = GameObject.Instantiate(morePrefab);
            go.transform.position = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0));
        }
    }

}
