using TMPro;       
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameManager3 : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown cellWallDropdown;

    [Header("Buttons")]
    public Button cellWallNextButton;
    public Button cellMembraneOilNextButton;
    public Button cellMembraneCarbohydrateNextButton;
    public Button cellMembraneProteinNextButton;
    public Button rfaNextButton;

    [Header("Popups")]
    public GameObject cellWallTruePopUp;
    public GameObject cellWallFalsePopUp;

    [Header("Input Fields")]
    public TMP_InputField cellMembraneInputField;
    public TMP_InputField cellMembraneInputField1;
    public TMP_InputField cellMembraneInputField2;

    [Header("Drag and Drop Draggables")]
    public List<DragScript> rfaDraggables;

    public void Update()
    {
        CellMembraneController();
        CheckRfaMatched();
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
    public void SaveButtonOnclicked()
    {
        CheckCellWall();
     
    }


}
