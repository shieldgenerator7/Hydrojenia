using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour {

    public float cost = 1;//cost per unit or cost per second, depending on costType
    public enum CostType
    {
        PER_UNIT,
        PER_SECOND
    }
    public CostType costType = CostType.PER_SECOND;
    public float efficiency = 2;//the higher this number, the more units/seconds this component gets per energy spent
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
