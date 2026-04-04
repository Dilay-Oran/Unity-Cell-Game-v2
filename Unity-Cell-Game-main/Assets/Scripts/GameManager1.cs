using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager1 : MonoBehaviour
{
    [Header("Drag and Drop Buttons and Draggables")]
    public Button draggingNextButton;
    public Button mitochondriaNextButton;
    public List<DragScript> Draggables;

    [Header("Cytoplasm Notebook Section")]
    public TMP_Dropdown cytoThirdDropdown;
    public TMP_Dropdown cytoFourthDropdown;
    public TMP_Dropdown cytoFifthDropdown;
    public TMP_Dropdown cytoSixthDropdown;
    public TMP_Dropdown cytoSeventhDropdown;
    public Button cytoNextButton;

    [Header("Mitochondria Notebook Section")]
    public TMP_Dropdown mitochondriaDropdown;


    [Header("Popups")]
    public GameObject truePopUp;  
    public GameObject falsePopUp; 
    public GameObject mitochondriaTruePopUp;
    public GameObject mitochondriaFalsePopUp;

    void Start()
    {
        
        if (truePopUp != null) truePopUp.SetActive(false);
        if (falsePopUp != null) falsePopUp.SetActive(false);
        if (cytoNextButton != null) cytoNextButton.interactable = false;
        if (draggingNextButton != null) draggingNextButton.interactable = false;
    }
    void Update()
    {

        CheckAllMatched();
    }

    void CheckAllMatched()
    {
        if (Draggables == null || Draggables.Count == 0) return;

        bool isEverythingDone = true;
        foreach (DragScript item in Draggables)
        {
            if (!item.matched)
            {
                isEverythingDone = false;
                break;
            }
        }
        draggingNextButton.interactable = isEverythingDone;
    }
    public void SaveButtonOnclicked()
    {

        int a3 = cytoThirdDropdown.value;
        int a4 = cytoFourthDropdown.value;
        int a5 = cytoFifthDropdown.value;
        int a6 = cytoSixthDropdown.value;
        int a7 = cytoSeventhDropdown.value;

        
        bool correctionControl = (a3 == 2 || a3 == 4 || a3 == 1 || a3 == 7 || a3 == 8) &&
                                 (a4 == 2 || a4 == 4 || a4 == 1 || a4 == 7 || a4 == 8) &&
                                 (a5 == 2 || a5 == 4 || a5 == 1 || a5 == 7 || a5 == 8) &&
                                 (a6 == 2 || a6 == 4 || a6 == 1 || a6 == 7 || a6 == 8) &&
                                 (a7 == 2 || a7 == 4 || a7 == 1 || a7 == 7 || a7 == 8);

        if (correctionControl)
        {
            
            cytoThirdDropdown.interactable = false;
            cytoFourthDropdown.interactable = false;
            cytoFifthDropdown.interactable = false;
            cytoSixthDropdown.interactable = false;
            cytoSeventhDropdown.interactable = false;

            if (truePopUp != null) truePopUp.SetActive(true);
            if (falsePopUp != null) falsePopUp.SetActive(false);

            if (cytoNextButton != null) cytoNextButton.interactable = true;
            if (draggingNextButton != null) draggingNextButton.interactable = true;

        }
        else
        {
            if (falsePopUp != null) falsePopUp.SetActive(true);
            if (truePopUp != null) truePopUp.SetActive(false);
        }

        // --------Mitochondria--------------

        if (mitochondriaDropdown.value == 1)
        {
           
            mitochondriaDropdown.interactable = false;
          
            mitochondriaTruePopUp.SetActive(true);
            mitochondriaNextButton.interactable = true;
            mitochondriaFalsePopUp.SetActive(false);

           
            if (mitochondriaDropdown != null)
            {
                mitochondriaDropdown.value = 1;
                
                mitochondriaDropdown.RefreshShownValue();
                
                mitochondriaDropdown.interactable = false;
                
            }

        }
        else
        {
            // wrong answer
            mitochondriaFalsePopUp.SetActive(true);
            mitochondriaTruePopUp.SetActive(false);
            mitochondriaNextButton.interactable = false;
        }
    } 
}