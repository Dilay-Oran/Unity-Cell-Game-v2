using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationTrigger : MonoBehaviour
{
    public Animator chromatineAnimator;
    public Animator BoxAnimator;
    public Animator ChromosomeAnimator;
    public Button nextButton; 

    public void OnButtonClick()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        chromatineAnimator.Play("Chromatin Animation");
        yield return new WaitForSeconds(1f);

        BoxAnimator.Play("Chromatin Machine Animation");
        yield return new WaitForSeconds(1.55f);

        ChromosomeAnimator.Play("Chromosome Animation");
        yield return new WaitForSeconds(3.10f);

        nextButton.interactable = true; // Tüm animasyonlar bitince next aktif
    }
}