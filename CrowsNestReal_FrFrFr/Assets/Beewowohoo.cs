using UnityEngine;

public class Beewowohoo : MonoBehaviour
{
    public float timer = 0;
    public Vector3 startScale;
    void Start()
    {
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if((int)timer % 2 == 0)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, startScale + new Vector3(0.5f, 0.5f, 0f), 5 * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector2.Lerp(transform.localScale, startScale, 5 * Time.deltaTime);
        }
        
    }
}
