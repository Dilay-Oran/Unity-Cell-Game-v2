using TMPro;       
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameManager3 : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown cellWallDropdown;
    public TMP_Dropdown chloroplastDropdown;
    public TMP_Dropdown chloroplastDropdown1;
    public TMP_Dropdown chloroplastDropdown2;
    public TMP_Dropdown assessmentDropdownQ1;
    public TMP_Dropdown assessmentDropdownQ2;
    public TMP_Dropdown assessmentDropdownQ3;
    public TMP_Dropdown assessmentDropdownQ4;
    public TMP_Dropdown assessmentDropdownQ5;

    [Header("Buttons")]
    public Button cellWallNextButton;
    public Button cellMembraneOilNextButton;
    public Button cellMembraneCarbohydrateNextButton;
    public Button cellMembraneProteinNextButton;
    public Button rfaNextButton;
    public Button chloroplastNextButton;
    public Button lisosomeNextButton;
    public Button centrosomeNextButton;
    public Button nucleusNextButton;
    public Button controllButtonQ1;
    public Button controllButtonQ2;
    public Button controllButtonQ3;
    public Button controllButtonQ4;
    public Button controllButtonQ5;

    [Header("Popups")]
    public GameObject cellWallTruePopUp;
    public GameObject cellWallFalsePopUp;
    public GameObject chloroplastTruePopUp;
    public GameObject chloroplastFalsePopUp;
    public GameObject assessmentTruePopUp;
    public GameObject assessmentFalsePopUp;

    [Header("Input Fields")]
    public TMP_InputField cellMembraneInputField;
    public TMP_InputField cellMembraneInputField1;
    public TMP_InputField cellMembraneInputField2;
    public TMP_InputField lisosomeInputField;
    public TMP_InputField centrosomeInputField;

    [Header("Drag and Drop Draggables")]
    public List<DragScript> rfaDraggables;
    public List<DragScript> nucleusDraggables;

    [Header("Assessment Backgrounds")]
    public GameObject assessmentBackgroundQ1;
    public GameObject assessmentBackgroundQ2;
    public GameObject assessmentBackgroundQ3;
    public GameObject assessmentBackgroundQ4;
    public GameObject assessmentBackgroundQ5;

    [Header("Speech Including Name")]
    public TMP_Text speech;

    public void Update()
    {
        AddName();
        CellMembraneController();
        CheckRfaMatched();
        OrganellesController();
        CheckNucleusMatched();
    }
    public void AddName()
    {
        if (PlayerData.playerName != null && PlayerData.playerName.Length > 0)
        {
            speech.text = speech.text.Replace("{isim}", PlayerData.playerName);
        }
    }
    void CheckCellWall()
    {


        if (cellWallDropdown.value == 2)
        {

            cellWallDropdown.interactable = false;

            if (cellWallTruePopUp != null) cellWallTruePopUp.SetActive(true);
            if (cellWallFalsePopUp != null) cellWallFalsePopUp.SetActive(false);
            if (cellWallNextButton != null) cellWallNextButton.interactable = true;
        }
        else
        {
            if (cellWallFalsePopUp != null) cellWallFalsePopUp.SetActive(true);
            if (cellWallTruePopUp != null) cellWallTruePopUp.SetActive(false);
        }

    }

    void CellMembraneController() 
    {
        if (cellMembraneInputField.text.ToLower().Trim() == "yað" )
        {
            cellMembraneOilNextButton.interactable = true;
        }
        if (cellMembraneInputField1.text.ToLower().Trim() == "karbonhidrat")
        {
            cellMembraneCarbohydrateNextButton.interactable = true;
        }
        if (cellMembraneInputField2.text.ToLower().Trim() == "protein")
        {
            cellMembraneProteinNextButton.interactable = true;
        }
   

    }

    void CheckRfaMatched()
    {
        if (rfaDraggables == null || rfaDraggables.Count == 0) return;

        bool isEverythingDoneRfa = true;
        foreach (DragScript item in rfaDraggables)
        {
            if (!item.matched)
            {
                isEverythingDoneRfa = false;
                break;
            }
        }
        rfaNextButton.interactable = isEverythingDoneRfa;
    }

    void CheckChloroplast()
    {


        if (chloroplastDropdown.value == 3 || chloroplastDropdown1.value == 3 || chloroplastDropdown2.value == 2)
        {

            chloroplastDropdown.interactable = false;
            chloroplastDropdown1.interactable = false;
            chloroplastDropdown2.interactable = false;

            if (chloroplastTruePopUp != null) chloroplastTruePopUp.SetActive(true);
            if (chloroplastFalsePopUp != null) chloroplastFalsePopUp.SetActive(false);
            if (chloroplastNextButton != null) chloroplastNextButton.interactable = true;
        }
        else
        {
            if (chloroplastFalsePopUp != null) chloroplastFalsePopUp.SetActive(true);
            if (chloroplastTruePopUp != null) chloroplastTruePopUp.SetActive(false);
        }

    }

    void OrganellesController()
    {
        if (lisosomeInputField.text.ToLower().Trim() == "lizozom")
        {
            lisosomeNextButton.interactable = true;
        }
        if (centrosomeInputField.text.ToLower().Trim() == "sentrozom")
        {
            centrosomeNextButton.interactable = true;
        }
        
    }

    void CheckNucleusMatched()
    {
        if (nucleusDraggables == null || nucleusDraggables.Count == 0) return;

        bool isEverythingDoneNucleus = true;
        foreach (DragScript item in nucleusDraggables)
        {
            if (!item.matched)
            {
                isEverythingDoneNucleus = false;
                break;
            }
        }
        nucleusNextButton.interactable = isEverythingDoneNucleus;
    }

    void AssessmentController()
    {
        if (assessmentDropdownQ1.value == 1)
        {
            assessmentDropdownQ1.interactable = false;
            assessmentFalsePopUp.SetActive(false);
            assessmentTruePopUp.SetActive(true);

        }
        if (centrosomeInputField.text.ToLower().Trim() == "sentrozom")
        {
            centrosomeNextButton.interactable = true;
        }

    }

    void CheckButtonOnCliked()
    {
        AssessmentController();
    }
    public void SaveButtonOnclicked()
    {
        CheckCellWall();
        CheckChloroplast();
       
    }


}
