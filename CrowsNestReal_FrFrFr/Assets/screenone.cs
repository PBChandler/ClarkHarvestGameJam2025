using UnityEngine;

public class screenone : MonoBehaviour
{
    public GameObject finishedButton;
    public GameManager localRef;
    public GameObject dialogScreen;
    bool donezo;
    public void OnClick()
    {
        localRef.score++;
        ScoreScreen.instance.AddTask("Finished With Extra Time", true);
        dialogScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(localRef.score >= 3 && !donezo)
        {
            finishedButton.SetActive(true);
            donezo = true;
        }
    }
}
