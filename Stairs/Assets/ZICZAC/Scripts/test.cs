using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
	private int mm;
	public Text a1,a2;
	// Use this for initialization
	void Start () {
		PlayerPrefs.GetInt("mn");
	}
	
	// Update is called once per frame
	void Update () {
		if (mm>PlayerPrefs.GetInt("mn"))
		{
			PlayerPrefs.SetInt("mn",mm);
		}
		a1.text=""+mm.ToString();
		a2.text=""+PlayerPrefs.GetInt("mn").ToString();
	}
	public void btn()
	{
		mm+=5;
		
	}
}
