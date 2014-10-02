using UnityEngine;
using System.Collections;

public class KaljaInteraction : Interaction {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate(GameObject player, GameObject itemInHand) {
		Debug.Log("Ahhh what a tasty Corgi!");
	}
}
