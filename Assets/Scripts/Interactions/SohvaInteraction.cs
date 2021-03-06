﻿using UnityEngine;
using System.Collections;

public class SohvaInteraction : Interaction {
	public GameObject sitterObject;
	
	private GameObject player;
	private bool playerSitting;
	private bool standingUp;
	
	// Use this for initialization
	void Start () {
		playerSitting = false;
		standingUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerSitting) {
			if(standingUp) {
				Animation anim = sitterObject.GetComponentInChildren<Animation>();
				if(!anim.isPlaying) {
					SwitchToStanding();
				}
			}
			else {
				Vector3 moving = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				if(moving != Vector3.zero) {
					// If we are already seated, let's stand up then
					Animation anim = sitterObject.GetComponentInChildren<Animation>();
					if(!anim.isPlaying) {
						StartStandingUp();
					}
				}
			}
		}
	}
	
	private void StartStandingUp() {
		standingUp = true;
		Animation anim = sitterObject.GetComponentInChildren<Animation>();
		anim.Play("StandUp");
	}
	
	private void SwitchToStanding() {
		player.SetActive(true);
		player.transform.forward = sitterObject.transform.forward;
		Camera c = player.GetComponentInChildren<Camera>();
		c.gameObject.GetComponent<MouseLook>().ResetYRotation();
		
		// Set player position to the front of the toilet so she stands up to the correct position
		Vector3 pos = sitterObject.transform.position;
		pos.y = player.transform.position.y;
		player.transform.position = pos;

		playerSitting = false;
		standingUp = false;
		
		// If the player is carrying something, drop it
		InteractionControls i1 = sitterObject.GetComponentInChildren<InteractionControls>();
		if(i1.CarriedObject != null) {
			i1.HandleDrop();
		}
		
		sitterObject.SetActive(false);
	}
	
	private void SwitchToSitting() {
		playerSitting = true;
		sitterObject.SetActive(true);
		Animation anim = sitterObject.GetComponentInChildren<Animation>();
		anim.Play("SitDown");
		
		// If the player is carrying something, drop it
		InteractionControls i1 = player.GetComponent<InteractionControls>();
		if(i1.CarriedObject != null) {
			i1.HandleDrop();
		}
		player.SetActive(false);
	}

	public override void Activate (GameObject player, GameObject itemInHand)
	{
		if(playerSitting) {
			StartStandingUp();
		}
		else {
			this.player = player;
			SwitchToSitting();
		}
	}
}
