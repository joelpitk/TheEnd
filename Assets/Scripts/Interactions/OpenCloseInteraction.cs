using UnityEngine;

namespace Assets.Scripts.Interactions
{
    public class OpenCloseInteraction : Interaction
    {
        private bool isOpen;
        public string closingAnimationName = "Close";
        public string openingAnimationName = "Open";

        public override void Activate(GameObject player, GameObject itemInHand)
        {
            if (isOpen)
            {
                transform.parent.animation.Play(closingAnimationName);
                isOpen = false;
            }
            else
            {
                transform.parent.animation.Play(openingAnimationName);
                isOpen = true;
            }
        }
    }
}