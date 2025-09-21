using UnityEngine;
using UnityEngine.SceneManagement;
public class Startup : MonoBehaviour
{
    public float delay;
    public AudioClip clip;
    public AudioSource src;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("LoadNextScene", delay);
        src.PlayOneShot(clip);
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
