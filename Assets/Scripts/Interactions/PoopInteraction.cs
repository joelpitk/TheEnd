using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Interactions {
	public class PoopInteraction : Interaction {
		private ToiletLidInteraction lid;
		public ToiletPaperInteraction paper;
		public Transform steppingUpFromToiletPosition;

		private GameObject player;
		private bool playerPooping;

		// Use this for initialization
		void Start () {
			lid = transform.parent.GetComponentInChildren<ToiletLidInteraction>();
		}
		
		// Update is called once per frame
		void Update () {
			if(playerPooping) {
				Vector3 moving = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				if(moving != Vector3.zero) {
					player.transform.position = steppingUpFromToiletPosition.position;
					player.transform.forward = gameObject.transform.forward;
					playerPooping = false;
				}
			}
		}

		public override void Activate (GameObject player, GameObject itemInHand)
		{
			if(lid.IsOpen) {
				playerPooping = true;
				this.player = player;
				Vector3 newPos = new Vector3();
				player.transform.forward = gameObject.transform.forward;
				newPos.x = gameObject.transform.position.x;
				newPos.z = gameObject.transform.position.z;
				newPos.y = player.transform.position.y;
				player.transform.position = newPos;
				// Play pooping sound. Fun!
			}
		}
	}
}