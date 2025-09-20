using Unity.VisualScripting;
using UnityEngine;

public class telescope : MonoBehaviour
{
    public telescopeBoat boat;
    public SpriteRenderer spriteRenderer;
    public float scrollSpeed;
    public float lookPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float width = spriteRenderer.bounds.size.x/2;
        //float xpos = transform.position.x;
        //float boatRealPosition = boat.position;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            lookPosition -= scrollSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            lookPosition += scrollSpeed * Time.deltaTime;

        }
        lookPosition = bind(lookPosition);
        
        Vector3 p = transform.position;
        p.x = (lookPosition-0.5f)*width;
        transform.position = p;

        float bpos = (lookPosition + boat.position);

        p = boat.transform.position;
        p.x = (bind(bpos) - 0.5f) * width;
        boat.transform.position = p;
    }

    private float bind(float pos)
    {
        if (pos < 0)
            pos += 1;
        if (pos > 1)
            pos -= 1;
        return pos;
    }
}
