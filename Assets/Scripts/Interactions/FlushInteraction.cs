using UnityEngine;

namespace Assets.Scripts.Interactions
{
    public class FlushInteraction : Interaction
    {
        public override void Activate(GameObject player, GameObject itemInHand)
        {
            if (!audio.isPlaying)
            {
                animation.Play("Flush");
                audio.Play();
            }
        }
    }
}