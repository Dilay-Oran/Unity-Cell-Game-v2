using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MitochondriaAnimatorScrpit : MonoBehaviour
{
       
    [Header("Drag & Drop")]
    public DragScript oxygenDraggable; 

    [Header("Animation")]
    public Animator mitochondriaAnimator;
    public string animationTriggerName = "PlayAnim"; 

    [Header("Button")]
    public Button mitochondriaAnimatorNextButton;
    private bool animationStarted = false;

    void Start()
    {
        mitochondriaAnimatorNextButton.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (animationStarted) return;

        bool allMatched = true;

        if (!oxygenDraggable.matched)
        {
            allMatched = false;
        }

        if (allMatched) // ← Bu kısım eksikti
        {
            StartAnimation();
        }

    }


    void StartAnimation()
    {
        animationStarted = true;
        mitochondriaAnimator.SetTrigger(animationTriggerName);
        StartCoroutine(EnableButtonAfterAnimation());
    }

    System.Collections.IEnumerator EnableButtonAfterAnimation()
    {
        // Animator'ın transition'ı tamamlamasını bekle
        yield return new WaitUntil(() =>
            mitochondriaAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mitochondria Animation"));

        // Şimdi süreyi oku
        float length = mitochondriaAnimator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(length);

        mitochondriaAnimatorNextButton.interactable = true;

    }


}
