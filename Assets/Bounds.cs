using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collGO = collision.GetComponent<Collider2D>().gameObject;
        if (collGO.CompareTag("Player"))
        {
            collGO.transform.position = transform.position - (collGO.transform.position - transform.position);
        }
    }
}
