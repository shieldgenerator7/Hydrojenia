using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour {

    public enum ActivationButton
    {
        ABILITY_1,
        ABILITY_2,
        ABILITY_3,
        NONE
    }
    public ActivationButton activationButton;
    public float cost = 1;//cost per unit or cost per second, depending on costType
    public enum CostType
    {
        PER_UNIT,
        PER_SECOND
    }
    public CostType costType = CostType.PER_SECOND;
    /// <summary>
    /// The higher this number, the more units/seconds this component gets per energy spent
    /// (only really applicable to PER_SECOND components)
    /// </summary>
    public float efficiency = 2;
    public ResourceBar resourceBar;
    public Sprite resourceSprite;//to be used for the resource meter to distinguish it from other components

    protected Rigidbody2D rb2d;

    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d == null)
        {
            rb2d = GetComponentInParent<Rigidbody2D>();
        }
    }
}
