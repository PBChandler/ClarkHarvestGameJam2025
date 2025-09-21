using UnityEngine;
using UnityEngine.UI;

public class DrinkSelectionMinigame : Minigame
{
    [Header("Tea Stuff")]
    public Color TeaStart, TeaTarget, ACTIVE_TEA_COLOR;
    public Image TeaCup;
    public GameObject TeaBag;
    public TeaSteeper step;
    public GameManager localRef;
    public void PlayTeaMinigame()
    {

    }

    public void Update()
    {
        ACTIVE_TEA_COLOR = TeaCup.color;
    }
    /// <summary>
    /// for the tea minigame specifically
    /// </summary>
    public void CalculateScore()
    {
       
        float rDiff = (TeaTarget.r * 255f) - (TeaCup.color.r * 255f);
        float gDiff = (TeaTarget.g * 255f) - (TeaCup.color.g * 255f);
        float bDiff = (TeaTarget.b * 255f) - (TeaCup.color.b * 255f);

        float colorDistance = Mathf.Sqrt(rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);

        if(256-colorDistance > 210)
        {
            if(localRef.instance.CurrentShipTarget == GameManager.activeShipTarget.Navy)
            {
                localRef.instance.score++;
                ScoreScreen.instance.AddTask("Brewed a Propper Cuppa", true);
                localRef.UpdateMinigamesFinished();
            }
        }
        OnEndMinigame(256-colorDistance);
    }
    public void PlayEctoplasmMinigame()
    {

    }

    public void PlayPieMinigame()
    {

    }
}
