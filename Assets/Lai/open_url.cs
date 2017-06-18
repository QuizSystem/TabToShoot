using UnityEngine;
using System.Collections;

public class open_url : MonoBehaviour {
	public string uri;
	// Use this for initialization
	public void openlink(){
		
		Application.OpenURL (uri);
		//Appodeal.show(Appodeal.INTERSTITIAL);
	}
}
