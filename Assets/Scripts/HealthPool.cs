using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPool : MonoBehaviour
{

    public int maxHealth = 100;

    [SerializeField]
    private int health = 0;
    public int HP
    {
        get { return health; }
        set
        {
            int prevHP = health;
            health = value;
            health = Mathf.Clamp(health, 0, maxHealth);
            if (health < prevHP)
            {

            }
            if (health > prevHP)
            {

            }
            if (health == 0)
            {
                if (onDeath != null)
                {
                    onDeath();
                }
            }
        }
    }

    public delegate void OnDeath();
    public OnDeath onDeath;

    private void Start()
    {
        HP = maxHealth;
    }

}
