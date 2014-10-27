using UnityEngine;
using System.Collections;

public class LoverConversation : IConversation {
	public string NameOfTalker {
		get {
			return "J";
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
		return "Please, I told you I need some time to think, you have to stop calling me. I'll call you in a few days, I promise.";
	}
	
	public bool OpenLine() {
		startTime = WorldClock.ElapsedRealSeconds;
		return true;
	}
}
