using UnityEngine;
using System.Collections;

public class SaloraInteraction : Interaction, IGameEventListener {
	public bool TVOn {
		get; set;
	}

	// Use this for initialization
	void Start () {
		GameEventManager.RegisterListener(this);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public override void Activate(GameObject player, GameObject itemInHand) {
		if(TVOn) {
			SwitchOff();
		}
		else if(WorldStatus.Electricity) {
			SwitchOn();
		}
	}

	public void SwitchOn() {
		TVOn = true;
		Debug.Log("TV is on, rejoice!");
	}

	public void SwitchOff() {
		TVOn = false;
		Debug.Log("TV is off, what a bummer!");
	}

	public void ReceiveEvent(GameEvent e) {
		if(e.Name.Equals("PowerOutage")) {
			SwitchOff();
		}
	}
}
