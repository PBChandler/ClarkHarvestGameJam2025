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
    public void OnEnable()
    {
        LaunchDialogSequence(GameManager.activeShipTarget.Navy);
    }
    public void LaunchDialogSequence(GameManager.activeShipTarget target)
    {
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

    public void ContinueDialogSequence(bool win)
    {
        if(!win && activeChunk.lines[index].isInstaFail == true)
        {
            localRef.LoadResultsScreen();
        }
        if(index + 1 > activeChunk.lines.Count)
        {
            localRef.score++;
            
            localRef.LoadResultsScreen();
        }
    }
    public void SelectDialogChoice(int i)
    {
        if(i == winningNumber)
        {
            ContinueDialogSequence(true);
        }
        else
        {
            ContinueDialogSequence(false);
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
}
[System.Serializable]
public struct dialogChunk
{
    public GameManager.activeShipTarget mode;
    public List<dialogLine> lines;
}