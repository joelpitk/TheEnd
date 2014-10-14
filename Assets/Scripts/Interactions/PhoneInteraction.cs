﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneInteraction : Interaction, IGameEventListener {
	public PhoneReceiverChecker checker;
	public GameObject receiver;

	private string numberBeingDialled;
	private Dictionary<string, IConversation> phonebook;

	private bool receiverUp;
	private float dialTimer;

	private bool lineOpen;
	private IConversation currentConversation;
	private InvalidNumberConversation invalidNumber;

	// Use this for initialization
	void Start () {
		numberBeingDialled = "";

		receiverUp = false;
		dialTimer = 0f;

		// Great testing stuff mmmm
		phonebook = new Dictionary<string, IConversation>();
		phonebook.Add("5551234", new MotherConversation());

		invalidNumber = new InvalidNumberConversation();

		GameEventManager.RegisterListener(this);
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

		if(lineOpen) {
			string toShow = currentConversation.NameOfTalker + ": " + currentConversation.GetResponse();
			SubtitleManager.ShowTelephoneSubtitle(toShow, receiver.transform);
			if(currentConversation.ConversationDone) {
				CloseLine();
			}
		}
	}

	void ReceiverLifted() {
		receiverUp = true;
	}

	void ReceiverReturned() {
		receiverUp = false;
		CloseLine();
	}

	private void CloseLine() {
		currentConversation = null;
		lineOpen = false;
		SubtitleManager.StopTelephoneSubtitle();
	}

	private void OpenLine(IConversation c) {
		currentConversation = c;
		c.OpenLine();
		lineOpen = true;
	}

	private void Dial() {
		IConversation response;
		if(phonebook.TryGetValue(numberBeingDialled, out response)) {
			OpenLine(response);
		}
		else {
			OpenLine(invalidNumber);
		}

		numberBeingDialled = "";
	}

	public override void Activate (GameObject player, GameObject itemInHand)
	{
		if(lineOpen) {
			CloseLine();
		}
	}

	public void AddNumber(string n) {
		if(receiverUp && WorldStatus.Electricity) {
			dialTimer = 0f;
			numberBeingDialled += n;
			// Max length of a number is seven numbers. Let's dial!
			if(numberBeingDialled.Length == 7) {
				Dial();
			}
		}
	}

	public void ReceiveEvent(GameEvent e) {
		// Close the line when the power cuts, if it's open
		if(e.Name.Equals("PowerOutage")) {
			CloseLine();
		}
	}
}
