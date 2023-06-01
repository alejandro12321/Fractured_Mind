using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour,  IDragHandler, IEndDragHandler
{
    private Transform parentToReturnTo = null;
    private RectTransform rectTransform;
    private Vector3 startPosition;
    
    public DropSlot correctSlot;
    public bool droppedOnSlot = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.position;
        parentToReturnTo = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        
        if (eventData.pointerEnter != null)
        {
            DropSlot slot = eventData.pointerEnter.GetComponent<DropSlot>();
            if (slot != null)
            {
                Debug.Log("Entro");
                transform.SetParent(slot.transform);
                transform.position = slot.transform.position;
                droppedOnSlot = true;
                correctSlot = slot;
            }
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {       
        if (correctSlot != null)
        {
            if (transform.position == correctSlot.transform.position && droppedOnSlot)
            {
                if (correctSlot.CheckIfCorrect(gameObject))
                {
                    correctSlot.image.color = Color.green;
                }
                else
                {
                    correctSlot.image.color = Color.red;
                    droppedOnSlot = false;
                }
            }
        }   
        if (!droppedOnSlot)
        {
            transform.position = startPosition;
            transform.SetParent(parentToReturnTo);
        }
    }
}
