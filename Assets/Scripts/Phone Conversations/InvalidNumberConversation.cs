using UnityEngine;
using System.Collections;

public class InvalidNumberConversation : IConversation {
	public string NameOfTalker {
		get {
			return "Voice";
		}
	}

	// Elapsed real seconds when conversation started
	private float startTime;
	public bool ConversationDone {
		get {
			return startTime + 5f < WorldClock.ElapsedRealSeconds;
		}
	}

	public string GetResponse() {
		return "The number you have tried to reach does not exist. Please try again.";
	}

	public bool OpenLine() {
		startTime = WorldClock.ElapsedRealSeconds;
		return true;
	}
}
