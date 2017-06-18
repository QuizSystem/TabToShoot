using UnityEngine;
using System.Collections;

public class splabgame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (tolv1 ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator tolv1 (){
		yield return new WaitForSeconds (4f);
		Application.LoadLevel (1);
	}
}
