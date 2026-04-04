using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class AnalyzerDrop : MonoBehaviour ,IDropHandler
{
    public string targetType;

    public string objectname = "";
    public GameObject mineral_label;
    public GameObject protein_label;
    public GameObject oil_label;
    public GameObject organel_label;
    public GameObject nucleus_label;

    public void OnDrop(PointerEventData eventData) // bunun içindeki yazýlar ve dropscriptteki matched satýrlarý olmadan aslýnda drop çalýþýyor ama objeyi etkilemesi gerek
    {
        AnalyzerDrag dragged = eventData.pointerDrag.GetComponent<AnalyzerDrag>();//sürüklenen objenin drag scriptine ulaþmamý saðlar
        dragged.matched = true;



        if (dragged != null)
        {
            // Cihazýn geri dönmesini engelle ve merkeze oturt
            dragged.matched = true;
            dragged.rt.position = this.GetComponent<RectTransform>().position;// ortasýna gitmesini saðlýyor sürüklenen objenin 

            // 2. Cihazýn içindeki targetobject deðiþkenini bu objenin türüyle doldur
            dragged.targetobject = this.targetType.ToLower();

            // 3. Analiz Sonucunu Göster (Label Aktif Etme)
            ActivateCorrectLabel(dragged.targetobject);

        }

    }
    private void ActivateCorrectLabel(string type)
    {
     
        string check = type.Trim().ToLower();


        if (check == "mineral" && mineral_label != null) mineral_label.SetActive(true);

        if (check == "protein" && protein_label != null) protein_label.SetActive(true);

        if ((check == "oil" || check == "yað") && oil_label != null) oil_label.SetActive(true);

        if (check == "organel" && organel_label != null) organel_label.SetActive(true);

        if ((check == "nucleus" || check == "çekirdek") && nucleus_label != null) nucleus_label.SetActive(true);

        if ((check == "protein" ) && protein_label != null) protein_label.SetActive(true);
    }

}


    

