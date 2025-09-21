using UnityEngine;
using TMPro;

public class telescopeBoat : MonoBehaviour
{
    public GameObject panel;
    public float position;
    public GameObject backButton;
    public Sprite[] ships;
    public string[] dialogues;
    public TextMeshProUGUI textBox;
    private Sprite ship;
    private SpriteRenderer spriteRenderer;
    private float scale = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("wait", 0.1f);
    }

    void wait()
    {
        int i = 0;
        switch (DATADUDE.instance.SHIP)
        {
            case GameManager.activeShipTarget.NULL:
                break;
            case GameManager.activeShipTarget.Navy:
                i = 0;
                break;
            case GameManager.activeShipTarget.Ghost:
                i = 1;
                break;
            case GameManager.activeShipTarget.Clowns:
                i = 2;
                scale = 0.62085f;
                break;
            default:
                break;
        }
        ship = ships[i];
        textBox.text = dialogues[i];
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        panel.SetActive(true);
        backButton.SetActive(true);
        transform.localScale = new Vector3(scale,scale,1);
        Vector3 pos = transform.localPosition;
        pos.y = 0;
        transform.localPosition = pos;
        spriteRenderer.sprite = ship;
    }
}
