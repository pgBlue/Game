using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour {
	private Transform target;
	private float offset;
	private Vector3 endOffset;
	// Use this for initialization
	void Start () {
		target=GameObject.FindGameObjectWithTag("Plane").transform;
		offset=transform.position.x-target.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		endOffset=transform.position;
		endOffset.x=target.position.x+offset;
		transform.position=endOffset;
	}
}
