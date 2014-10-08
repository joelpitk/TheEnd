using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneInteraction : Interaction {
	public PhoneReceiverChecker checker;

	private string numberBeingDialled;
	private Dictionary<string, IConversation> phonebook;

	private bool receiverUp;
	private float dialTimer;

	// Use this for initialization
	void Start () {
		numberBeingDialled = "";

		receiverUp = false;
		dialTimer = 0f;

		// Great testing stuff mmmm
		phonebook = new Dictionary<string, IConversation>();
		phonebook.Add("5551234", new MotherConversation());
	}

	void Update () {
		if(!checker.ReceiverOnPlace && !receiverUp) {
			ReceiverLifted();
		}
		if(checker.ReceiverOnPlace && receiverUp) {
			ReceiverReturned();
		}

		// If the receiver is down or player has not pressed any buttons yet, do nothing.
		if(receiverUp && numberBeingDialled.Length > 0) {
			dialTimer += Time.deltaTime;
			// If a button has not been pressed in a while, let's dial!
			if(dialTimer >= 3f) {
				Dial();
			}
		}
	}

	void ReceiverLifted() {
		receiverUp = true;
	}

	void ReceiverReturned() {
		receiverUp = false;
	}

	private void Dial() {
		IConversation response;
		if(phonebook.TryGetValue(numberBeingDialled, out response)) {
			Debug.Log(response.GetResponse());
		}
		else {
			Debug.Log("The number you have tried to reach does not exist. Please try again.");
		}

		numberBeingDialled = "";
	}

	public override void Activate (GameObject player, GameObject itemInHand)
	{

	}

	public void AddNumber(string n) {
		Debug.Log("Pressed button " + n);
		if(receiverUp) {
			dialTimer = 0f;
			numberBeingDialled += n;
			// Max length of a number is seven numbers. Let's dial!
			if(numberBeingDialled.Length == 7) {
				Dial();
			}
		}
	}
}
