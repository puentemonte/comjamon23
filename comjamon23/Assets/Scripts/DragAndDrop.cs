using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rect;
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private int id;
    void Start()
    {
        Debug.Log("Start");
        _rect = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
 
    public void OnBeginDrag(PointerEventData _eventData)
    {
        _canvasGroup.blocksRaycasts = false;
    }
 
    public void OnDrag(PointerEventData _eventData)
    {
        Debug.Log("OnDrag");
        _rect.anchoredPosition += _eventData.delta;
    }
 
    public void OnEndDrag(PointerEventData _eventData)
    {
        _canvasGroup.blocksRaycasts = true;
    }

    public int getId()
    {
        return id;
    }
}
