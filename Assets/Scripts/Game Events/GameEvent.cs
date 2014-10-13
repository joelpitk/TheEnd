using UnityEngine;
using System.Collections;

public class GameEvent
{
	public string Name {
		get; set;
	}
	public int TimeToExecute {
		get; set;
	}

	public GameEvent(string n, int time) {
		Name = n;
		TimeToExecute = time;
	}
}

