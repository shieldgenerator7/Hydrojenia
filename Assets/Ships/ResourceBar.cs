using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBar : MonoBehaviour
{

    public float maxResource = 100;
    [SerializeField]
    private float currentResource = 0;

    public float ResourceAmount
    {
        get { return currentResource; }
        set
        {
            currentResource = value;
            currentResource = Mathf.Clamp(currentResource, 0, maxResource);
            if (sr != null)
            {
                Color c = sr.color;
                c.a = currentResource / maxResource;
                sr.color = c;
            }
        }
    }

    private SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (ResourceAmount == 0)
        {
            ResourceAmount = maxResource;
        }
    }

    public float useResource(float amount)
    {
        if (currentResource < amount)
        {
            amount = ResourceAmount;
        }
        ResourceAmount -= amount;
        return amount;
    }

    public void recharge(float amount)
    {
        ResourceAmount += amount;
    }
}
