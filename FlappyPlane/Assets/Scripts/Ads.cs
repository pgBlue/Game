using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {
	public static Ads instance;
	void Awake()
	{
		instance=this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Skipped:
				Manager.instance.deadCount=0;
				Manager.instance.GameOver();
				break;
			case ShowResult.Finished:
				Manager.instance.deadCount=0;
				Manager.instance.GameOver();
				break;
		}
	}
	public void ShowVideo()
	{
		if (Advertisement.IsReady("video"))
		{
			var option=new ShowOptions{resultCallback=HandleShowResult};
			Advertisement.Show("video",option);
		}
	}
	public void ShowRewardVideo()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var option=new ShowOptions{resultCallback=HandleShowResult};
			Advertisement.Show("rewardedVideo",option);
		}
	}
}
