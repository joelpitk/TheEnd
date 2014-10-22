using UnityEngine;
using System.Collections;

public class Amplifier : Interaction, IGameEventListener {
	public AudioSource[] speakers;

	private bool amplifierOn;
	private float volume;

	// Use this for initialization
	void Start () {
		amplifierOn = false;
		volume = 0.5f;
		foreach(AudioSource a in speakers) {
			a.volume = 0f;
		}

		GameEventManager.RegisterListener(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartPlaying(AudioClip song) {
		foreach(AudioSource a in speakers) {
			a.clip = song;
			a.Play();
		}
	}

	public void StopPlaying() {
		foreach(AudioSource a in speakers) {
			a.Stop();
		}
	}

	public void VolumeUp() {
		volume += 0.1f;
		if(volume > 1f) {
			volume = 1f;
		}
		foreach(AudioSource a in speakers) {
			a.volume = volume;
		}
	}

	public void VolumeDown() {
		volume -= 0.1f;
		if(volume < 0f) {
			volume = 0f;
		}
		foreach(AudioSource a in speakers) {
			a.volume = volume;
		}
	}

	public override void Activate (GameObject player, GameObject itemInHand)
	{
		if(!WorldStatus.Electricity) {
			return;
		}

		if(amplifierOn) {
			amplifierOn = false;
			// A record is playing but the amplifier was switched off
			foreach(AudioSource a in speakers) {
				a.volume = 0f;
			}
		}
		else {
			amplifierOn = true;
			// A record was already playing, bring the noize!
			foreach(AudioSource a in speakers) {
				a.volume = volume;
			}
		}
	}

	public void ReceiveEvent(GameEvent e) {
		if(e.Name.Equals("PowerOutage")) {
			StopPlaying();
		}
	}
}
