using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/SupportedEvents.html 참고
public class RecordUIEvent : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(transform.GetPath() + " OnPointerClick, eventData:" + eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(transform.GetPath() + " OnPointerDown!, eventData:" + eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(transform.GetPath() + " OnPointerEnter!, eventData:" + eventData);
    }
}
