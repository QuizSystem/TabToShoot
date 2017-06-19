using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleJSON;

public class IronSourceAdsManager : MonoBehaviour {

	IEnumerator Start()
	{
		string url = "http://oceanspin.cf/app/getnetwork/?network_alias=com_tabtoshoot_sonic";
		WWW www = new WWW(url);
		yield return www;
		string result = www.text;
		var json = JSON.Parse(result);
		string application_key = json["application_key"];
		//print ("json " + result);
		//print ("application_key " + application_key);

		if (string.IsNullOrEmpty (application_key)) {
			string appKeyDefault = "4859b10d";
			initSDKIronSource (appKeyDefault);
		} else {
			initSDKIronSource (application_key);
		}
	}
		
	void initSDKIronSource (string appKey) {
		string uniqueUserId = SystemInfo.deviceUniqueIdentifier;//"demoUserUnity";
		//string appKey = "4859b10d";
		IronSource.Agent.setUserId (uniqueUserId);
		IronSource.Agent.init (appKey);
	}

	void Update () {
	
	}

	public void onClickNew() {
		//print("Click New");
		ShowOfferwallButtonClicked ();
	}

	void OnEnable() {
		// Add Offerwall Events
		IronSourceEvents.onOfferwallClosedEvent += OfferwallClosedEvent;
		IronSourceEvents.onOfferwallOpenedEvent += OfferwallOpenedEvent;
		IronSourceEvents.onOfferwallShowFailedEvent += OfferwallShowFailedEvent;
		IronSourceEvents.onOfferwallAdCreditedEvent += OfferwallAdCreditedEvent;
		IronSourceEvents.onGetOfferwallCreditsFailedEvent += GetOfferwallCreditsFailedEvent;
		IronSourceEvents.onOfferwallAvailableEvent += OfferwallAvailableEvent;
	}

	void OnDisable() {
		IronSourceEvents.onOfferwallClosedEvent -= OfferwallClosedEvent;
		IronSourceEvents.onOfferwallOpenedEvent -= OfferwallOpenedEvent;
		IronSourceEvents.onOfferwallShowFailedEvent -= OfferwallShowFailedEvent;
		IronSourceEvents.onOfferwallAdCreditedEvent -= OfferwallAdCreditedEvent;
		IronSourceEvents.onGetOfferwallCreditsFailedEvent -= GetOfferwallCreditsFailedEvent;
		IronSourceEvents.onOfferwallAvailableEvent -= OfferwallAvailableEvent;
	}

	public void ShowOfferwallButtonClicked () {
		if (IronSource.Agent.isOfferwallAvailable ()) {
			IronSource.Agent.showOfferwall ();
		} else {
			Debug.Log ("IronSource.Agent.isOfferwallAvailable - False");
		}
	}

	void OfferwallOpenedEvent () {
		Debug.Log ("I got OfferwallOpenedEvent");
	}

	void OfferwallClosedEvent () {
		Debug.Log ("I got OfferwallClosedEvent");
	}

	void OfferwallShowFailedEvent (IronSourceError error) {
		Debug.Log ("I got OfferwallShowFailedEvent, code :  " + error.getCode () + ", description : " + error.getDescription ());
	}

	void OfferwallAdCreditedEvent (Dictionary<string, object> dict) {
		Debug.Log ("I got OfferwallAdCreditedEvent, current credits = " + dict ["credits"] + " totalCredits = " + dict ["totalCredits"]);
	}

	void GetOfferwallCreditsFailedEvent (IronSourceError error) {
		Debug.Log ("I got GetOfferwallCreditsFailedEvent, code :  " + error.getCode () + ", description : " + error.getDescription ());
	}

	void OfferwallAvailableEvent (bool canShowOfferwal) {
		Debug.Log ("I got OfferwallAvailableEvent, value = " + canShowOfferwal);
		if (canShowOfferwal) {
		} else {
		}
	}

}
