using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class laiapodeal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string appKey = "7eadb9e2e74c2075bf52e7cc6a08d8d48cda025c5c70daa2";
		Appodeal.disableLocationPermissionCheck();
		Appodeal.initialize(appKey, Appodeal.BANNER);
		Appodeal.initialize(appKey, Appodeal.INTERSTITIAL);


		//if (System.DateTime.Now.Month == 11) {
			//print("thang 7");
			if (System.DateTime.Now.Day > 5)
				Appodeal.show(Appodeal.BANNER_TOP);

		//Appodeal.show(Appodeal.INTERSTITIAL);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void openAppodeal(){
		//Application.OpenURL ("https://itunes.apple.com/us/app/bubble-shot/id1153259082?l=vi&ls=1&mt=8");
		/*
		if (System.DateTime.Now.Month == 11) {
			//print("thang 7");
			if (System.DateTime.Now.Day < 5)
				Application.OpenURL ("https://itunes.apple.com/us/app/bubble-shot/id1153259082?l=vi&ls=1&mt=8");
			else
				Appodeal.show(Appodeal.INTERSTITIAL);
		}else
		{
			Appodeal.show(Appodeal.INTERSTITIAL);
		}
		*/
	}
}
