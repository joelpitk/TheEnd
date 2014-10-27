using UnityEngine;
using System.Collections;

public class SaloraInteraction : Interaction, IGameEventListener {
	public Texture tvOffTexture;
	public Material screenMaterial;

	public bool TVOn {
		get; set;
	}

	private float volume;
	private TVChannel currentChannel;

	private TVProgram testcard;

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
		TVOn = false;

		testcard = TVProgramRepository.GetProgram("Testcard");
		SwitchOn();
	}
	
	// Update is called once per frame
	void Update () {
		if(TVOn) {
			TVProgram p = currentChannel.CurrentProgram;
			if(p != null) {
				SubtitleManager.ShowTelevisionSubtitle(currentChannel.CurrentProgram.CurrentText, gameObject.transform, volume);
				screenMaterial.mainTexture = currentChannel.CurrentProgram.CurrentImage;
			}
			else {
				SubtitleManager.StopTelevisionSubtitle();
				screenMaterial.mainTexture = testcard.CurrentImage;
			}
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
		screenMaterial.mainTexture = tvOffTexture;
	}

	public void ReceiveEvent(GameEvent e) {
		if(e.Name.Equals("PowerOutage")) {
			SwitchOff();
		}
	}
}
