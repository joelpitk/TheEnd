using UnityEngine;
using System.Collections;

public class PhoneDialInteraction : Interaction {
	public string numberOrCharacterOnButton;
	public AudioClip soundOnPress;

	PhoneInteraction phone;

	// Use this for initialization
	void Start () {
		phone = transform.parent.gameObject.GetComponent<PhoneInteraction>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate (GameObject player, GameObject itemInHand) {
		phone.AddNumber(numberOrCharacterOnButton);
		phone.audio.Play();
	}
}
