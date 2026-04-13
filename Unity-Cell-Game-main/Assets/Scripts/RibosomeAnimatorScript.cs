using UnityEngine;
using UnityEngine.UI;

public class RibosomeAnimatorScript : MonoBehaviour
{

    [Header("Drag & Drop")]
    public DragScript orderDraggable;

    [Header("Animation")]
    public Animator ribosomeAnimator;
    public string animationTriggerName = "PlayAnimRibosome";

    [Header("Button")]
    public Button ribosomeAnimatorNextButton;
    private bool animationStarted = false;

    [Header("Text")]
    public TMPro.TextMeshProUGUI proteinsText;
    void Start()
    {
        ribosomeAnimatorNextButton.interactable = false;
    }

 
    void Update()
    {
        if (animationStarted) return;

        bool allMatched = true;

        if (!orderDraggable.matched)
        {
            allMatched = false;
        }

        if (allMatched) 
        {
            StartAnimation();
        }
    }

    void StartAnimation()
    {
        animationStarted = true;
        ribosomeAnimator.SetTrigger(animationTriggerName);
        StartCoroutine(EnableButtonAfterAnimation());
    }

    System.Collections.IEnumerator EnableButtonAfterAnimation()
    {

        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(1.9f);
        proteinsText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);


        ribosomeAnimatorNextButton.interactable = true;
       
    }
}
