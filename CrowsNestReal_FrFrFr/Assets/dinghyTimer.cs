using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class dinghyTimer : MonoBehaviour
{

    public float targetTime = 30.0f; //change time in inspector
    public Image targetImage;
    public float currentFillAmount = 0.0f;
    float elapsedTime = 0f;

    private void Start()
    {
        if (targetImage == null)
        {
            Debug.LogError("Target image is not assigned");
            return;
        }
        targetImage.fillAmount = currentFillAmount;
    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        currentFillAmount = elapsedTime / targetTime;
        targetImage.fillAmount = currentFillAmount; 
        Debug.Log("Current Fill Amount: " + currentFillAmount);

        if (currentFillAmount >= 1f)
        {
            targetImage.fillAmount = currentFillAmount;
            timerEnded();
        }
    }

    void timerEnded()
    {
        Debug.Log("Timer ended yay");
        //Debug.Log("Timer: " + targetTime);
        //Debug.Log("Current Fill Amount: " + currentFillAmount);
    }
}
