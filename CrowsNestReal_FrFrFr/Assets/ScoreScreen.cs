using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ScoreScreen : MonoBehaviour
{
    public TextMeshProUGUI description;
    public List<GameObject> blowup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Clear();
    }

    public void Launch()
    {
        foreach(GameObject g in blowup)
        {
            g.SetActive(true);
        }
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
