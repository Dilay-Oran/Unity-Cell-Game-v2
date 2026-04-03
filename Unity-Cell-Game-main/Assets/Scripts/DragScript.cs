using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public RectTransform rt;
    Canvas canvas;
    Vector2 startpos;
    CanvasGroup cg;
    public bool matched = false;
    public string targetobject = "";
    public string result = "does not matched"; // true or false


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rt = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startpos = rt.anchoredPosition;
        cg = GetComponent<CanvasGroup>();

    }

    public void OnDrag(PointerEventData eventData)
    {
        matched = false;
        rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        matched |= false;
        cg.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        cg.blocksRaycasts = true;
        BacktoStartPos();
    }

    public void BacktoStartPos()
    {
        if(!matched)
        rt.anchoredPosition = startpos;
    }
}
