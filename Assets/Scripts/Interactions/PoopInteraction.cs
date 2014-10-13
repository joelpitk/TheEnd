using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Interactions {
	public class PoopInteraction : Interaction {
		private ToiletLidInteraction lid;

		public GameObject sitterObject;
		public ToiletPaperInteraction paper;
		public Transform steppingUpFromToiletPosition;

		private GameObject player;
		private bool playerPooping;
		private bool standingUp;

		// Use this for initialization
		void Start () {
			lid = transform.parent.GetComponentInChildren<ToiletLidInteraction>();
			playerPooping = false;
			standingUp = false;
		}
		
		// Update is called once per frame
		void Update () {
			if(playerPooping) {
				if(standingUp) {
					Animation anim = sitterObject.GetComponentInChildren<Animation>();
					if(!anim.isPlaying) {
						sitterObject.SetActive(false);
						player.SetActive(true);
						player.transform.forward = sitterObject.transform.forward;
						Camera c = player.GetComponentInChildren<Camera>();
						c.gameObject.GetComponent<MouseLook>().ResetYRotation();

						// Set player position to the front of the toilet so she stands up to the correct position
						Vector3 pos = sitterObject.transform.position;
						pos.y = player.transform.position.y;
						player.transform.position = pos;

						playerPooping = false;
						playerPooping = false;
						standingUp = false;
					}
				}
				else {
					Vector3 moving = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
					if(moving != Vector3.zero) {
						// If we are already seated, let's stand up then
						Animation anim = sitterObject.GetComponentInChildren<Animation>();
						if(!anim.isPlaying) {
							standingUp = true;
							anim.Play("StandUp");
						}
					}
				}
			}
		}

		public override void Activate (GameObject player, GameObject itemInHand)
		{
			if(playerPooping) {
				standingUp = true;
				Animation anim = sitterObject.GetComponentInChildren<Animation>();
				anim.Play("StandUp");
			}
			else if(lid.IsOpen) {
				playerPooping = true;
				this.player = player;
				player.SetActive(false);
				sitterObject.SetActive(true);
				Animation anim = sitterObject.GetComponentInChildren<Animation>();
				anim.Play("SitDown");

				// Play pooping sound. Fun!
			}
		}
	}
}