using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Interactions {
	public class ToiletPaperInteraction : Interaction {
		public bool WipeMode {
			get; set;
		}

		private int usesLeft;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public override void Activate (GameObject player, GameObject itemInHand)
		{
			if(usesLeft == 0) {
				return;
			}

			if(WipeMode) {
				// Play an ass wipe sound
			}
			else {
				// Play a sneeze sound or something??
			}

			usesLeft--;
			// Change the model at certain intervals to indicate paper running out?!?!
		}
	}
}