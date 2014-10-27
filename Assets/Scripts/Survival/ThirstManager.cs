using UnityEngine;
using System.Collections;

public class ThirstManager : MonoBehaviour {
	private float currentThirst;
	public float CurrentThirst {
		get { return currentThirst; }
	}

	private int minuteWhenLastDrunk;
	private int sipsDrunk;
	public int SipsDrunk {
		get { return sipsDrunk; }
	}

	private bool urinating;
	public bool Urinating {
		get { return urinating; }
	}

	// Use this for initialization
	public ThirstManager() {
		currentThirst = 1f;
		minuteWhenLastDrunk = -60;
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: figure out something great here. Currently it takes one hour after every sip for the thrist to start building up again
		if(WorldClock.ElapsedMinutes - minuteWhenLastDrunk > 60) {
			HandleThirstBuildup();
		}

		if(urinating) {
			UpdateUrination();
		}
	}

	private void HandleThirstBuildup() {
		// Todo: make thirst grow in relation to the world time
		currentThirst -= 0.01f * Time.deltaTime;
	}

	public void TakeSip() {
		sipsDrunk++;
		minuteWhenLastDrunk = WorldClock.ElapsedMinutes;
		currentThirst += 0.05f;
	}

	/*
	 * URINATION STUFF BELOW, DON'T LOOK IT'S NASTY
	 */

	// For an average male it takes 0.2 seconds to urinate exactly one sip worth of liquid. Look it up!
	private float urinationDelay = 0.2f;
	private float urinationTimer;
	private void UpdateUrination() {
		urinationTimer -= Time.deltaTime;
		if(urinationTimer <= 0f) {
			// Let's urinate one urination unit
			urinationTimer = urinationDelay;
			if(!UrinateOneUnit()) {
				StopUrinating();
			}
		}
	}

	public void StartUrinating() {
		urinating = true;
		urinationTimer = urinationDelay;
	}
	
	public void StopUrinating() {
		urinating = false;
	}

	// Returns false if no more sips left
	private bool UrinateOneUnit() {
		if(sipsDrunk > 0) {
			sipsDrunk--;
			if(sipsDrunk > 0) {
				return true;
			}
		}

		return false;
	}
}
