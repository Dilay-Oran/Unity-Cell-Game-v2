using UnityEngine;
using UnityEngine.UI;       
using TMPro;       

public class GameManager3 : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown cellWallDropdown;

    [Header("Buttons")]
    public Button cellWallNextButton;
    public Button cellMembraneOilNextButton;
    public Button cellMembraneCarbohydrateNextButton;
    public Button cellMembraneProteinNextButton;

    [Header("Popups")]
    public GameObject cellWallTruePopUp;
    public GameObject cellWallFalsePopUp;

    [Header("Input Fields")]
    public TMP_InputField cellMembraneInputField;
    public TMP_InputField cellMembraneInputField1;
    public TMP_InputField cellMembraneInputField2;

    public void Update()
    {
        CellMembraneController();
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
    public void SaveButtonOnclicked()
    {
        CheckCellWall();
     
    }


}
