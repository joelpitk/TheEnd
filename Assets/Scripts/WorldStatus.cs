using UnityEngine;
using System.Collections;

public class WorldStatus : MonoBehaviour, IGameEventListener {
	public static bool Electricity {
		get; set;
	}

	public static bool Water {
		get; set;
	}
	
	void Start () {
		Electricity = true;
		Water = true;

		GameEventManager.RegisterListener(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReceiveEvent(GameEvent e) {
		if(e.Name.Equals("PowerOutage")) {
			Electricity = false;
		}
		else if(e.Name.Equals("WaterCut")) {
			Water = false;
		}
	}
}
