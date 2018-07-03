using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZICZAC_Camera : MonoBehaviour {
	private Transform target;
	private  Vector3 offset,endOffset;
	// Use this for initialization
	void Start () {
		target=GameObject.FindGameObjectWithTag("Ball").transform;
		offset=transform.position-target.position;
	}
	
	// Update is called once per frame
	void Update () {
		endOffset=transform.position;
		endOffset.x=target.position.x+offset.x;
		endOffset.z=target.position.z+offset.z;
		transform.position=endOffset;
	}
}
