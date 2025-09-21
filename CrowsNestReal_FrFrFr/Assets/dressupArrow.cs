using UnityEngine;
using UnityEngine.Events;

public class dressupArrow : MonoBehaviour
{
    public UnityEvent myEvent;
    public Sprite[] spriteArray;
    int index = 0;
    public SpriteRenderer currentImage;
    //only needed for the finish button
    public DressUpMinigame localRef;
    public AudioClip clip;
    private void OnMouseDown()
    {
        AudioManager.instance.PlaySound(clip);
        myEvent.Invoke();
    }

    public void displayImage()
    {
        if (index >= 0 && index < spriteArray.Length)
        {
            currentImage.sprite = spriteArray[index];
        }
        else
        {
            Debug.LogWarning("Invalid image index: " + index);
        }
    }

    public void nextImage()
    {
        index = (index + 1) % spriteArray.Length;
        displayImage();
    }

    public void prevImage()
    {
        index = (index - 1 + spriteArray.Length) % spriteArray.Length;
        displayImage();
    }

    public void testButton()
    {
        Debug.Log("my princess is so beautiful..");

        localRef.CalculateScore();
    }
}
