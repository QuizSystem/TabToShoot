using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class Submitref : MonoBehaviour {

		GameObject inbuttext;

		void Start ()
		{
				



		}
		public void okbutton(){

				inbuttext = GameObject.Find ("id_input");
				print ("inptbuttonxxx: " + inbuttext.GetComponent<Text>().text);
				StartCoroutine(sendata (inbuttext.GetComponent<Text>().text));

		}

		IEnumerator sendata(string idref){

		WWWForm form = new WWWForm();

		//AndroidJavaObject TM = new AndroidJavaObject("android.telephony.TelephonyManager");
		//string IMEI = TM.Call<string>("getDeviceId");
		//imel.text = IMEI;

		string IDD = SystemInfo.deviceUniqueIdentifier;
		string IMELid=SystemInfo.deviceModel;
		//iddevice.text = IDD;
				//print(lay)

				form.AddField("refId", idref);
				form.AddField("IMEIId", IMELid);
				form.AddField("deviceId", IDD );
		//Hashtable headers = form.headers;
		//byte[] rawData = form.data;
		//string url = "http://sportdarts.cf/default/app/submit-ref";
		string url = "http://gtwoco.ga/default/app/submit-ref";

		// Add a custom header to the request.
		// In this case a basic authentication to access a password protected resource.
		//headers["Authorization"] = "Basic " + System.Convert.ToBase64String(
		//System.Text.Encoding.ASCII.GetBytes("username:password"));

		// Post a request to an URL with our custom headers
		WWW www = new WWW(url, form);
		yield return www;

		string result = www.text;
		var N = JSON.Parse(result);
		//Debug.Log (N.ToString());
		//txresult.text = N.ToString();
		string val1 = N["status"];
		Debug.Log ("lai xxxx refffffffffffffff"+N.ToString());
				inbuttext.GetComponent<Text>().text=N.ToString();
				if (val1 == "true") {
			GameObject.Find ("Panelref").SetActive (false);
				} else
						GameObject.Find ("sms").GetComponent<Text> ().text =  N.ToString();
}


	public void canelfefffff(){

		this.gameObject.GetComponent<Animator>().SetTrigger("nook");
	}
	int i=0;
	public void okrefffff(){
		i++;
		if (i ==4) {
			this.gameObject.GetComponent<Animator>().SetTrigger("ok");
			i = 0;
		}


	}
}
