using UnityEngine;
using System.Collections;

public class getDayTime : MonoBehaviour {
	
	// Use this for initialization
	void Awake () {
		if (System.DateTime.Now.Month == 10) {
			print ("thang 8");
			if (System.DateTime.Now.Day < 32)
				this.gameObject.SetActive (false);
		} 
	}
	
	// Update is called once per frame
	void Update () {

	}
}
