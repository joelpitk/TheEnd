using UnityEngine;

public class KaljaInteraction : Interaction
{
    public AudioClip openSound;
    public AudioClip sipSound;
	public AudioClip burpSound;
    private bool isOpen;
    public int sipsLeft = 3;

    public override void Activate(GameObject player, GameObject itemInHand)
    {
        if (!isOpen)
        {
			audio.clip = openSound;
			isOpen = true;
			audio.Play();
        }
        else
        {
			if(sipsLeft > 0) {
				sipsLeft--;
				PlayerStatus.Thirst.TakeSip();
				PlayerStatus.Drunkness += 0.02f;
				if(sipsLeft > 0) {
					audio.clip = sipSound;
					audio.Play();
				}
				else {
					audio.clip = burpSound;
					audio.Play();
				}
			}
        }
    }
}