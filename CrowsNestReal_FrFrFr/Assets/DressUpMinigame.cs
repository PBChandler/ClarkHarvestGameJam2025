using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DressUpMinigame : Minigame
{
    public SpriteRenderer hat, shirt, accessory;
    public Sprite brit_hat, brit_shirt, brit_accessory;
    public Sprite ghost_hat, ghost_shirt, ghost_accessory;
    public Sprite clown_hat, clown_shirt, clown_accessory;
    public GameManager localRef;
    public Button thisButton;

    private void Start()
    {
        scripts = new string[] { "We should make a Roblox game like this...", "Is that ketchup? I hope that's ketchup."};
    }
    public void CalculateScore()
    {
        int score = 0;
        switch (localRef.CurrentShipTarget)
        {
            case GameManager.activeShipTarget.NULL:
                break;
            case GameManager.activeShipTarget.Ghost:
                if (hat.sprite == ghost_hat)
                    score++;
                if (shirt.sprite == ghost_shirt)
                    score++;
                if (accessory.sprite == ghost_accessory)
                    score++;
                break;
            case GameManager.activeShipTarget.Navy:
                if (hat.sprite == brit_hat)
                    score++;
                if (shirt.sprite == brit_shirt)
                    score++;
                if (accessory.sprite == brit_accessory)
                    score++;
                break;
            case GameManager.activeShipTarget.Clowns:
                if (hat.sprite == clown_hat)
                    score++;
                if (shirt.sprite == clown_shirt)
                    score++;
                if (accessory.sprite == clown_accessory)
                    score++;
                break;
            default:
                break;
        }
        if(score == 3)
        {
            localRef.score++;
            OnEndMinigame(score);
            ScoreScreen.instance.AddTask("Equipped Proper Attire", true);
            localRef.UpdateMinigamesFinished();
            thisButton.enabled = false; 
        }
        else
        {
            thisButton.enabled = true;
            OnEndMinigame(score);
            ScoreScreen.instance.AddTask("Equipped Proper Attire", false);
            localRef.UpdateMinigamesFinished();
        }
    }
}
