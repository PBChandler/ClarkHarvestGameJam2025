using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Parrot : MonoBehaviour
{
    public Parrot instance;
    public TextMeshProUGUI epic;
    public Image sprite;
    public Sprite closed, Open;
    public GameManager localRef;
    bool firstLine = false;
    public AudioClip talking;
    public dinghyTimer ding;
    public void Start()
    {
        instance = this;
        Invoke("wait", 0.1f);
    }

    public void wait()
    {
        if(localRef.CurrentShipTarget == GameManager.activeShipTarget.Navy)
        {
            firstLine = true;
            Speak("You have one minute to get everything ship-shape before they come and interrogate you!");
        }
        
    }
    public void Speak(string text)
    {
        StopAllCoroutines();
        epic.text = "<color=black>"+text+" .";
        StartCoroutine(Fade(text + " ."));
    }
    int index = 0;
    public IEnumerator Fade(string text)
    {
        
        while(index < text.Length)
        {
            yield return new WaitForSeconds(0.05f);
            epic.text = text.Substring(0, index) + "<color=black>";
            if (text[index] == ' ')
            {
                sprite.sprite = closed;
            }
            else
            {
                AudioManager.instance.PlaySoundPitchVariance(talking, 0.4f, 0.6f);
                sprite.sprite = Open;
            }

            index++;
        }
        sprite.sprite = closed;
        index = 0;
        dialogEnded();
    }

    public void dialogEnded()
    {
        if(firstLine)
        {
            ding.Startwe = true;
        }
    }
}
