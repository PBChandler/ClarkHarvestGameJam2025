using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragManager : MonoBehaviour
{
    public static DragManager instance;
    public bool mouseHeld;
    public RectTransform Canvas;
    //Rupaul
    public DragNDrop current;
    float weirdWait;
    public float maxWeirdWait = 0.1f;
    public void Start()
    {
        instance = this;
    }

    public void Update()
    {
        mouseHeld = Input.GetMouseButton(0);
        if (current != null)
        {
            if (mouseHeld)
            {
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.transform as RectTransform, Input.mousePosition, Camera.main, out localPoint);
                current.me.anchoredPosition = localPoint;
            }
            else
            {
                current = null;
            }
        }
        

    }

    public void GrabNewDragNDrop(DragNDrop toy)
    {
        current = toy;
    }

}
