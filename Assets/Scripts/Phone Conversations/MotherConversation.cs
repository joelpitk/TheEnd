using UnityEngine;
using System.Collections;

public class MotherConversation : IConversation {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetResponse() {
		int time = WorldClock.Hour;
		if(time > 12) {
			return "Hello this is mom";
		}
		else {
			return "Hey I was asleep! :(";
		}

	}
}
