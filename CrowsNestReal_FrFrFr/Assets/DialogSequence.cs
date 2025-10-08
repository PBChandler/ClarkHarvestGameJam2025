using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogSequence : MonoBehaviour
{
    public GameManager localRef;
    public TextMeshProUGUI talkyText;

    public TextMeshProUGUI optionOne, optionTwo, optionThree, optionFour;
    public int index = 0;
    public int winningNumber = 0;
    public List<dialogChunk> chunks;
    private dialogChunk activeChunk;
    public Sprite[] BritSprites;
    public Sprite[] GhostSprites;
    public Sprite[] ClownSprites;
    public Sprite neutral, happy, angry;
    public Image awesomeDude;
    
    int score = 0;
    public void OnEnable()
    {
        LaunchDialogSequence(localRef.CurrentShipTarget);
    }
    public void LaunchDialogSequence(GameManager.activeShipTarget target)
    {
        target = localRef.CurrentShipTarget;
        setSprites(target);
        setSprites(target);
        index = 0;
        dialogChunk c = chunks.Find(p => p.mode == target);
        talkyText.text = c.lines[index].displayText;
        optionOne.text = c.lines[index].opt1;
        optionTwo.text = c.lines[index].opt2;
        optionThree.text = c.lines[index].opt3;
        optionFour.text = c.lines[index].opt4;
        winningNumber = c.lines[index].correctOption;
        activeChunk = c;
    }
    private void setSprites(GameManager.activeShipTarget target)
    {
        Sprite[] sprites = null;
        switch (target)
        {
            //case GameManager.activeShipTarget.NULL:
            //    break;
            case GameManager.activeShipTarget.Ghost:
                sprites = GhostSprites;
                break;
            case GameManager.activeShipTarget.Navy:
                sprites = BritSprites;
                break;
            case GameManager.activeShipTarget.Clowns:
                sprites = ClownSprites;
                break;
            default:
                return;
                //break;
        }
        happy = sprites[0];
        neutral = sprites[1];
        angry = sprites[2];
        if(neutral != null)
        {
            awesomeDude.sprite = neutral;
        }
      
    }

    public void ContinueDialogSequence(bool win)
    {
        if(win)
        {
            score++;
        }
        if(!win && activeChunk.lines[index].isInstaFail == true)
        {
            localRef.LoadResultsScreen();
            ScoreScreen.instance.AddTask("Verbal Deception", false);
            return;
        }
        if(index >= activeChunk.lines.Count-1)
        {
            if(score >= activeChunk.lines.Count-1)
            {
                localRef.score++;
                ScoreScreen.instance.AddTask("Verbal Deception", true);
            }
            else
            {
                ScoreScreen.instance.AddTask("Verbal Deception", false);
            }
            
            localRef.LoadResultsScreen();
            return;
        }
        if(index < activeChunk.lines.Count)
        {
            index++;
        }
       
        dialogChunk c = activeChunk;
        talkyText.text = c.lines[index].displayText;
        optionOne.text = c.lines[index].opt1;
        optionTwo.text = c.lines[index].opt2;
        optionThree.text = c.lines[index].opt3;
        optionFour.text = c.lines[index].opt4;
        winningNumber = c.lines[index].correctOption;
    }
    public void SelectDialogChoice(int i)
    {
        try
        {
            if (i == 1)
            {
                activeChunk.lines[index].opt1.Contains("  ");
                {
                    AudioManager.instance.PlaySound(activeChunk.lines[index].clip);
                }
            }
            if (i == 2)
            {
                activeChunk.lines[index].opt2.Contains("  ");
                {
                    AudioManager.instance.PlaySound(activeChunk.lines[index].clip);
                }
            }
            if (i == 3)
            {
                activeChunk.lines[index].opt3.Contains("  ");
                {
                    AudioManager.instance.PlaySound(activeChunk.lines[index].clip);
                }
            }
            if (i == 4)
            {
                activeChunk.lines[index].opt4.Contains("  ");
                {
                    AudioManager.instance.PlaySound(activeChunk.lines[index].clip);
                }
            }
        }
        catch
        {

        }
        

        if (i == winningNumber)
        {
            ContinueDialogSequence(true);
            awesomeDude.sprite = happy;
        }
        else
        {
            ContinueDialogSequence(false);
            awesomeDude.sprite = angry;
        }
    }
   
}
[System.Serializable]
public struct dialogLine
{
    public string displayText;
    public string opt1, opt2, opt3, opt4;
    public int correctOption;
    public bool isInstaFail;
    public AudioClip clip;
}
[System.Serializable]
public struct dialogChunk
{
    public GameManager.activeShipTarget mode;
    public List<dialogLine> lines;
}