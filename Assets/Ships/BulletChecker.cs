using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChecker : MonoBehaviour {

    public float damage;
    public GameObject owner;

    private void Start()
    {
        RaycastHit2D[] rch2ds = new RaycastHit2D[10];
        int count = GetComponent<Collider2D>().Cast(Vector2.zero, rch2ds, 0, true);
        for (int i = 0; i < count; i++)
        {
            checkCollisionWithObject(rch2ds[i].collider.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll2d)
    {
        checkCollisionWithObject(coll2d.gameObject);
    }

    void checkCollisionWithObject(GameObject other)
    {
        if (other != owner)
        {
            HealthPool hp = other.GetComponent<HealthPool>();
            if (hp)
            {
                hp.HP -= (int)damage;
                Destroy(gameObject);
            }
        }
    }
}
