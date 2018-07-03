using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearObject : MonoBehaviour {
	private float timer;
	// Use this for initialization
	void Start () {
		timer=1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		timer-=Time.deltaTime;
		if (timer<=0)
		{
			Destroy(gameObject);
		}
	}

}
