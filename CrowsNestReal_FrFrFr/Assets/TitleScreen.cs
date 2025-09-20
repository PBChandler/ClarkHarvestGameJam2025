using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("sampleScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("creditsScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("No you aren't allowed to quit");
    }

}
