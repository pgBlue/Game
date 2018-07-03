using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	public static Manager instance;
	public GameObject pnStart,pnPlay,pnOver;
	public GameObject medalBronze,medalSliver,medalGold;
	public GameObject imgNew,pn;
	public Text tscore,thigh,txtscore;
	public static int mscore;
	public int deadCount;
	private bool isPlaying;
	private float timer=1.5f;
	void Awake(){
		instance=this;
	}
	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
		PlayerPrefs.GetInt("HighScore");
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlaying)
		{
			if (!PlaneController.instance.isDead)
			{
				txtscore.text=""+mscore.ToString();
			}
			else 
			{
				timer-=Time.deltaTime;
				if (deadCount>=5&&timer<0)
				{
					if (mscore<50)
					{
						Ads.instance.ShowVideo();
					}
					else
					{
						Ads.instance.ShowRewardVideo();
					}
				}
				else
				{
					if(timer<=0)
					{
						GameOver();
					}	
				}		
			}
		}
	}
	#region panel
		public void StartGame()
		{
			pnStart.SetActive(true);
			pnPlay.SetActive(false);
			pnOver.SetActive(false);

			isPlaying=false;
			PlaneController.instance.isDead=true;
		}
		public void PlayGame()
		{
			pnStart.SetActive(false);
			pnPlay.SetActive(true);
			pnOver.SetActive(false);

			isPlaying=true;
			PlaneController.instance.isDead=false;
			mscore=0;
		}
	#endregion

	public void GameOver()
	{
		pnStart.SetActive(false);
		pnPlay.SetActive(false);
		pnOver.SetActive(true);
		if (mscore>PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore",mscore);
			imgNew.SetActive(true);
		}
		else if (mscore<PlayerPrefs.GetInt("HighScore"))
		{
			imgNew.SetActive(false);
		}
		tscore.text=""+mscore.ToString();
		thigh.text=""+PlayerPrefs.GetInt("HighScore").ToString();
		//show medal
		if (mscore<50)
		{
			medalBronze.SetActive(true);
			medalSliver.SetActive(false);
			medalGold.SetActive(false);
		}
		else if(mscore>=50&&mscore<500)
		{
			medalBronze.SetActive(false);
			medalSliver.SetActive(true);
			medalGold.SetActive(false);
		}
		else
		{
			medalBronze.SetActive(false);
			medalSliver.SetActive(false);
			medalGold.SetActive(true);
		}
	}
	public void BtnRetry()
	{
		//plane
		PlaneController.instance.transform.position=PlaneController.instance.startPos;
		PlaneController.instance.transform.rotation=Quaternion.Euler(0,0,0);
		PlaneController.instance.stateAnimIndex=Random.Range(0,3);
		PlaneController.instance.myAnim.SetInteger("State",PlaneController.instance.stateAnimIndex);
		PlaneController.instance.transform.GetChild(0).gameObject.SetActive(true);

		//Createtile
		CreateBG.instance.transform.position=CreateBG.instance.startPos;
		GameObject[] objTiles=GameObject.FindGameObjectsWithTag("clearTile");
		foreach (var tile in objTiles)
		{
			tile.SetActive(false);
			/* tile.transform.GetChild(0).gameObject.SetActive(false);
			tile.transform.GetChild(1).gameObject.SetActive(false); */
		}
		CreateTile.instance.transform.position=CreateTile.instance.startPos;
		//createbg
		GameObject[] objBGs=GameObject.FindGameObjectsWithTag("clearBG");
		foreach (var bg in objBGs)
		{
			bg.SetActive(false);
		}
		//disable all object
		
		StartGame();
		pn.SetActive(false);
		timer=1.5f;
		//deadCount++;
	}
}
