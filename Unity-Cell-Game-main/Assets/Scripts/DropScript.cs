    using UnityEngine;
    using UnityEngine.EventSystems;

    // sürüklenecek objenin içine canvas group koyulur -raycast kontrolü için

    public class DropScript : MonoBehaviour, IDropHandler
    {
        public string objectname = "";


       public void OnDrop(PointerEventData eventData) // bunun içindeki yazýlar ve dropscriptteki matched satýrlarý olmadan aslýnda drop çalýþýyor ama objeyi etkilemesi gerek
        {
            DragScript dragged = eventData.pointerDrag.GetComponent<DragScript>();//sürüklenen objenin drag scriptine ulaþmamý saðlar
            dragged.matched = true;
            dragged.rt.anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition; // ortasýna gitmesini saðlýyor sürüklenen objenin 

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
