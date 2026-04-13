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
    public TMP_Dropdown sentrosomeDropdown;
    public TMP_Dropdown sentrosomeDropdown1;
    public TMP_Dropdown lisosomeDropdown;
    public TMP_Dropdown lisosomeDropdown1;

    [Header("Buttons")]
    public Button golgiNextButton;
    public Button saveButton;
    public Button erNextButton;
    public Button erNextButton1;
    public Button sentrosomeNextButton;
    public Button rfaNextButton;
    public Button rfaNextButton1;
    public Button rfaNextButton2;
    public Button lisosomeNextButton;

    [Header("Popups")]
    public GameObject golgiTruePopUp;
    public GameObject golgiFalsePopUp;
    public GameObject erTruePopUp;
    public GameObject erFalsePopUp;
    public GameObject sentrosomeTruePopUp;
    public GameObject sentrosomeFalsePopUp;
    public GameObject lisosomeTruePopUp;
    public GameObject lisosomeFalsePopUp;

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

    void CheckSentrosomeNotebook()
    {
        if (sentrosomeDropdown.value == 1 && sentrosomeDropdown1.value == 2)
        {

            sentrosomeDropdown.interactable = false;
            sentrosomeDropdown1.interactable = false;

                
            if (sentrosomeTruePopUp != null) sentrosomeTruePopUp.SetActive(true);
            if (sentrosomeFalsePopUp != null) sentrosomeFalsePopUp.SetActive(false);
            if (sentrosomeNextButton != null) sentrosomeNextButton.interactable = true;

        }
        else
        {
            if (sentrosomeFalsePopUp != null) sentrosomeFalsePopUp.SetActive(true);
            if (sentrosomeTruePopUp != null) sentrosomeTruePopUp.SetActive(false);
        }
    }

    void CheckLisosomeNotebook()
    {
        if (lisosomeDropdown.value == 1 && lisosomeDropdown1.value == 2)
        {

            lisosomeDropdown.interactable = false;
            lisosomeDropdown1.interactable = false;

            if (lisosomeTruePopUp != null) lisosomeTruePopUp.SetActive(true);
            if (lisosomeFalsePopUp != null) lisosomeFalsePopUp.SetActive(false);
            if (lisosomeNextButton != null) lisosomeNextButton.interactable = true;
        }
        else
        {
            if (lisosomeFalsePopUp != null) lisosomeFalsePopUp.SetActive(true);
            if (lisosomeTruePopUp != null) lisosomeTruePopUp.SetActive(false);
        }
    }
    public void RfaEnableButton(Button targetButton)
    {
        if (targetButton != null) { targetButton.interactable = true; }

    }

    public void SaveButtonOnclicked() 
    {
        CheckErNotebook();
        CheckGolgiNotebook();
        CheckSentrosomeNotebook();
        CheckLisosomeNotebook();
    }

  
}
