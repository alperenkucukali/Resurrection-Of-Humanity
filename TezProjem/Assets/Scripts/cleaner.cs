using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth playerFall = other.GetComponent<playerHealth>();
            playerFall.makeDead();
        }
        else Destroy(other.gameObject);
    }
}
