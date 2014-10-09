using UnityEngine;

namespace Assets.Scripts.Interactions
{
    public class ToiletSeatInteraction : Interaction
    {
        private bool isOpen;
        private Animation parentAnimation;
        private ToiletLidInteraction toiletLid;

        public bool IsOpen
        {
            get { return isOpen; }
        }

        public void Awake()
        {
            parentAnimation = transform.parent.animation;
            toiletLid = transform.parent.parent.GetComponentInChildren<ToiletLidInteraction>();
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
            return !IsOpen && !parentAnimation.isPlaying && toiletLid.IsOpen;
        }

        private void Open()
        {
            parentAnimation.Play("OpenIstuin");
            isOpen = true;
        }

        private void Close()
        {
            parentAnimation.Play("CloseIstuin");
            isOpen = false;
        }
    }
}
