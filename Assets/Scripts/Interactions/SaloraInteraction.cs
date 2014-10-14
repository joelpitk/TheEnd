using UnityEngine;
using System.Collections;

public class SaloraInteraction : Interaction, IGameEventListener {
	public bool TVOn {
		get; set;
	}

	private float volume;
	private TVChannel currentChannel;

	public void VolumeDown() {
		volume -= 0.1f;
		if(volume < 0f)
			volume = 0f;
	}
	public void VolumeUp() {
		volume += 0.1f;
		if(volume > 1f)
			volume = 1f;
	}

	// Use this for initialization
	void Start () {
		GameEventManager.RegisterListener(this);

		volume = 1f;
		currentChannel = new TVChannel();
	}
	
	// Update is called once per frame
	void Update () {
		if(TVOn) {
			SubtitleManager.ShowTelevisionSubtitle(currentChannel.CurrentProgram.Text, gameObject.transform, volume);
		}
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
	}

	public void SwitchOff() {
		TVOn = false;
		SubtitleManager.StopTelevisionSubtitle();
	}

	public void ReceiveEvent(GameEvent e) {
		if(e.Name.Equals("PowerOutage")) {
			SwitchOff();
		}
	}
}
