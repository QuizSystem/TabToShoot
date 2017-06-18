using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IronSourceAdsManager : MonoBehaviour {

	public static string uniqueUserId = "demoUserUnity";
	public static string appKey = "38760d6d" ;
	
	void Start () {
		//string appKey = "4859b10d";
		IronSource.Agent.setUserId ("uniqueUserId");
		IronSource.Agent.init (appKey);
	}

	void Update () {
	
	}

	public void onClickNew() {
		print("Click New");
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
