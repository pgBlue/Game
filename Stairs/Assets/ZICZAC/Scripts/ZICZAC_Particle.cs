﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZICZAC_Particle : MonoBehaviour {
	private float timer=2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer-=Time.deltaTime;
		if (timer<0)
		{
			Destroy(gameObject);
		}
	}
}
