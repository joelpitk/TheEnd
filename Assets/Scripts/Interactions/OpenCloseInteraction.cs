using UnityEngine;

namespace Assets.Scripts.Interactions
{
    public class OpenCloseInteraction : Interaction
    {
        private bool isOpen;
        public string closingAnimationName = "Close";
        public string openingAnimationName = "Open";
        public AudioClip closingSound;
        public float closingSoundDelay;
        public AudioClip openingSound;
        public float openingSoundDelay;

        public override void Activate(GameObject player, GameObject itemInHand)
        {
            if (isOpen)
            {
                if (audio != null)
                {
                    audio.clip = closingSound;
                    audio.PlayDelayed(closingSoundDelay);
                }
                transform.parent.animation.Play(closingAnimationName);
                isOpen = false;
            }
            else
            {
                if (audio != null)
                {
                    audio.clip = openingSound;
                    audio.PlayDelayed(openingSoundDelay);
                }
                transform.parent.animation.Play(openingAnimationName);
                isOpen = true;
            }
        }
    }
}