using UnityEngine;
using System.Collections;

public class RecordPlayerInteraction : Interaction, IGameEventListener {
	public Amplifier amplifier;
	public Transform recordPlayingSpot;

	private AudioRecord currentRecord;
	private bool playingRecord;

	// Use this for initialization
	void Start () {
		playingRecord = false;

		GameEventManager.RegisterListener(this);
	}

	void FixedUpdate () {
		if(playingRecord) {
			// Check if the record has been removed
			Ray ray = new Ray(transform.position, transform.up);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 1f)) {
				AudioRecord a = hit.collider.gameObject.GetComponent<AudioRecord>();
				if(a == null) {
					RemoveRecord();
				}
				else {
					// TODO: There's a record and we are playing it, make it spin!
				}
			}
			else {
				RemoveRecord();
			}
		}
	}

	public override void Activate (GameObject player, GameObject itemInHand)
	{
		if(!WorldStatus.Electricity) {
			return;
		}

		if(itemInHand != null) {
			AudioRecord a = itemInHand.GetComponent<AudioRecord>();
			if(a != null) {
				player.GetComponent<InteractionControls>().HandleDrop();
				PlaceRecord(a);
				return;
			}
			else {
				TogglePlaying();
			}
		}
		else {
			TogglePlaying();
		}
	}

	private void PlaceRecord(AudioRecord a) {
		currentRecord = a;
		a.transform.position = recordPlayingSpot.position;
	}

	private void RemoveRecord() {
		currentRecord = null;
		StopPlaying();
	}

	private void TogglePlaying() {
		if(playingRecord) {
			StopPlaying();
		}
		else {
			StartPlaying();
		}
	}

	private void StopPlaying() {
		playingRecord = false;
		amplifier.StopPlaying();
	}

	private void StartPlaying() {
		if(currentRecord != null) {
			playingRecord = true;
			amplifier.StartPlaying(currentRecord.song);
		}
	}

	public void ReceiveEvent(GameEvent e) {
		if(e.Name.Equals("PowerOutage")) {
			StopPlaying();
		}
	}
}
