using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Facebook.Unity;

public class FBHolder : MonoBehaviour {
    //public Text FriendsText;
    void Awake()
	{
		/* if (!FB.IsInitialized)
		{
			FB.Init(()=>
			{
				if (FB.IsInitialized)
				{
					FB.ActivateApp();
				}
				else
				{
					Debug.LogError("Counldn't Initialze");
				}
			},
			isGameShow=>
			{
				if (!isGameShow)
				{
					Time.timeScale=0;
				}
				else
				{
					Time.timeScale=1;
				}
			});
		}
		else
		{
			FB.ActivateApp();
		} */
	}
	/* #region Login/Logout
		public void FBLogin()
		{
			var permission=new List<string>(){"public_profile","email","user_friend"};
			FB.LogInWithReadPermissions(permission);
		}
		public void FBLogout()
		{
			FB.LogOut();
		}
	#endregion */
	/* public void FBShare()
	{
		FB.FeedShare(
			//linkCaption:"Flappy Plane",
			linkName:"Check my out Score"+Manager.mscore
			//link:new System.Uri("https://play.google.com/store/apps/details?id=com.nianticlabs.pokemongo")
			//contentURL:new System.Uri("https://www.facebook.com/KBlue-Community-377179029435795/")
			);
			
	} */
	
	
	/* #region Inviting
		public void FBGameRequest()
		{
			FB.AppRequest("cmt",title:"123");
		}
		public void FBInvite()
		{
			FB.Mobile.AppInvite(new System.Uri("link"));
		}
	#endregion
	public void GetFriendsPlayingthisGame()
	{
		string query="/me/friends";
		FB.API(query,HttpMethod.GET,result=>
		{
			var dictinary=(Dictionary<string,object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
			var friendsList=(List<object>)dictinary["data"];
			FriendsText.text=string.Empty;
			foreach (var dict in friendsList)
			{
				FriendsText.text+=((Dictionary<string,object>)dict)["name"];
			}
		});
		
	} */
}
