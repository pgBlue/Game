using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZICZAC_disable : MonoBehaviour {
	Rigidbody mrb;
	bool isPlay;
	// Use this for initialization
	void Start () {
		mrb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {		
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag=="Ball")
		{
			mrb.isKinematic=false;
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag=="Clear")
		{
			gameObject.SetActive(false);
			transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
