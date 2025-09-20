using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DressUpMinigame : Minigame
{
    public Sprite[] spriteArray;
    int index = 0;
    public Image currentImage;

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
        index = (index+1)%spriteArray.Length;
        displayImage();
    }

    public void prevImage()
    {
        index = (index-1+spriteArray.Length)%spriteArray.Length;
        displayImage();
    }
}
