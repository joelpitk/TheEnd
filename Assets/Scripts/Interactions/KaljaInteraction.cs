using UnityEngine;

public class KaljaInteraction : Interaction
{
    public AudioClip openSound;
    public AudioClip sipSound;
    private bool isOpen;
    public int sipsLeft = 3;

    public override void Activate(GameObject player, GameObject itemInHand)
    {
        if (isOpen && sipsLeft >= 0)
        {
            audio.clip = sipSound;
            sipsLeft--;
        }
        else
        {
            audio.clip = openSound;
            isOpen = true;
        }

        if (sipsLeft >= 0)
        {
            audio.Play();
        }
    }
}