using UnityEngine;

/// <summary>
/// for all information that must persist across all scenes, this bad boy is on a DoNotDestroyOnLoad object.
/// </summary>
public class DATADUDE : MonoBehaviour
{
    public int RoundCounter = 0;
    public GameManager.activeShipTarget SHIP = GameManager.activeShipTarget.Navy;
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
