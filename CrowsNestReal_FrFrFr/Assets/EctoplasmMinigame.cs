using UnityEngine;
using UnityEngine.UI;

public class EctoplasmMinigame : MonoBehaviour
{
    public Minigame hahaEpic;
    public Image image;
    public Sprite[] sprites;
    int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image.sprite = sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("ouch");
        nextSprite();
    }
    public void Reset()
    {
        index = 0;
    }

    public void nextSprite()
    {
        index++;
        if (index >= sprites.Length)
        {
            index--;
        }
        image.sprite = sprites[index];
    }
}
