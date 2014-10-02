using UnityEngine;
using System.Collections;

public class SaloraInteraction : Interaction {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public override void Activate(GameObject player, GameObject itemInHand) {
		Debug.Log("You touched a TV. Grats!");
	}
}
