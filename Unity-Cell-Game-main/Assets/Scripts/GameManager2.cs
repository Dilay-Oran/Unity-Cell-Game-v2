using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic; 



public class GameManager2 : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown golgiDropdown;
    public TMP_Dropdown golgiDropdown1;

    [Header("Buttons")]
    public Button golgiNextButton;
    public Button saveButton;

    [Header("Popups")]
    public GameObject golgiTruePopUp;
    public GameObject golgiFalsePopUp;





    public void SaveButtonOnclicked() 
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

  
}
