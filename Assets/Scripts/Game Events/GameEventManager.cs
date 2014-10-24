using UnityEngine;
using System.Collections.Generic;

public class GameEventManager : MonoBehaviour {
	private static List<GameEvent> events;
	private static List<IGameEventListener> listeners;

	// Use this for initialization
	void Awake() {
		events = new List<GameEvent>();
		listeners = new List<IGameEventListener>();

		System.Random r = new System.Random();

		// A power outage happens some time after the first day
		//events.Add(new GameEvent("PowerOutage", r.Next(11, 12)));
		// Water gets cut some time after the second day
		events.Add (new GameEvent("WaterCut", r.Next(60*24*2, 60*24*5)));
	}

	void Update () {
		int time = WorldClock.ElapsedMinutes;
		// Loop though events that have not been resolved. Execute and remove all that are due
		// This is stupidly inefficient I guess, but there's not gonna be that many events anyway so whatevs!
		for(int i = events.Count-1; i >= 0; i--) {
			GameEvent e = events[i];
			if(e.TimeToExecute <= time) {
				foreach(IGameEventListener l in listeners) {
					l.ReceiveEvent(e);
				}
				events.RemoveAt(i);
			}
		}
	}

	public static void AddEvent(GameEvent e) {
		events.Add(e);
	}

	public static void RegisterListener(IGameEventListener listener) {
		listeners.Add (listener);
	}
}
