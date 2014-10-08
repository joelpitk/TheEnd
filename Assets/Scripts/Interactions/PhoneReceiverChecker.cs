using UnityEngine;
using System.Collections;

public class PhoneReceiverChecker : MonoBehaviour {
	public bool ReceiverOnPlace {
		get; set;
	}

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		Ray ray = new Ray(transform.position, transform.up);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 0.06f)) {
			ReceiverOnPlace = true;
		}
		else {
			ReceiverOnPlace = false;
		}
	}
}
