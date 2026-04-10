using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic; 



public class GameManager2 : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown golgiDropdown;
    public TMP_Dropdown golgiDropdown1;
    public TMP_Dropdown erDropdown;

    [Header("Buttons")]
    public Button golgiNextButton;
    public Button saveButton;
    public Button erNextButton;
    public Button erNextButton1;

    [Header("Popups")]
    public GameObject golgiTruePopUp;
    public GameObject golgiFalsePopUp;
    public GameObject erTruePopUp;
    public GameObject erFalsePopUp;

    [Header("Drag and Drop Draggables")]
     public List<DragScript> erDraggables;

    void Update()
    {
        CheckErMatched();
    }

    void CheckErMatched()
    {
        if (erDraggables == null || erDraggables.Count == 0) return;

        bool isEverythingDoneEr = true;
        foreach (DragScript item in erDraggables )
        {
            if (!item.matched)
            {
                isEverythingDoneEr = false;
                break;
            }
        }
        erNextButton.interactable = isEverythingDoneEr;
    }
    void CheckErNotebook() 
    {
        
        
            if (erDropdown.value == 1)
            {

                erDropdown.interactable = false;


                if (erTruePopUp != null) erTruePopUp.SetActive(true);
                if (erFalsePopUp != null) erFalsePopUp.SetActive(false);
                if (erNextButton1 != null) erNextButton1.interactable = true;

            }
            else
            {
                if (erFalsePopUp != null) erFalsePopUp.SetActive(true);
                if (erTruePopUp != null) erTruePopUp.SetActive(false);
            }
        
    }

    void CheckGolgiNotebook() 
    {
        bool golgiCorrect = golgiDropdown.value == 1 && golgiDropdown1.value == 2;


        golgiTruePopUp.SetActive(golgiCorrect);
        golgiFalsePopUp.SetActive(!golgiCorrect);
        golgiNextButton.interactable = golgiCorrect;


        if (golgiCorrect)
        {
            golgiDropdown.interactable = false;
            golgiDropdown1.interactable = false;

            golgiDropdown.RefreshShownValue();
            golgiDropdown1.RefreshShownValue();
        }
    }

    public void SaveButtonOnclicked() 
    {
        CheckErNotebook();
        CheckGolgiNotebook();

    }

  
}
