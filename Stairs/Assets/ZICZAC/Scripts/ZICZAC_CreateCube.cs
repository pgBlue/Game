using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZICZAC_CreateCube : MonoBehaviour {
	public static ZICZAC_CreateCube instance;
	public Color[] cubeColor;
	public GameObject cube,startCube;
	public int amountCube;
	public int gemCount,cubeCount,gemIndex;
	public Vector3 startPos;
	private List<GameObject> cubeObjects;
	private Transform nextCreate;
	private bool direction;
	private float distance=2f;
	private int cubeTotal,gemEnable;
	
	 
	 void Awake()
	 {
		 instance=this;
	 }
	
	// Use this for initialization
	void Start () {
		startPos=transform.position;
		nextCreate=GameObject.FindGameObjectWithTag("nextCube").transform;
		//
		cubeObjects=new List<GameObject>();
		for (int i = 0; i < amountCube; i++)
		{
			GameObject obj=(GameObject)Instantiate(cube);
			obj.SetActive(false);
			cubeObjects.Add(obj);
		}
		gemIndex=Random.Range(0,cubeColor.Length-1);
		//
		GameObject startObj=(GameObject)Instantiate(startCube);
		startObj.transform.position=new Vector3(0,0,0);
		startObj.transform.rotation=Quaternion.identity;
		startObj.GetComponent<MeshRenderer>().material.color=cubeColor[gemIndex];
	}
	private GameObject GetCube()
	{
		for (int i = 0; i < cubeObjects.Count; i++)
		{
			if (!cubeObjects[i].activeInHierarchy)
			{
				return cubeObjects[i];
			}
		}
		return null;
	}
	// Update is called once per frame
	void Update () {
		ChangeColor();
		if (!direction)
		{
			if (transform.position.z<nextCreate.position.z)
			{
				CreateCube();
			}
		}
		else
		{
			if (transform.position.x>nextCreate.position.x)
			{
				CreateCube();
			}
		}
	}
	private void CreateCube()
	{
		
		gemEnable=Random.Range(0,10);
		if (cubeCount>cubeTotal)
		{
			direction=!direction;
			cubeTotal=Random.Range(1,5);
			cubeCount=0;
		}
		
		GameObject obj=GetCube();
		obj.transform.position=transform.position;
		obj.transform.rotation=Quaternion.identity;
		if (gemEnable==1)
		{
			obj.transform.GetChild(0).gameObject.SetActive(true);
		}
		else
		{
			obj.transform.GetChild(0).gameObject.SetActive(false);
		}
		obj.GetComponent<Rigidbody>().isKinematic=true;
		obj.SetActive(true);
		cubeCount++;
		if (!direction)
		{
			transform.position=new Vector3(transform.position.x,
				transform.position.y,
				transform.position.z+distance);
		}
		else
		{
			transform.position=new Vector3(transform.position.x-distance,
				transform.position.y,
				transform.position.z);
		}

	}
	private void ChangeColor()
	{
		if (gemCount>10)
		{
			if (gemIndex>=cubeColor.Length-1)
			{
				gemIndex=0;
			}
			else
			{
				gemIndex++;
			}
			gemCount=0;
		}
		
		GameObject[] objs=GameObject.FindGameObjectsWithTag("Cube");
		foreach (var obj in objs)
		{
			obj.GetComponent<MeshRenderer>().material.color=cubeColor[gemIndex];
		}
	}
}
