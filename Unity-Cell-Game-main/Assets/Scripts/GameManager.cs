using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // variables
    [Header("Screen Management")]
    public GameObject Name_Screen;
    public GameObject Introduction_Screen3;
    public TMP_InputField nameInput;

    [Header("Cell Membrane Drag and Drop")]
    public Button cell_membrane_next_button;
    public List<DragScript> allDraggables;

    [Header("NeoNefes Notebook Section")]
    public TMP_Dropdown firstDropdown;
    public TMP_Dropdown secondDropdown;
    public Button NeoNefesNotebookNextButton;
    public GameObject truePopUp;
    public GameObject falsePopUp;

    [Header("Cytoplasm Notebook Section")]
    public TMP_Dropdown cytoFirstDropdown;
    public TMP_Dropdown cytoSecondDropdown;

    [Header("Cell Membrane Notebook Section")]
    public TMP_Dropdown membraneFirstDropdown;
    public TMP_Dropdown membraneSecondDropdown;
    public TMP_Dropdown membraneThirdDropdown;
    public TMP_Dropdown membraneFourthDropdown;
    public Button cell_membrane_next_button_3;
    public GameObject membranetruePopUp;
    public GameObject membranefalsePopUp;


    public int trueIndex1 = 1;
    public int trueIndex2 = 2;



    void Start()
    {

        if (cell_membrane_next_button != null) cell_membrane_next_button.interactable = false;
        if (NeoNefesNotebookNextButton != null) NeoNefesNotebookNextButton.interactable = false;
        if (cell_membrane_next_button_3 != null) cell_membrane_next_button.interactable |= false;

        if (truePopUp != null) truePopUp.SetActive(false);
        if (falsePopUp != null) falsePopUp.SetActive(false);
        if (membranetruePopUp != null) membranetruePopUp.SetActive(false);
        if (membranefalsePopUp != null) membranefalsePopUp.SetActive(false);

    }

    void Update()
    {

        CheckAllMatched();
    }

    void CheckAllMatched()
    {
        if (allDraggables == null || allDraggables.Count == 0) return;

        bool isEverythingDone = true;
        foreach (DragScript item in allDraggables)
        {
            if (!item.matched)
            {
                isEverythingDone = false;
                break;
            }
        }
        cell_membrane_next_button.interactable = isEverythingDone;
    }

    // button functions

    public void nameButtonClicked()
    {
        if (nameInput.text.Length > 0)
        {
            PlayerData.playerName = nameInput.text;
            Name_Screen.SetActive(false);
            Introduction_Screen3.SetActive(true);
        }
        else
        {
            Debug.Log("Lütfen isim giriniz.");
        }
    }

    public void SaveButtonOnclicked() //notebook
    {
        // --------CYTOPLASM--------------

        if (firstDropdown.value == trueIndex2 && secondDropdown.value == trueIndex2)
        {
            // correct answer
            firstDropdown.interactable = false;
            secondDropdown.interactable = false;
            truePopUp.SetActive(true);
            NeoNefesNotebookNextButton.interactable = true;
            falsePopUp.SetActive(false);

            // to save dropdown values in cytoplasm part
            if (cytoFirstDropdown != null && cytoSecondDropdown != null)
            {
                cytoFirstDropdown.value = trueIndex2;
                cytoSecondDropdown.value = trueIndex2;

                cytoFirstDropdown.RefreshShownValue();
                cytoSecondDropdown.RefreshShownValue();

                cytoFirstDropdown.interactable = false;
                cytoSecondDropdown.interactable = false;
            }

        }
        else
        {
            // wrong answer
            falsePopUp.SetActive(true);
            truePopUp.SetActive(false);
            NeoNefesNotebookNextButton.interactable = false;
        }


        // ------------- CELL MEMBRANE-----------------

        int v1 = membraneFirstDropdown.value;
        int v2 = membraneSecondDropdown.value;
        int v3 = membraneThirdDropdown.value;
        int v4 = membraneFourthDropdown.value;


        bool isFirstThreeValid = (v1 == 2 || v1 == 4 || v1 == 5) &&
                                 (v2 == 2 || v2 == 4 || v2 == 5) &&
                                 (v3 == 2 || v3 == 4 || v3 == 5);

        bool isFourthValid = (v4 == 2);

        if (isFirstThreeValid && isFourthValid)
        {

            membranetruePopUp.SetActive(true);
            membranefalsePopUp.SetActive(false);
            cell_membrane_next_button_3.interactable = true;


            membraneFirstDropdown.interactable = false;
            membraneSecondDropdown.interactable = false;
            membraneThirdDropdown.interactable = false;
            membraneFourthDropdown.interactable = false;
        }
        else
        {

            membranetruePopUp.SetActive(false);
            membranefalsePopUp.SetActive(true);
            cell_membrane_next_button_3.interactable = false;
        }





    }
}