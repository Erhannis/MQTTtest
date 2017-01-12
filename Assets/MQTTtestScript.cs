using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

public class MQTTtestScript : MonoBehaviour {

	private MqttClient4Unity client;

	// Use this for initialization
	void Start () {
		client = new MqttClient4Unity("192.168.0.6", 1883, false, null);
		client.Connect("Unity");
		client.MqttMsgPublished += new MqttClient.MqttMsgPublishedEventHandler(OnMessage);
		client.Subscribe("color_value");
	}

	private void OnMessage(object sender, MqttMsgPublishedEventArgs e) 
	{
		Debug.Log("This is called when the event fires. " + e.ToString());
	}

	void OnDestroy() {
		client.Disconnect ();
	}

	private int i;

	// Update is called once per frame
	void Update () {
		client.Publish("color_value", Encoding.ASCII.GetBytes("count " + i));
		i++;
	}
}
