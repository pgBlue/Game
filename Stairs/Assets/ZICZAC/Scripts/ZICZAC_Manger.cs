using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZICZAC_Manger : MonoBehaviour {
	public static ZICZAC_Manger instance;
	public GameObject pnStartGame,pnPlayGame,pnGameOver;
	public static int mScore;
	public Text tscore,txtScore,txtHigh;
	public bool isPlaying;
	void Awake()
	{
		instance=this;
	}
	// Use this for initialization
	void Start () {
		PlayerPrefs.GetInt("HighScore");
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlaying)
		{
			if (!ZICZAC_Ball.instance.isDead)
			{
				tscore.text=""+mScore.ToString();
				
			}
			else
			{
				if (mScore>PlayerPrefs.GetInt("HighScore"))
				{
					PlayerPrefs.SetInt("HighScore",mScore);
				}
				txtScore.text=""+mScore.ToString();
				txtHigh.text=""+PlayerPrefs.GetInt("HighScore").ToString();
				if (ZICZAC_Ball.instance.deadCount>=5)
				{
					if (mScore<500)
					{
						ZICZAC_Ads.instance.ShowVideo();
					}
					else
					{
						ZICZAC_Ads.instance.ShowRewardVideo();
					}
				}
				else
				{
					GameOver();
				}
			}
		}
	}
	void StartGame()
	{
		isPlaying=false;
		pnStartGame.SetActive(true);
		pnPlayGame.SetActive(false);
		pnGameOver.SetActive(false);
	}
	void PlayGame()
	{
		isPlaying=true;
		mScore=0;
		pnStartGame.SetActive(false);
		pnPlayGame.SetActive(true);
		pnGameOver.SetActive(false);
	}
	public void GameOver()
	{
		pnStartGame.SetActive(false);
		pnPlayGame.SetActive(false);
		pnGameOver.SetActive(true);
	}
	public void Play()
	{
		PlayGame();
		ZICZAC_Ball.instance.isDead=false;
		//ZICZAC_Ball.instance.myRig.isKinematic=false;
	}
	public void Retry()
	{
		//disable all clone cube
		GameObject[] objs=GameObject.FindGameObjectsWithTag("Cube");
		foreach (var obj in objs)
		{
			obj.SetActive(false);
			obj.transform.GetChild(0).gameObject.SetActive(false);
		}
		GameObject startCube=GameObject.FindGameObjectWithTag("Start");
		Destroy(startCube);
		//ball
		ZICZAC_Ball.instance.transform.position=ZICZAC_Ball.instance.startPos;
		ZICZAC_Ball.instance.speed=0;
		ZICZAC_Ball.instance.isDead=false;
		ZICZAC_Ball.instance.deadCount++;
		//createcube
		ZICZAC_CreateCube.instance.transform.position=ZICZAC_CreateCube.instance.startPos;
		ZICZAC_CreateCube.instance.cubeCount=0;
		ZICZAC_CreateCube.instance.gemCount=0;
		ZICZAC_CreateCube.instance.gemIndex=Random.Range(0,ZICZAC_CreateCube.instance.cubeColor.Length-1);
		//
		GameObject startObj=(GameObject)Instantiate(ZICZAC_CreateCube.instance.startCube);
		startObj.transform.position=new Vector3(0,0,0);
		startObj.transform.rotation=Quaternion.identity;
		startObj.GetComponent<MeshRenderer>().material.color=ZICZAC_CreateCube.instance.cubeColor[ZICZAC_CreateCube.instance.gemIndex];
		//
		PlayGame();
	}
}
