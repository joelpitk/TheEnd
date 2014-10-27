using UnityEngine;
using System.Collections;

public class LightFixture : MonoBehaviour, IGameEventListener {
	public bool LightBulbsOn {
		get; set;
	}

	public Light[] lightBulbs;

	// Use this for initialization
	void Start () {
		GameEventManager.RegisterListener(this);

		if(lightBulbs[0].enabled) {
			LightBulbsOn = true;
		}
	}
	public void Toggle() {
		if(LightBulbsOn) {
			SwitchOff();
		}
		else {
			SwitchOn();
		}
	}

	private void SwitchOn() {
		if(WorldStatus.Electricity) {
			LightBulbsOn = true;
			foreach(Light l in lightBulbs) {
				l.enabled = true;
			}
		}
	}

	private void SwitchOff() {
		LightBulbsOn = false;
		foreach(Light l in lightBulbs) {
			l.enabled = false;
		}
	}

	public void ReceiveEvent(GameEvent e) {
		if(e.Name.Equals("PowerOutage")) {
			SwitchOff();
		}
	}
}
