using UnityEngine;
using System.Collections;

public class LightSwitchInteraction : Interaction {
	public Light[] connectedLights;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate (GameObject player, GameObject itemInHand)
	{
		foreach(Light l in connectedLights) {
			l.enabled = !l.enabled;
		}
	}
}
