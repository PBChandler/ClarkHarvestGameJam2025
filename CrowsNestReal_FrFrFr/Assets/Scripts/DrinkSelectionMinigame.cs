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
    [Header("Ghost Stuff")]
    public Image Ectoplasm;
    public Sprite lastEctoplasmSprite;
    public Image Cream;
    public Sprite LastCreamPie;
    private void Start()
    {
        scripts = new string[] { "Perry want a cracker?", "Do...do ghosts drink?" };
    }

    public void PlayTeaMinigame()
    {

    }

    public void Update()
    {
        ACTIVE_TEA_COLOR = TeaCup.color;
    }

    public void REMOTECLOWN()
    {
        CalculateScore(GameManager.activeShipTarget.Clowns);
    }

    public void REMOTEGHOST()
    {
        CalculateScore(GameManager.activeShipTarget.Ghost);
    }

    public void REMOTEBRIT()
    {
        CalculateScore(GameManager.activeShipTarget.Navy);
    }
    /// <summary>
    /// for the tea minigame specifically
    /// </summary>
    public void CalculateScore(GameManager.activeShipTarget ship)
    {
        if (ship != localRef.CurrentShipTarget)
        {
            OnEndMinigame(0);
            return;
        }
        if(ship == GameManager.activeShipTarget.Navy)
        {
            float rDiff = (TeaTarget.r * 255f) - (TeaCup.color.r * 255f);
            float gDiff = (TeaTarget.g * 255f) - (TeaCup.color.g * 255f);
            float bDiff = (TeaTarget.b * 255f) - (TeaCup.color.b * 255f);

            float colorDistance = Mathf.Sqrt(rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);

            if (256 - colorDistance > 210)
            {
                if (localRef.instance.CurrentShipTarget == GameManager.activeShipTarget.Navy)
                {
                    localRef.instance.score++;
                    ScoreScreen.instance.AddTask("Brewed a Propper Cuppa", true);
                    localRef.UpdateMinigamesFinished();
                }
            }
            OnEndMinigame(256 - colorDistance);
        }
        if(ship == GameManager.activeShipTarget.Ghost)
        {
            if(Ectoplasm.sprite == lastEctoplasmSprite)
            {
                localRef.instance.score++;
                ScoreScreen.instance.AddTask("Made Some Ectoplasm", true);
                localRef.UpdateMinigamesFinished();
            }
            else
            {
                ScoreScreen.instance.AddTask("Made Some Ectoplasm", false);
                localRef.UpdateMinigamesFinished();
            }
            OnEndMinigame(0);
        }
        if(ship == GameManager.activeShipTarget.Clowns)
        {
            if (Cream.sprite == LastCreamPie)
            {
                localRef.instance.score++;
                ScoreScreen.instance.AddTask("Made Some Ectoplasm", true);
                localRef.UpdateMinigamesFinished();
            }
            else
            {
                ScoreScreen.instance.AddTask("Made Some Ectoplasm", false);
                localRef.UpdateMinigamesFinished();
            }
            OnEndMinigame(0);
        }
    }
    public void PlayEctoplasmMinigame()
    {

    }

    public void PlayPieMinigame()
    {

    }
}
