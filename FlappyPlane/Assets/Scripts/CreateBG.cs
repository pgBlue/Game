using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBG : MonoBehaviour {
	public static CreateBG instance;
	public int amountBG;
	public float distanceX;
	public GameObject[] objectBGs;
	public Vector2 startPos;
	private List<GameObject> bgObjects;
	private Transform createPoint;
	private int bgIndex;
	
	void Awake()
	{
		instance=this;
	}
	// Use this for initialization
	void Start () {
		createPoint=GameObject.FindGameObjectWithTag("createPoint").transform;
		startPos=transform.position;

		bgIndex=Random.Range(0,objectBGs.Length-1);

		bgObjects=new List<GameObject>();

		for (int i = 0; i < amountBG; i++)
		{
			GameObject obj=(GameObject)Instantiate(objectBGs[bgIndex]);
			obj.SetActive(false);
			bgObjects.Add(obj);
		}
	}
	private GameObject GetBG()
	{
		for (int i = 0; i < bgObjects.Count; i++)
		{
			if (!bgObjects[i].activeInHierarchy)
			{
				return bgObjects[i];
			}
		}
		return null;
	}
	// Update is called once per frame
	void Update () {
		if (transform.position.x<createPoint.position.x)
		{
			Create();
		}
	}
	private void Create()
	{
		GameObject obj=GetBG();
		obj.transform.position=transform.position;
		obj.transform.rotation=transform.rotation;
		obj.SetActive(true);
		transform.position=new Vector2(transform.position.x+distanceX,transform.position.y);
	}
}
