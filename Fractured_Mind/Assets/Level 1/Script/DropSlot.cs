using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public string expectedObject;
    public bool passLevel = false; // La llave que se entregará al jugador
    public Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }


    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem dragItem = eventData.pointerDrag.GetComponent<DraggableItem>();

        Debug.Log(dragItem.name); 
        if (dragItem != null )
        {
            // Colocar el objeto arrastrable en el slot
            dragItem.transform.SetParent(transform);
            dragItem.transform.position = transform.position;
        }
    }

    public bool CheckIfCorrect(GameObject placedObject)
    {
        if (placedObject.name == expectedObject)
        {
            passLevel = true;
            return true;
        }

        return false;
    }
}
