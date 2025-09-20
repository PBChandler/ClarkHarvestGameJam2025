using UnityEngine;

public class MinigameFramework : MonoBehaviour
{
    public Minigame MinigameToLaunch;
    private Minigame currentMinigame;
    public void Start()
    {
        LaunchMinigame(MinigameToLaunch);
    }
    public void LaunchMinigame(Minigame m)
    {
        m.OnStartMinigame();
        currentMinigame = m;
    }
}
