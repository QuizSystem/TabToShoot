using UnityEngine;
using System.Collections;
using SimpleJSON;
public class LLogin : MonoBehaviour {

	IEnumerator Start(){

		WWWForm form = new WWWForm();

		//AndroidJavaObject TM = new AndroidJavaObject("android.telephony.TelephonyManager");
		//string IMEI = TM.Call<string>("getDeviceId");
		//imel.text = IMEI;

		string IDD = SystemInfo.deviceUniqueIdentifier;
		string IMELid=SystemInfo.deviceModel;
		//iddevice.text = IDD;

		form.AddField( "tag", "login" );
		form.AddField( "IMEIId", IMELid);
		form.AddField( "androidId", IDD );
		//Hashtable headers = form.headers;
		//byte[] rawData = form.data;
		string url = "http://gtwoco.ga/default/app/login/";

		// Add a custom header to the request.
		// In this case a basic authentication to access a password protected resource.
		//headers["Authorization"] = "Basic " + System.Convert.ToBase64String(
		//System.Text.Encoding.ASCII.GetBytes("username:password"));

		// Post a request to an URL with our custom headers
		WWW www = new WWW(url, form);
		yield return www;

		string result = www.text;
		var N = JSON.Parse(result);
		Debug.Log ("lai xxx:  "+N.ToString());
		//txresult.text = N.ToString();
		string val1 = N["status"];
				//Debug.Log ("lai xxxx"+N.ToString());
		if (val1 == "true") {
			
			string valId = N ["id"];
			Debug.Log ("login seccess!-uid saveer=: " + valId.ToString ());
			PlayerPrefs.SetString ("uid", valId);
			PlayerPrefs.Save ();
		} else {
			string Id = Random.Range (1, 100000) + "";
			PlayerPrefs.SetString ("uid", Id);
			PlayerPrefs.Save ();
			Debug.Log ("login fail");
		}
			
	}
}
