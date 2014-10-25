using System.Collections;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    private TextMesh textMesh;
    private string messageToShow;
    private float secondsToShowMessage;
    private string originalText;

    public string Text
    {
        get { return textMesh.text; }
        set { textMesh.text = value; }
    }

    public void Awake()
    {
        textMesh = GetComponent<TextMesh>();
        originalText = textMesh.text;
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        textMesh.text = originalText;
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
        originalText = textMesh.text;
        textMesh.text = messageToShow;
        yield return new WaitForSeconds(secondsToShowMessage);
        textMesh.text = originalText;
    }
}
