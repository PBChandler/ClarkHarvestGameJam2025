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
    public void Start()
    {
        instance = this;
    }

    public void Update()
    {
        mouseHeld = Input.GetMouseButton(0);
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.transform as RectTransform, Input.mousePosition, Camera.main, out localPoint);
        if (current != null)
        {
            current.GetComponent<RectTransform>().anchoredPosition = localPoint;
        }
    }

    public void GrabNewDragNDrop(DragNDrop toy)
    {
        current = toy;
    }

}
