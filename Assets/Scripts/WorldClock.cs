using UnityEngine;
using System.Collections;

public class WorldClock : MonoBehaviour {
	private static float elapsedRealSeconds;
	public static float ElapsedRealSeconds {
		get {
			return elapsedRealSeconds;
		}
	}

	// Length of a game world minute in seconds
	public float minuteLength = 1f;
	private float minuteTimer = 0f;

	private static int hour = 12;
	private static int elapsedHours;
	private static int minute;
	private static int elapsedMinutes;

	public static int Hour {
		get {return hour;}
	}
	public static int ElapsedHours {
		get {return elapsedHours;}
	}
	public static int Minute {
		get {return minute;}
	}
	public static int ElapsedMinutes {
		get {return elapsedMinutes;}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedRealSeconds += Time.deltaTime;
		minuteTimer += Time.deltaTime;

		if(minuteTimer >= minuteLength) {
			minuteTimer = 0;
			minute++;
			elapsedMinutes++;
			if(minute == 60) {
				minute = 0;
				hour++;
				elapsedHours++;
				if(hour == 24) {
					hour = 0;
				}
			}
		}
	}
}
