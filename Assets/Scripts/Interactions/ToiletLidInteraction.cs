﻿using UnityEngine;

namespace Assets.Scripts.Interactions
{
    public class ToiletLidInteraction : Interaction
    {
        private bool isOpen;
        private Animation parentAnimation;
        private ToiletSeatInteraction toiletSeat;

        public bool IsOpen
        {
            get { return isOpen; }
        }

        public void Awake()
        {
            parentAnimation = gameObject.transform.parent.animation;
            toiletSeat = transform.parent.parent.GetComponentInChildren<ToiletSeatInteraction>();
        }

        public override void Activate(GameObject player, GameObject itemInHand)
        {
            if (CanOpen())
            {
                Open();
            }
            else if (!toiletSeat.IsOpen)
            {
                Close();
            }
        }

        private bool CanOpen()
        {
            return !IsOpen && !parentAnimation.isPlaying;
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
