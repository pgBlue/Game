using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour {
	private Transform target;
	// Use this for initialization
	void Start () {
		target=GameObject.FindGameObjectWithTag("clearPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x<target.position.x)
		{
			gameObject.SetActive(false);
		}
	}
}
