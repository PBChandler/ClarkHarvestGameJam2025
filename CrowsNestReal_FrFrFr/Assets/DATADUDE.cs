using UnityEngine;

/// <summary>
/// for all information that must persist across all scenes, this bad boy is on a DoNotDestroyOnLoad object.
/// </summary>
public class DATADUDE : MonoBehaviour
{
    public int RoundCounter = 0;
    public GameManager.activeShipTarget SHIP = GameManager.activeShipTarget.Navy;
    public static DATADUDE instance;
    public void Start()
    {
        if(DATADUDE.instance == null)
        {
            instance = this;
        }
        else if(DATADUDE.instance != this && DATADUDE.instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnSceneLoaded()
    {
        Debug.Log("CAN YOU FEEL");
        
    }
    public void ChangeShipTarget(GameManager.activeShipTarget shipTarget)
    {
        Debug.Log("LAMAR");
        SHIP = shipTarget;
    }
}
