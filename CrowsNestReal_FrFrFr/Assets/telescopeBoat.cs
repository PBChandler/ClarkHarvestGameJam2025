using UnityEngine;

public class telescopeBoat : MonoBehaviour
{
    public GameObject panel;
    public float position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        panel.SetActive(true);
    }
}
