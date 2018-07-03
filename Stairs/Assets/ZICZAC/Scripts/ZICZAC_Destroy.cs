using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZICZAC_Destroy : MonoBehaviour {
	Rigidbody mrb;
	// Use this for initialization
	void Start () {
			mrb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag=="Clear")
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag=="Ball")
		{
			mrb.isKinematic=false;
		}
	}
}
