using UnityEngine;
using System.Collections.Generic;

public class Minigame : MonoBehaviour
{
    public List<GameObject> elements;
    public virtual void OnStartMinigame()
    {
        foreach (GameObject item in elements)
        {
            item.SetActive(true);
        }
    }

    public virtual void OnEndMinigame(float score)
    {
        foreach (GameObject item in elements)
        {
            item.SetActive(false);
        }
        Debug.Log(score);
    }
}
