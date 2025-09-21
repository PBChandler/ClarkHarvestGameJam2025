using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarBar : MonoBehaviour
{
    public List<Image> stars;
    public Sprite starEmpty, starFull; //starBomb
    public GameManager localref; //can't do static cos of scene transitions
    public bool resultsScreenOpen;
    int score
    {
        get { return _score; }
        set { _score = value; UpdateScore(); }
    }
    private int _score;
    void Start()
    {
        Invoke("waitASec", 0.1f);
    }

    public void waitASec()
    {
        localref.instance.dg_OnScoreUpdated += SetScore;
    }
    public void SetScore(int sc)
    {
        score = sc;
    }
    public void UpdateScore()
    {
        foreach(Image star in stars)
        {
            if(resultsScreenOpen)
                star.color = Color.white;
            star.sprite = starEmpty;
        }
        for(int i = 0; i < score; i++)
        {
            stars[i].sprite = starFull;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
