using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ScoreScreen : MonoBehaviour
{
    public static ScoreScreen instance;
    public TextMeshProUGUI description;
    public List<GameObject> blowup;
    public StarBar rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Clear();
        instance = this;
    }

    public void Launch()
    {
        foreach(GameObject g in blowup)
        {
            g.SetActive(true);
        }
        rend.resultsScreenOpen = true;
        rend.UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTask(string taskName, bool completed)
    {
        if (completed)
            description.text += "[X] ";
        else description.text += "[   ] "; 
        description.text += taskName + "\n";
    }
    public void Clear()
    {
        description.text = "";
    }
}
