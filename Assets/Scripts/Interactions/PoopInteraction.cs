using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Interactions {
	public class PoopInteraction : Interaction {
		private ToiletLidInteraction lid;

		public GameObject sitterObject;
		public ToiletPaperInteraction paper;

		private bool playerUrinating;

		private GameObject player;
		private bool playerSitting;
		private bool standingUp;
		private bool sittingDown;

		// Use this for initialization
		void Start () {
			lid = transform.parent.GetComponentInChildren<ToiletLidInteraction>();
			playerSitting = false;
			standingUp = false;
			sittingDown = false;
			playerUrinating = false;
		}
		
		// Update is called once per frame
		void Update () {
			if(playerSitting) {
				if(playerUrinating) {
					if(!PlayerStatus.Thirst.Urinating) {
						StopUrinating();
					}
				}

				if(standingUp) {
					Animation anim = sitterObject.GetComponentInChildren<Animation>();
					if(!anim.isPlaying) {
						SwitchToStanding();
					}
				}
				else {
					Vector3 moving = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
					if(moving != Vector3.zero) {
						// If we are already seated, let's stand up
						Animation anim = sitterObject.GetComponentInChildren<Animation>();
						if(!anim.isPlaying) {
							StartStandingUp();
						}
					}
				}
			}
			else if(sittingDown) {
				Animation anim = sitterObject.GetComponentInChildren<Animation>();
				if(!anim.isPlaying) {
					SwitchToSitting();
				}
			}
		}

		private void StopUrinating() {
			PlayerStatus.Thirst.StopUrinating();
			sitterObject.audio.Stop();
			playerUrinating = false;
		}

		private void StartUrinating() {
			playerUrinating = true;
			PlayerStatus.Thirst.StartUrinating();
			sitterObject.audio.Play();
		}

		private void StartStandingUp() {
			standingUp = true;
			Animation anim = sitterObject.GetComponentInChildren<Animation>();
			anim.Play("StandUp");

			StopUrinating();

		}

		private void StartSittingDown() {
			sittingDown = true;

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
			sittingDown = false;

			StartUrinating();
		}

		public override void Activate (GameObject player, GameObject itemInHand)
		{
			if(playerSitting) {
				StartStandingUp();
			}
			else if(lid.IsOpen) {
				this.player = player;
				StartSittingDown();
			}
		}
	}
}