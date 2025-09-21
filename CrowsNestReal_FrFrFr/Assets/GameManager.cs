using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public delegate void dg_int(int score);
    public dg_int dg_OnScoreUpdated;
    public activeShipTarget CurrentShipTarget = activeShipTarget.Navy;
    public AudioSource source;
    public List<jukeboxDisc> discs;
    public ScoreScreen resultsScreen;
    public int minigamesFinished = 0;
    [System.Serializable]
    public struct jukeboxDisc
    {
        public AudioClip clip;
        public activeShipTarget target;
    }
    public int score
    {
        get { return _score; }
        set { _score = value; dg_OnScoreUpdated.Invoke(value); }
    }
    private int _score;
    void Start()
    {
        instance = this;
        try
        {
            CurrentShipTarget = GameObject.Find("DATADUDE").GetComponent<DATADUDE>().SHIP;
        }
        catch
        {
            CurrentShipTarget = activeShipTarget.Navy;
        }
        dg_OnScoreUpdated += Dummy;
        SetMusic();
    }

    public void UpdateMinigamesFinished()
    {
        minigamesFinished++;
    }

    public void LoadResultsScreen()
    {
        resultsScreen.Launch();
    }
    public void SetMusic()
    {
        foreach(jukeboxDisc dis in discs)
        {
            if(dis.target == CurrentShipTarget)
            {
                source.clip = dis.clip;
                source.Play();
            }
        }
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
