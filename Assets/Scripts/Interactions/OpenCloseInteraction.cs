using UnityEngine;

namespace Assets.Scripts.Interactions
{
    public class OpenCloseInteraction : Interaction
    {
        private bool isOpen;

        public override void Activate(GameObject player, GameObject itemInHand)
        {
            if (isOpen)
            {
                transform.parent.animation.Play("Close");
                isOpen = false;
            }
            else
            {
                transform.parent.animation.Play("Open");
                isOpen = true;
            }
        }
    }
}