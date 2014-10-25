using UnityEngine;

public class ClockDisplay : MonoBehaviour
{
    public TextDisplay display;

    public void Update()
    {
        display.Text = string.Format("{0:d2}:{1:d2}", WorldClock.Hour, WorldClock.Minute);
    }
}