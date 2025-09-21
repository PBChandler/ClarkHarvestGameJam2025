using NUnit.Framework;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MinigameFramework : MonoBehaviour
{
    public Minigame MinigameToLaunch;
    private Minigame currentMinigame;
    private Parrot parrot;
    public GameManager localRef;
    public void Start()
    {
        //LaunchMinigame(MinigameToLaunch);
        parrot = GameObject.Find("[PARROT]").GetComponent<Parrot>();
    }
    public void LaunchMinigame(Minigame m)
    {
        m.OnStartMinigame();
        currentMinigame = m;
        //Debug.Log("scropt: " + m.script);
        string script = null;
        switch (localRef.CurrentShipTarget)
        {
            case GameManager.activeShipTarget.NULL:
                break;
            case GameManager.activeShipTarget.Ghost:
                script = m.scripts[1];
                break;
            case GameManager.activeShipTarget.Navy:
                script = m.scripts[0];
                break;
            case GameManager.activeShipTarget.Clowns:
                
                break;
            default:
                break;
        }
        if (script != null)
            parrot.Speak(script);
    }
}
