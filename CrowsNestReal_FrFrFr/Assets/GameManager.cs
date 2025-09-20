using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public delegate void dg_int(int score);
    public dg_int dg_OnScoreUpdated;
    public activeShipTarget CurrentShipTarget = activeShipTarget.Navy;
    public int score
    {
        get { return _score; }
        set { _score = value; dg_OnScoreUpdated.Invoke(value); }
    }
    private int _score;
    void Start()
    {
        instance = this;
        dg_OnScoreUpdated += Dummy;
    }

    public void Dummy(int dum) { }
    // Update is called once per frame
    void Update()
    {
        //testing code;
        if (Input.GetKeyDown(KeyCode.J))
        {
            score++;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            score--;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Telescope");
        }
    }

    public enum activeShipTarget
    {
        NULL,
        Navy,
        Ghost,
        Clowns
    }
}
