using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour {
	public static CreateTile instance;
	public int amountTile;
	public float distanceX;
	public GameObject[]	objectTiles;
	public Vector2 startPos;
	//private int gemActive;
	private int tileIndex;
	//private bool isTile;
	private List<GameObject> tileObjects;
	private Transform createPoint;
	private float[] tilePosY={-1.2f,-.7f,-.2f,.3f,.8f,1.3f,1.8f};
	private int tilePosYIndex;
	//private float[] starPosY={0.3f,1f,1.7f};
	//private int starIndex;
	//private float starPosX=0.7f;

	void Awake()
	{
		instance=this;
	}
	// Use this for initialization
	void Start () {
		createPoint=GameObject.FindGameObjectWithTag("createPoint").transform;
		startPos=transform.position;

		tileIndex=Random.Range(0,objectTiles.Length-1);

		tileObjects=new List<GameObject>();

		for (int i = 0; i < amountTile; i++)
		{
			GameObject obj=(GameObject)Instantiate(objectTiles[tileIndex]);
			obj.SetActive(false);
			tileObjects.Add(obj);
		}
	}
	private GameObject GetTile()
	{
		for (int i = 0; i < tileObjects.Count; i++)
		{
			if (!tileObjects[i].activeInHierarchy)
			{
				return tileObjects[i];
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
		GameObject obj=GetTile();
		
		obj.transform.position=transform.position;
		obj.transform.rotation=transform.rotation;
		obj.SetActive(true);
		/* if (isTile)
		{
			obj.transform.GetChild(0).gameObject.SetActive(true);
			obj.transform.GetChild(1).gameObject.SetActive(false);

			gemActive=Random.Range(0,10);

			if (gemActive==1)
			{
				starIndex=Random.Range(0,starPosY.Length-1);
				obj.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
				obj.transform.GetChild(0).GetChild(0).transform.localPosition=new Vector2(starPosX,starPosY[starIndex]);
			}
			else
			{
				obj.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
			}

			isTile=!isTile;
		}
		else
		{
			
			obj.transform.GetChild(0).gameObject.SetActive(false);
			obj.transform.GetChild(1).gameObject.SetActive(true);

			gemActive=Random.Range(0,10);
			if (gemActive==1)
			{
				starIndex=Random.Range(0,starPosY.Length-1);
				obj.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
				obj.transform.GetChild(1).GetChild(0).transform.localPosition=new Vector2(starPosX,-starPosY[starIndex]);
			}
			else
			{
				obj.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
			}
			
			
			isTile=!isTile;
		} */
		if (Manager.mscore<100)
		{
			tilePosYIndex=Random.Range(0,tilePosY.Length-1);
			distanceX=6f;
		}
		else if (Manager.mscore>=100&&Manager.mscore<500)
		{
			tilePosYIndex=Random.Range(0,tilePosY.Length-1);
			distanceX=4f;
		}
		else if (Manager.mscore>=500)
		{
			tilePosYIndex=Random.Range(0,tilePosY.Length-1);
			distanceX=2f;
		}
		
		transform.position=new Vector2(transform.position.x+distanceX,tilePosY[tilePosYIndex]);
	}
}
