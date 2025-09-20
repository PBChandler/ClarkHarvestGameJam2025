using UnityEngine;

public class telescope : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    float scrollSpeed = 12;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float width = spriteRenderer.bounds.size.x;
        float xpos = transform.position.x;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xpos -= scrollSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xpos += scrollSpeed * Time.deltaTime;

        }
        if (xpos > width / 4)
            xpos -= width/2;
        if (xpos < -width / 4)
            xpos += width/2;
        // xpos = (xpos)%(width/2);

        Vector3 p = transform.position;
        p.x = xpos;
        transform.position = p;
    }
}
