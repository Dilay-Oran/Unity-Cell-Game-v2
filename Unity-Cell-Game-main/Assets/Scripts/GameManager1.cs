using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager1 : MonoBehaviour
{
    [Header("Buttons")]
    public Button draggingNextButton;
    public Button mitochondriaNextButton;
    public Button ribosomeNextButton;
    public Button magnifierRibosomeNextButton;
    public Button vacouleNextButton;
    public Button vacouleNoteBookNextButton;
    public Button rfaNextButton;
    public Button rfa1NextButton;
    public Button rfa2NextButton;

    [Header("Drag and Drop Draggables")]
    public DragScript magnifierDraggable;
    public List<DragScript> vacouleDraggables;
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

    [Header("Ribosome Notebook Section")]
    public TMP_Dropdown ribosomeDropdown;
    public TMP_Dropdown ribosomeDropdown1;

    [Header("Vacoule Notebook Section")]
    public TMP_Dropdown vacouleDropdown;
    public TMP_Dropdown vacouleDropdown1;
    public TMP_Dropdown vacouleDropdown2;
    public TMP_Dropdown vacouleDropdown3;
    public TMP_Dropdown vacouleDropdown4;


    [Header("Popups")]
    public GameObject truePopUp;  
    public GameObject falsePopUp; 
    public GameObject mitochondriaTruePopUp;
    public GameObject mitochondriaFalsePopUp;
    public GameObject ribosomeTruePopUp;
    public GameObject ribosomeFalsePopUp;
    public GameObject vacouleTruePopUp;
    public GameObject vacouleFalsePopUp;

    void Start()
    {
        
        if (truePopUp != null) truePopUp.SetActive(false);
        if (falsePopUp != null) falsePopUp.SetActive(false);
        if (cytoNextButton != null) cytoNextButton.interactable = false;
        if (draggingNextButton != null) draggingNextButton.interactable = false;
        if (magnifierRibosomeNextButton != null) magnifierRibosomeNextButton.interactable = false;
        if (vacouleNextButton != null) vacouleNextButton.interactable = false;  

    }
    void Update()
    {

        CheckAllMatched();
        CheckMagnifierMatched();
        CheckVacouleMatched();
    }

    public void RfaEnableButton(Button targetButton)
    {
        if (targetButton != null) { targetButton.interactable = true; }

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
    void CheckMagnifierMatched()
    {
        if (magnifierDraggable == null || magnifierRibosomeNextButton == null) return;

        magnifierRibosomeNextButton.interactable = magnifierDraggable.matched;
    }
    void CheckVacouleMatched()
    {
        if (vacouleDraggables == null || vacouleDraggables.Count == 0) return;

        bool isEverythingDoneVacoule = true;
        foreach (DragScript item in vacouleDraggables)
        {
            if (!item.matched)
            {
                isEverythingDoneVacoule = false;
                break;
            }
        }
        vacouleNextButton.interactable = isEverythingDoneVacoule;
    }
    public void SaveButtonOnclicked()

    {
        // ----------------Cytoplasm 2--------------------

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
            
            mitochondriaFalsePopUp.SetActive(true);
            mitochondriaTruePopUp.SetActive(false);
            mitochondriaNextButton.interactable = false;
        }

        // --------Ribosome--------------

        if (ribosomeDropdown.value == 1 && ribosomeDropdown1.value== 2 )
        {

            ribosomeDropdown.interactable = false;
            ribosomeDropdown1.interactable = false;

            ribosomeTruePopUp.SetActive(true);
            ribosomeNextButton.interactable = true;
            ribosomeFalsePopUp.SetActive(false);


            if (ribosomeDropdown != null && ribosomeDropdown1 != null)
            {
                ribosomeDropdown.value = 1;
                ribosomeDropdown1.value = 2;

                ribosomeDropdown.RefreshShownValue();
                ribosomeDropdown1.RefreshShownValue();


                ribosomeDropdown.interactable = false;
                ribosomeDropdown1 .interactable = false;

            }

        }
        else
        {
            
            ribosomeFalsePopUp.SetActive(true);
            ribosomeTruePopUp.SetActive(false);
            ribosomeNextButton.interactable = false;
        }




        // --------Vacoule--------------
        bool secondq = (vacouleDropdown2.value == 1 || vacouleDropdown2.value == 2 || vacouleDropdown2.value == 4) &&
                       (vacouleDropdown3.value == 1 || vacouleDropdown3.value == 2 || vacouleDropdown3 .value == 4) &&
                       (vacouleDropdown4.value == 1 || vacouleDropdown4.value == 2 || vacouleDropdown4.value == 4);

        bool firstq = vacouleDropdown.value == 2 && vacouleDropdown1.value == 2  ;
        bool vacouleCorrect = firstq && secondq;

        Debug.Log($"firstq: {firstq}, secondq: {secondq}, vacouleCorrect: {vacouleCorrect}");
        Debug.Log($"d0:{vacouleDropdown.value} d1:{vacouleDropdown1.value} d2:{vacouleDropdown2.value} d3:{vacouleDropdown3.value} d4:{vacouleDropdown4.value}");
        vacouleTruePopUp.SetActive(vacouleCorrect);
        vacouleFalsePopUp.SetActive(!vacouleCorrect);
        vacouleNoteBookNextButton.interactable = vacouleCorrect;


        if (vacouleCorrect)
        {
            vacouleDropdown.interactable = false;
            vacouleDropdown1.interactable = false;
            vacouleDropdown2.interactable = false;
            vacouleDropdown3.interactable = false;
            vacouleDropdown4.interactable = false;

            vacouleDropdown.RefreshShownValue();
            vacouleDropdown1.RefreshShownValue();
            vacouleDropdown2.RefreshShownValue();
            vacouleDropdown3.RefreshShownValue();
            vacouleDropdown4.RefreshShownValue();


        }
    } 
}