using UnityEngine;
using UnityEngine.UI;
public class TeaSteeper : MonoBehaviour
{
    public bool teaModeStarted;
    public bool mouseInput;
    public GameObject steep;
    public RectTransform rec;
    public GameObject Canvas;
    public float maxHeight, maxDepth;
    public Image teaColor;
    public float yLowest;
    public Color TeaStart, TeaTarget;
    public float speed;
    public void OnClick()
    {
        teaModeStarted = true;
        teaColor.color = TeaStart;
    }

    public void Update()
    {
        mouseInput = Input.GetMouseButton(0);
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.transform as RectTransform, Input.mousePosition, Camera.main, out localPoint);
        if(localPoint.y >= maxDepth)
            rec.anchoredPosition = new Vector2(rec.anchoredPosition.x, localPoint.y);
        if(localPoint.y < maxHeight)
        {
            teaColor.color = Color.Lerp(teaColor.color, TeaTarget, speed * Time.deltaTime);
        }
    }
}
