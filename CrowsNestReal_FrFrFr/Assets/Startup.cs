using UnityEngine;
using UnityEngine.SceneManagement;
public class Startup : MonoBehaviour
{
    public float delay;
    public AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("LoadNextScene", delay);
        AudioManager.instance.PlaySound(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
