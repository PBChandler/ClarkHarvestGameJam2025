using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class DragNDrop : MonoBehaviour
{
    public bool mouseHovering;
    private EventTrigger eve;
    public RectTransform me;

    public void Start()
    {
        eve = GetComponent<EventTrigger>();
        me = GetComponent<RectTransform>();
    }
    public void OnMouseOver(BaseEventData arg0)
    {
        mouseHovering = true;
    }

    public void OnMouseDown(BaseEventData arg0)
    {
        if(DragManager.instance.current == null)
        {
            DragManager.instance.GrabNewDragNDrop(this);
        }
    }

    public void OnMouseExit(BaseEventData arg0)
    {
        mouseHovering = false;
    }
}
