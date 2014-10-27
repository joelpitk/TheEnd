using UnityEngine;
using System.Collections;

public class EmergencyConversation : IConversation {
	private float startTime;

	public string NameOfTalker {
		get {
			return "Voice";
		}
	}
	public bool ConversationDone {
		get {
			return startTime + 5f < WorldClock.ElapsedRealSeconds;
		}
	}
	
	public string GetResponse() {
		return "We're sorry, but all our lines are busy right now. Please try again later.";
	}

	public bool OpenLine() {
		startTime = WorldClock.ElapsedRealSeconds;
		return true;
	}
}
