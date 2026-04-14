using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleusAnimatiorScript : MonoBehaviour
{
    [Header("Animation")]
    public Animator nucleusAnimator;
    public string triggerName = "PlayAnimNucleus";

    [Header("Animasyon Bitince Kapanacaklar")]
    public List<GameObject> objectsToHide;

    [Header("Animasyon Bitince Açýlacaklar")]
    public List<GameObject> objectsToShow;

    public void OnNextButtonClicked()
    {
        nucleusAnimator.SetTrigger(triggerName);
        StartCoroutine(WaitAndChange());
    }

    System.Collections.IEnumerator WaitAndChange()
    {
        yield return new WaitForSeconds(4.267f);

        foreach (GameObject obj in objectsToHide)
            if (obj != null) obj.SetActive(false);

        foreach (GameObject obj in objectsToShow)
            if (obj != null) obj.SetActive(true);
    }


}