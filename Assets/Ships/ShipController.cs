using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float rechargeRate = 5;//how much fuel recharges each second

    public List<ResourceBar> resourceBars;
    protected ResourceBar rechargeTarget;//the resource that will currently get recharged
    private int rechargeTargetIndex = 0;//the index of the rechargeTarget in the resourceBars array

    public EngineComponent movementComponent;//the component that receives movement input
    public ShipComponent ability1;//the component in ability slot 1
    public ShipComponent ability2;//the component in ability slot 2
    public ShipComponent ability3;//the component in ability slot 3

    private Rigidbody2D rb2d;
    // Use this for initialization
    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rechargeTarget = resourceBars[rechargeTargetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //Switch recharge target
        if (checkSwitchRechargeTarget())
        {
            rechargeTargetIndex++;
            rechargeTargetIndex = rechargeTargetIndex % resourceBars.Count;
            rechargeTarget = resourceBars[rechargeTargetIndex];
        }
        //Recharge
        rechargeTarget.recharge(rechargeRate * Time.deltaTime);

        //Process Inputs
        checkMovement();
        if (ability1)
        {
            if (checkAbility(ability1, "Ability1"))
            {
                ability1.activate();
            }
        }
        if (ability2)
        {
            if (checkAbility(ability2, "Ability2"))
            {
                ability2.activate();
            }
        }
        if (ability3)
        {
            if (checkAbility(ability3, "Ability3"))
            {
                ability3.activate();
            }
        }

        //Close program
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    protected virtual bool checkSwitchRechargeTarget()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }

    protected virtual void checkMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementComponent.move(horizontal, vertical);
    }

    protected virtual bool checkAbility(ShipComponent component, string buttonName)
    {
        switch (component.activationMoment)
        {
            case ShipComponent.ActivationMoment.BUTTON_DOWN:
                return Input.GetButtonDown(buttonName);
            case ShipComponent.ActivationMoment.BUTTON_HELD:
                return Input.GetButton(buttonName);
            case ShipComponent.ActivationMoment.BUTTON_UP:
                return Input.GetButtonUp(buttonName);
        }
        throw new UnityException("Ship " + name + " has a component (" + component.name + ") that has an activation moment (" + component.activationMoment + ") that is not in the list!");
    }
}
