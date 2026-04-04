using UnityEngine;
using UnityEngine.EventSystems;

public class AnalyzerDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public RectTransform rt; // objelerin x,y,z deðerlerini deðiþtirmek için kullanacaðýmýz deðiþken
    Canvas canvas; // scaling (objenin mouse ile ayný hareket etmemesi) problemini çözmek için kullanacaðýz
    Vector2 startpos; // vector 2 olmasý önemli unutma
    CanvasGroup cg;
    public bool matched = false;
    public string targetobject;
    public string result = "does not matched"; // true or false
    public GameObject[] allLabels;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rt = GetComponent<RectTransform>(); // objenin rect tranformuna ulaþtýk ve onu yukarýda tanýmladýðýmýz rt deðiþkeninin içine attýk
        canvas = GetComponentInParent<Canvas>(); // canvasýn özelliklerine ulaþmaný saðlýyor
        startpos = rt.anchoredPosition; // objenin baþlangýç anýndaki pozisyonu 
        cg = GetComponent<CanvasGroup>();
        targetobject = "";

        if (cg == null) cg = gameObject.AddComponent<CanvasGroup>(); // cg yoksa otomatik ekleme
    }

    public void OnDrag(PointerEventData eventData) // bu satýrý eklediðin an aslýnda event çalýþýyor ama objeyle ilgili bir þey deðiþtirmediðin için sürükleniyor gibi gözüküyor
    {
        matched = false; // her sürüklemeye baþladýðýmda matched = false yapar
        rt.anchoredPosition += eventData.delta / canvas.scaleFactor; // scaling problemini çözen satýr
    }

    public void OnBeginDrag(PointerEventData eventData) // sürüklemeye baþladýðýnda raycasti iptal etme
    {
        matched |= false;
        cg.blocksRaycasts = false;

        // --- Sürükleme baþladýðýnda tüm etiketleri kapat ---
        if (allLabels != null)
        {
            foreach (GameObject lbl in allLabels)
            {
                if (lbl != null) lbl.SetActive(false);
            }
        }
        //-----------------------------------------------------
    }

    public void OnEndDrag(PointerEventData eventData) // býrakýnca raycast aktifleþiyor
    {
        cg.blocksRaycasts = true;

        // Eðer bir yere yerleþmediyse (matched hala false ise) geri dön
        if (!matched)
        {
            rt.anchoredPosition = startpos;
        }
    }

    public void BacktoStartPos()  // matchleþmeyen yere býrakýðýmda start positiona dönmesi 
    {
        if (!matched) // matched = false ise 
            rt.anchoredPosition = startpos;//baþlangýc positiona dön
    }
}
