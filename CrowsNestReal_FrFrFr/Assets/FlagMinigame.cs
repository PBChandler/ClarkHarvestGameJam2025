using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlagMinigame : Minigame
{
    public Image foreground, background;
    public GameManager localRef;
    [System.Serializable]
    public struct epicSet
    {
        public GameManager.activeShipTarget shipTarget;
        public Color validBGColor;
        public Sprite sprite;
    }

    public List<epicSet> awesomeSets;

    private void Start()
    {
        scripts = new string[] { "Isn't that from the privy?", "Don't tear up my favorite flag...:(" };
    }

    public void CalculateScore()
    {
        int points = 0;
        epicSet work = awesomeSets.Find(p => p.shipTarget == localRef.CurrentShipTarget);
        if(foreground.sprite == work.sprite) { points += 1; }
        if(background.color == work.validBGColor) { points += 1; };
        if(points == 2)
        {
            OnEndMinigame(points);
            localRef.score++;
            ScoreScreen.instance.AddTask("Created The Right Flag", true);
            localRef.UpdateMinigamesFinished();
        }
        else
        {
            OnEndMinigame(points);
            ScoreScreen.instance.AddTask("Created The Right Flag", false);
            localRef.UpdateMinigamesFinished();
        }
    }
}
