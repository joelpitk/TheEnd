using UnityEngine;

public abstract class Interaction : MonoBehaviour 
{
    public abstract void Activate(GameObject player, GameObject itemInHand);
}