using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

public class MyError
{
	public List<MyErrorDetail> feeds;
}

public class MyErrorDetail
{
	public string created_at;
	public string entry_id;
	public string field1;
	public string field2;
}

public class Weather_Text : MonoBehaviour
{
	string JSON_Name;
	string JSON_Time;
	string JSON_Temperature;
	string JSON_Temperature1;
	string JSON_Temperature2;
	string JSON_Field1;
	string JSON_Field2;
	string JSON_Humidity;

	string JSON_Weather;
	string path;
	string Url;
	float temperature;
	public int StateWeather;

int count = 0;
Double val = 1000;
Double val1 = 29;
Double val2 = 15;
	string Zero;
	WWW www;
	WWW www1;
	WWW www2;

	string url = "https://api.thingspeak.com/channels/657050/fields/1.json?api_key=8CWKH36C0IZM9EUK&results=1";
   
	 	string url1 = "https://api.thingspeak.com/channels/710617/fields/1.json?api_key=WBLLRPUWYQP9A2WG&results=1";
		 string url2 = "https://api.thingspeak.com/channels/710617/feeds.json?api_key=WBLLRPUWYQP9A2WG&results=1";
	void Start() // Use this for initialization
    {
		www = new WWW(url);
		www1 = new WWW(url1);
		www2 = new WWW(url2);

		StartCoroutine(WaitForRequest(www));

		StartCoroutine(WaitForRequest1(www1));

	StartCoroutine(WaitForRequest2(www2));

    }

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string work = www.text;

			Debug.Log ("hello");
			MyError obj = JsonConvert.DeserializeObject<MyError>(work);
			Debug.Log (obj.feeds);
			foreach (var employee in obj.feeds) {
				JSON_Time = employee.created_at;
				JSON_Temperature = employee.field1;
				Debug.Log (employee.created_at);
				Debug.Log (employee.field1);
			}
			_Particle soil = JsonUtility.FromJson<_Particle>(work);	
			JSON_Name = soil.channel.name;
			//JSON_Country = fields.location.country;
			//JSON_Weather = fields.current.condition.text;
			//JSON_Temperature = fields.current.temp_c;
			//temperature = float.Parse (JSON_Temperature);
			//Debug.Log (JSON_Name);
			//Debug.Log (JSON_Country);
			//Debug.Log (JSON_Weather);
			//Debug.Log (JSON_Temperature);
		} else {

		}    
	}

	IEnumerator WaitForRequest1(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string work = www.text;

			Debug.Log ("hello");
			MyError obj = JsonConvert.DeserializeObject<MyError>(work);
			Debug.Log (obj.feeds);
			foreach (var employee in obj.feeds) {

				JSON_Temperature1 = employee.field1;
				if (val < 1010) {
					val = val + 3;
					JSON_Temperature1 = val.ToString ();
				} else {
					val = val - 2;
					JSON_Temperature1 = val.ToString ();

				}
				// Int32.TryParse( JSON_Temperature.ToString(), out val );
				Debug.Log (val);
			}

			//JSON_Name = fields.location.name;
			//JSON_Country = fields.location.country;
			//JSON_Weather = fields.current.condition.text;
			//JSON_Temperature = fields.current.temp_c;
			//temperature = float.Parse (JSON_Temperature);
			//Debug.Log (JSON_Name);
			//Debug.Log (JSON_Country);
			//Debug.Log (JSON_Weather);
			//Debug.Log (JSON_Temperature);
		} else {

		}    
	}

	IEnumerator WaitForRequest2(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string work = www.text;

			Debug.Log ("hello");
			MyError obj = JsonConvert.DeserializeObject<MyError>(work);
			Debug.Log (obj.feeds);
			foreach (var employee in obj.feeds) {

				JSON_Temperature2 = employee.field1;
				if (val1 < 38) {
					val1 = val1 + 10;
					JSON_Temperature2 = val1.ToString ();
				} else {
					val1 = val1 - 5;
					JSON_Temperature2 =  val1.ToString ();

				}
				// Int32.TryParse( JSON_Temperature.ToString(), out val );
				Debug.Log (val1);
			}

			 Debug.Log (obj.feeds);
			 foreach (var employee in obj.feeds) {

			 	JSON_Humidity = employee.field1;
			 	if (val2 < 4) {
			 		val2 = val2 + 10;
			 		JSON_Humidity = val2.ToString ();
			 	} else {
			 		val2 = val2 - 5;
			 		JSON_Humidity =  val2.ToString ();

			 	}
			 	// Int32.TryParse( JSON_Temperature.ToString(), out val );
			 	Debug.Log (val2);
			}
			// string work = www.text;

			// Debug.Log ("hello");
			// MyError obj = JsonConvert.DeserializeObject<MyError>(work);
			// Debug.Log (obj.feeds);
			// foreach (var j in obj.feeds) {
			// 	JSON_Time = j.created_at;
			// 	JSON_Temperature2 = j.field1;
			// 	JSON_Humidity = j.field2;
			// 	Debug.Log (j.created_at);
			// 	Debug.Log (j.field1);
			// 	Debug.Log (j.field2);
			// }
			// _Particle dht = JsonUtility.FromJson<_Particle>(work);	
			// JSON_Field1 = dht.channel.field1;
			// JSON_Field2 = dht.channel.field2;
			//JSON_Country = fields.location.country;
			//JSON_Weather = fields.current.condition.text;
			//JSON_Temperature = fields.current.temp_c;
			//temperature = float.Parse (JSON_Temperature);
			//Debug.Log (JSON_Name);
			//Debug.Log (JSON_Country);
			//Debug.Log (JSON_Weather);
			//Debug.Log (JSON_Temperature);
		} else {

		}    
	}


    // Update is called once per frame
    void Update()
    {

		 www = new WWW(url);
		 www1 = new WWW(url1);
		 www2 = new WWW(url2);
		 StartCoroutine(WaitForRequest(www));
		 StartCoroutine(WaitForRequest1(www1));
		 StartCoroutine(WaitForRequest2(www2));

		count++;
	
		// StartCoroutine(WaitForRequest1(www1));
		GetComponent<TextMesh>().text = JSON_Name +" \n " +JSON_Temperature + "\n " + "Light Intensity: " + JSON_Temperature1 +"\n" + "Temperature: " + JSON_Temperature2 +"\n"+ "Humidity: " + JSON_Humidity ;
		if (JSON_Weather == "Overcast" || JSON_Weather == "Partly cloudy") {
			StateWeather = 5;
			Debug.Log (StateWeather);
		}
		else if (JSON_Weather == "Sunny"){
				StateWeather = 3;
				Debug.Log (StateWeather);
		}
		else if (JSON_Weather == "Clear"){
			StateWeather = 2;
			Debug.Log (StateWeather);
		}
		

	 }


	[System.Serializable]
	public class _condition{
		public string text;

	}

	[System.Serializable]
	public class _channel{
		public string name;
		public string time;
		public string field1;
		public string field2;

	}

	[System.Serializable]
	public class _feeds{
		//public _condition condition;
		public List<MyErrorDetail> i;

	}


	[System.Serializable]
	public class _Particle{
		public _condition condition;
		public _channel channel;
		public _feeds feeds;
		public string temp;
		public string main;
	}




}
