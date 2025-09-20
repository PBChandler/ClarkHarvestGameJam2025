using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Parrot : MonoBehaviour
{
    public Parrot instance;
    public TextMeshProUGUI epic;

    public void Start()
    {
        instance = this;
        Speak("I'm the King of the Junjel, baby");
    }
    public void Speak(string text)
    {
        epic.text = "<color=black>"+text+" .";
        StartCoroutine(Fade(text + " ."));
    }

    public IEnumerator Fade(string text)
    {
        int index = 0;
        while(index < text.Length)
        {
            yield return new WaitForSeconds(0.05f);
            epic.text = text.Substring(0, index) + "<color=black>";
            index++;
        }
    }
}
