using UnityEngine;
using System.Collections;

public class PhoneInteraction : Interaction {
	private string numberBeingDialled;

	private bool receiverUp;
	private float dialTimer;

	// Use this for initialization
	void Start () {
		numberBeingDialled = "";

		receiverUp = false;
		dialTimer = 0f;
	}

	void Update () {
		// If the receiver is down or player has not pressed any buttons yet, do nothing.
		if(receiverUp && numberBeingDialled.Length > 0) {
			dialTimer += Time.deltaTime;
			// If a button has not been pressed in a while, let's dial!
			if(dialTimer >= 3f) {
				Dial();
			}
		}
	}

	private void Dial() {
		Debug.Log("Thank you for dialling number " + numberBeingDialled);
		numberBeingDialled = "";
	}

	public override void Activate (GameObject player, GameObject itemInHand)
	{
		if(receiverUp) {
			Debug.Log("Receiver down");
			receiverUp = false;
			// I guess play some sounds and make the receiver go back on the phone?
		}
		else {
			Debug.Log("Receiver up");
			receiverUp = true;
			// I guess play some sounds and make the receiver float in the air in front of player or something?
		}
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
