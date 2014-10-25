using System.Collections;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    private TextMesh textMesh;
    private string messageToShow;
    private float secondsToShowMessage;

    public void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void ShowMessageForSeconds(string message, float seconds)
    {
        messageToShow = message;
        secondsToShowMessage = seconds;
        StartCoroutine("DisplayMessage");
    }

    public IEnumerator DisplayMessage()
    {
        string originalText = textMesh.text;
        textMesh.text = messageToShow;
        yield return new WaitForSeconds(secondsToShowMessage);
        textMesh.text = originalText;
    }
}
