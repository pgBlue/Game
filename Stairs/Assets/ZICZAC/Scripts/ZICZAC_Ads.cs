using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class ZICZAC_Ads : MonoBehaviour {
	public static ZICZAC_Ads instance;
	/* #if UNITY_ADS
		public string appID;
		public bool enableTestMode=true;
	#endif */
	private BannerView bannerView;
	
	void Awake()
	{
		instance=this;
	}
	// Use this for initialization
	void Start () {
		/* #if UNITY_ANDROID
		string appID="ca-app-pub-9259778474335943~4108951425";
		#endif
		//initialize the google moble ads
		MobileAds.Initialize(appID); */
		RequestBanner();
	}
	private void RequestBanner()
	{
		
		string adUnitID="ca-app-pub-9259778474335943/4344619091";
		bannerView=new BannerView(adUnitID,AdSize.Banner,AdPosition.Top);
		AdRequest request=new AdRequest.Builder().Build();
		bannerView.LoadAd(request);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ShowRewardVideo()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var option=new ShowOptions{resultCallback=HandleShowResult};
			Advertisement.Show("rewardedVideo",option);
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
	void HandleShowResult(ShowResult result)
	{
		
		switch (result)
		{
			case ShowResult.Finished:
				ZICZAC_Ball.instance.deadCount=0;
				ZICZAC_Manger.instance.GameOver();
			break;
			case ShowResult.Skipped:
				ZICZAC_Ball.instance.deadCount=0;
				ZICZAC_Manger.instance.GameOver();
			break;
		}
	}
}
