using UnityEngine;
using UnityEngine.UI;       
using TMPro;       

public class GameManager3 : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown cellWallDropdown;

    [Header("Buttons")]
    public Button cellWallNextButton;

    [Header("Popups")]
    public GameObject cellWallTruePopUp;
    public GameObject cellWallFalsePopUp;


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
    public void SaveButtonOnclicked()
    {
        CheckCellWall();
     
    }

}
