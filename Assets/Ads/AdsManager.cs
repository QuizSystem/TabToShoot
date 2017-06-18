using UnityEngine;
using System.Collections;
using FyberPlugin;

public class AdsManager : MonoBehaviour {

	private Ad ofwAd;

	void Start () {
		string appId = "101928";
		string securityToken = "432cf403d42cc9f3e169110c1380025f";
		Fyber.With(appId).WithSecurityToken(securityToken).Start();
		OfferWallRequester.Create().Request();
	}

	void Update () {
	
	}

	public void onClickGoHome() {
		//print("Click Go Home");
		OfferWallRequester.Create().Request();
		ShowOfferWall ();
	}

	public void onClickPause() {
		//print("Click Pause");
		OfferWallRequester.Create().Request();
		ShowOfferWall ();
	}

	private void ShowOfferWall() {
		if (ofwAd != null) {
			ofwAd.Start();
			ofwAd = null;
		}
	}

	void OnEnable() {
		FyberCallback.AdAvailable += OnAdAvailable;
		FyberCallback.AdNotAvailable += OnAdNotAvailable;   
		FyberCallback.RequestFail += OnRequestFail; 
		FyberCallback.AdStarted += OnAdStarted;
		FyberCallback.AdFinished += OnAdFinished;
	}

	void OnDisable() {
		FyberCallback.AdAvailable -= OnAdAvailable;
		FyberCallback.AdNotAvailable -= OnAdNotAvailable;   
		FyberCallback.RequestFail -= OnRequestFail; 
		FyberCallback.AdStarted -= OnAdStarted;
		FyberCallback.AdFinished -= OnAdFinished;  
	}

	private void OnAdAvailable(Ad ad) {
		// store ad response
		if (ad.AdFormat == AdFormat.OFFER_WALL)
			ofwAd = ad;
	}

	private void OnAdNotAvailable(AdFormat adFormat) {
		// discard previous stored response
		if (adFormat == AdFormat.OFFER_WALL)
			ofwAd = null;
	}

	private void OnRequestFail(RequestError error)
	{
		// process error
		Debug.Log("OnRequestError: " + error.Description);
	}

	private void OnAdStarted(Ad ad) {
		if (ad.AdFormat == AdFormat.OFFER_WALL) {
			// this is where you mute the sound and toggle buttons if necessary
			ofwAd = null;
		}
	}

	private void OnAdFinished(AdResult result) {
		if (result.AdFormat == AdFormat.OFFER_WALL) {
			Debug.Log("Ofw closed with result: " + result.Status +
				" and message: " + result.Message);
		}
		OfferWallRequester.Create().Request();
	}

}
