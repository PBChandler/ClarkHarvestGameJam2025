using UnityEngine;
using UnityEngine.UI;
public class flagButton : MonoBehaviour
{
    public Image image;
    public Sprite flagSprite;
    public Sprite iconSprite;
    Image iconImage;
    public Color color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iconImage = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        iconImage.sprite = iconSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setImage()
    {
        image.sprite = flagSprite;
        image.color = color;
    }
}
