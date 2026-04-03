using UnityEngine;
using UnityEngine.EventSystems;

public class DropScript : MonoBehaviour, IDropHandler
{
    public string objectname = "";

   public void OnDrop(PointerEventData eventData)
    {
        DragScript dragged = eventData.pointerDrag.GetComponent<DragScript>();
        dragged.matched = true;

        if (dragged.targetobject == objectname) 
        {
            dragged.result = "doðru";
        
        }
        else
        {
            dragged.result = "false";
            dragged.matched = false;
            dragged.BacktoStartPos();
        }

    }

   
}
