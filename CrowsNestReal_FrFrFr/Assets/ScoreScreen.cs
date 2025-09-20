using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class ScoreScreen : MonoBehaviour
{
    public TextMeshProUGUI description;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Clear();
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
