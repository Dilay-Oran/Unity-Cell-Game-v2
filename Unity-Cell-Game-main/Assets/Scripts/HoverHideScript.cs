using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverHideScript : MonoBehaviour, IPointerEnterHandler
{
    public List<GameObject> objectsToHide;
    public Button nextButton;
    public List<GameObject> allObjects;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover oldu!");
        Debug.Log("pointerDrag: " + eventData.pointerDrag);

        if (eventData.pointerDrag != null)
        {
            Debug.Log("Sürüklenen obje adý: " + eventData.pointerDrag.name);

            if (eventData.pointerDrag.name == "lisosome")
            {
                Debug.Log("Liste sayýsý: " + objectsToHide.Count);
                foreach (GameObject obj in objectsToHide)
                {
                    Debug.Log("Gizleniyor: " + obj.name);
                    if (obj != null)
                        obj.SetActive(false);
                }
                CheckAllHidden();
            }
        }
    }
    void CheckAllHidden()
    {
        foreach (GameObject obj in allObjects)
        {
            if (obj != null && obj.activeSelf)
            {
                Debug.Log("Henüz gizlenmedi: " + obj.name);
                return;
            }
        }
        Debug.Log("Hepsi gizlendi, buton aktifleþiyor!");
        if (nextButton != null)
        {
            nextButton.interactable = true;
            Debug.Log("Buton interactable: " + nextButton.interactable);
            Debug.Log("Buton gameObject aktif mi: " + nextButton.gameObject.activeSelf);
        }
    }
}