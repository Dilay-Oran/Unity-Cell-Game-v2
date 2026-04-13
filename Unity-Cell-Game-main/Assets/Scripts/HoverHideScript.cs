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

        if (eventData.pointerDrag != null)
        {

            if (eventData.pointerDrag.name == "lisosome")
            {
                foreach (GameObject obj in objectsToHide)
                {
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
                return;
            }
        }
        if (nextButton != null)
        {
            nextButton.interactable = true;
        }
    }
}