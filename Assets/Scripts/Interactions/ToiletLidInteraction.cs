using UnityEngine;

namespace Assets.Scripts.Interactions
{
    public class ToiletLidInteraction : Interaction
    {
        private bool isOpen;
        private Animation parentAnimation;

        public void Awake()
        {
            parentAnimation = gameObject.transform.parent.animation;
        }

        public override void Activate(GameObject player, GameObject itemInHand)
        {
            if (CanOpen())
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        private bool CanOpen()
        {
            return !isOpen && !parentAnimation.isPlaying;
        }

        private void Open()
        {
            parentAnimation.Play("OpenKansi");
            isOpen = true;
        }

        private void Close()
        {
            parentAnimation.Play("CloseKansi");
            isOpen = false;
        }
    }
}
