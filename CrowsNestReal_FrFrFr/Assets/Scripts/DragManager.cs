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
        if (current != null)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.transform as RectTransform, Input.mousePosition, Camera.main, out localPoint);
            current.GetComponent<RectTransform>().anchoredPosition = localPoint;
            if(Input.GetMouseButtonUp(0))
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
